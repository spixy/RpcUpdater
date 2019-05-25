using System;
using System.Threading;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;

namespace RpcUpdater
{
    public class RpcUpdater : IDisposable
    {
        private readonly DiscordRpcClient client;
        private readonly CancellationTokenSource ctsForConnection = new CancellationTokenSource();

        /// <summary>
        /// If discord client is ready to send and receive messages
        /// </summary>
        public bool IsReady => ctsForConnection.IsCancellationRequested;

        /// <summary>
        /// The Rich Presence structure that will be sent and received by Discord. Use this class to build your presence and update it appropriately.
        /// </summary>
        public RichPresence RichPresence { get; set; }

        public RpcUpdater(string applicationId)
        {
            client = new DiscordRpcClient(applicationId)
            {
                Logger = new ConsoleLogger {Level = LogLevel.Warning}
            };
            client.OnReady += SetReady;
            client.Initialize();

            void SetReady(object sender, ReadyMessage args)
            {
                ctsForConnection.Cancel();
                client.OnReady -= SetReady;
            }
        }

        /// <summary>
        /// Wait until discord client is ready to send and receive messages.
        /// </summary>
        public async Task WaitForConnectAsync()
        {
            try
            {
                await Task.Delay(-1, ctsForConnection.Token);
            }
            catch (TaskCanceledException)
            {
            }
        }

        /// <summary>
        /// Update rich presence
        /// </summary>
        public async Task UpdateAsync(int tickRate, CancellationToken token = default)
        {
            if (!IsReady)
            {
                throw new Exception("Client is not ready yet.");
            }

            while (!token.IsCancellationRequested)
            {
                client.SetPresence(RichPresence);
                try
                {
                    await Task.Delay(tickRate, token);
                }
                catch (TaskCanceledException)
                {
                }
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
