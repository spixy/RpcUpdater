using CommandLine;

namespace RpcUpdater
{
    public class ProgramOptions
    {
        [Option("app-id", Required = true, HelpText = "The ID of the application created at discord's developers portal")]
        public string ApplicationId { get; set; }

        [Option("details", Required = false, HelpText = "What the user is currently doing", Default = null)]
        public string Details { get; set; }

        [Option("state", Required = false, HelpText = "The user's current party status", Default = null)]
        public string State { get; set; }

        [Option("large-image", Required = false, HelpText = "Name of the uploaded image for the large profile artwork", Default = null)]
        public string LargeImageKey { get; set; }

        [Option("large-image-text", Required = false, HelpText = "The tooltip for the large square image. For example, \"Summoners Rift\" or \"Horizon Lunar Colony\"", Default = null)]
        public string LargeImageText { get; set; }

        [Option("small-image", Required = false, HelpText = "Name of the uploaded image for the small profile artwork", Default = null)]
        public string SmallImageKey { get; set; }

        [Option("small-image-text", Required = false, HelpText = "The tooltip for the small circle image. For example, \"LvL 6\" or \"Ultimate 85%\"", Default = null)]
        public string SmallImageText { get; set; }

        [Option("tick-rate", Required = false, HelpText = "How often to change rich presence, in milliseconds", Default = 1000)]
        public int TickRate { get; set; }
    }
}
