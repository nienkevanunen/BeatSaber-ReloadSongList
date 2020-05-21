using IPA;
using IPALogger = IPA.Logging.Logger;
using BeatSaberMarkupLanguage.MenuButtons;

namespace ReloadSongList
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger log { get; set; }

        public static SemVer.Version Version => IPA.Loader.PluginManager.GetPlugin("ReloadSongList").Version;

        [Init]
        public Plugin(IPALogger logger)
        {
            Instance = this;
            log = logger;
        }

        [OnStart]
        public void OnApplicationStart()
        {
            log.Debug("Loaded ReloadSongList plugin.");
            MenuButtons.instance.RegisterButton(new MenuButton("Refresh Songs", "Refresh your custom song library", delegate { SongCore.Loader.Instance.RefreshSongs(); }));
        }

        [OnExit]
        public void OnApplicationQuit()
        {

        }

    }
}
