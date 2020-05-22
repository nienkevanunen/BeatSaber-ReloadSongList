using IPA;
using IPALogger = IPA.Logging.Logger;
using BeatSaberMarkupLanguage.MenuButtons;

namespace ReloadSongList
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger log { get; set; }

        public static SemVer.Version Version => IPA.Loader.PluginManager.GetPlugin("ReloadSongList").Version;

        private MenuButton _menuButton;

        [Init]
        public Plugin(IPALogger logger)
        {
            Instance = this;
            log = logger;
        }

        [OnEnable]
        public void OnEnable()
        {
            _menuButton = new MenuButton("Refresh Songs", "Refresh your custom song library", delegate { SongCore.Loader.Instance.RefreshSongs(); });
            log.Debug("Loaded ReloadSongList plugin.");
            MenuButtons.instance.RegisterButton(_menuButton);
        }

        [OnDisable]
        public void OnDisable()
        {
            MenuButtons.instance.UnregisterButton(_menuButton);
            _menuButton = null;
        }

    }
}
