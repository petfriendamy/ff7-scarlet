using AutoUpdaterDotNET;
using Newtonsoft.Json.Linq;

namespace FF7Scarlet.Shared
{
    public enum UpdateChannel { Stable, Canary }

    public static class ScarletUpdater
    {
        public const string
            UPDATE_ON_STARTUP_KEY = "UpdateOnStartup",
            UPDATE_CHANNEL_KEY = "UpdateChannel";

        private const string
            SCARLET_PREFIX = "FF7Scarlet-v",
            RELEASE_URL = "https://api.github.com/repos/petfriendamy/ff7-scarlet/releases/",
            CHANGE_LOG_URL = "https://github.com/petfriendamy/ff7-scarlet/releases/";

        private static bool loaded = false;

        public static UpdateChannel UpdateChannel { get; set; } = UpdateChannel.Stable;
        public static bool UpdateOnStartup { get; set; } = true;

        private static string GetUpdateVersion(string name)
        {
            return name.Replace(SCARLET_PREFIX, "");
        }

        private static string GetUpdateReleaseUrl(dynamic assets)
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

        private static string GetReleaseUrl(UpdateChannel channel)
        {
            string location = "latest";
            if (channel == UpdateChannel.Canary)
            {
                location = "tag/canary";
            }
            return RELEASE_URL + location;
        }

        public static void CheckForUpdates(UpdateChannel channel)
        {
            if (!loaded)
            {
                AutoUpdater.ParseUpdateInfoEvent += ParseUpdateInfoEvent;
                loaded = true;
            }
            AutoUpdater.Start(GetReleaseUrl(channel));
        }

        private static void ParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            dynamic release = JValue.Parse(args.RemoteData);

            args.UpdateInfo = new UpdateInfoEventArgs
            {
                CurrentVersion = GetUpdateVersion(release.name.Value),
                DownloadURL = GetUpdateReleaseUrl(release.assets),
                ChangelogURL = CHANGE_LOG_URL
            };
        }
    }
}
