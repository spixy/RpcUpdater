using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CommandLine;
using DiscordRPC;

namespace RpcUpdater
{
    public class Program
    {
        private static ProgramOptions options;
        private static HelpWriter helpWriter;

        private static async Task Main(string[] args)
        {
            var parser = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new Parser(settings => { settings.HelpWriter = helpWriter = new HelpWriter(); })
                : Parser.Default;

            parser.ParseArguments<ProgramOptions>(args)
                  .WithParsed(OnParseSuccess)
                  .WithNotParsed(OnParseError);

            if (options != null)
            {
                var rpcUpdater = new RpcUpdater(options.ApplicationId)
                {
                    RichPresence = new RichPresence
                    {
                        Details = options.Details,
                        State = options.State,
                        Assets = new Assets
                        {
                            LargeImageKey = options.LargeImageKey,
                            SmallImageKey = options.SmallImageKey,
                            LargeImageText = options.LargeImageText,
                            SmallImageText = options.SmallImageText
                        }
                    }
                };

                await rpcUpdater.WaitForConnectAsync();
                await rpcUpdater.UpdateAsync(options.TickRate);

                rpcUpdater.Dispose();
            }
        }

        private static void OnParseSuccess(ProgramOptions programOptions)
        {
            options = programOptions;
        }

        private static void OnParseError(IEnumerable<Error> errs)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                WinConsole.Show();
                helpWriter.WriteToConsole();
                Console.ReadKey();
            }
            else
            {
                Environment.Exit(-1);
            }
        }
    }
}
