using AutoUpdaterDotNET;
using Newtonsoft.Json.Linq;

namespace FF7Scarlet.Shared
{
    public enum UpdateChannel { Stable, Canary }

    public class ScarletUpdater
    {
        public const string
            UPDATE_ON_STARTUP_KEY = "UpdateOnStartup",
            UPDATE_CHANNEL_KEY = "UpdateChannel";

        private const string SCARLET_PREFIX = "FF7Scarlet-v";

        public UpdateChannel UpdateChannel { get; set; } = UpdateChannel.Stable;
        public bool UpdateOnStartup { get; set; } = true;

        public ScarletUpdater()
        {
            AutoUpdater.HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0";
            AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;
        }

        private string GetUpdateChannel(UpdateChannel channel)
        {
            switch (channel)
            {
                case UpdateChannel.Stable:
                    return "https://github.com/petfriendamy/ff7-scarlet/releases/latest";
                case UpdateChannel.Canary:
                    return "https://github.com/petfriendamy/ff7-scarlet/releases/tags/canary";
                default:
                    return "";
            }
        }

        private string GetUpdateVersion(string name)
        {
            return name.Replace(SCARLET_PREFIX, "");
        }

        private string GetUpdateReleaseUrl(dynamic assets)
        {
            foreach (dynamic asset in assets)
            {
                string url = asset.browser_download_url.Value;

                if (url.Contains(SCARLET_PREFIX) && url.EndsWith(".zip"))
                {
                    return url;
                }
            }
            return string.Empty;
        }

        public void CheckForUpdates()
        {
            AutoUpdater.Start(GetUpdateChannel(UpdateChannel));
        }

        private void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            dynamic release = JValue.Parse(args.RemoteData);

            args.UpdateInfo = new UpdateInfoEventArgs
            {
                CurrentVersion = (new Version(GetUpdateVersion(release.name.Value))).ToString(),
                DownloadURL = GetUpdateReleaseUrl(release.assets),
                ChangelogURL = GetUpdateChannel(UpdateChannel)
            };
        }
    }
}
