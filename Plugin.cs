﻿using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using EFT.UI.Map;
using InGameMap.Config;
using InGameMap.Patches;
using InGameMap.UI;

namespace InGameMap
{
    // the version number here is generated on build and may have a warning if not yet built
    [BepInPlugin("com.mpstark.InGameMap", "InGameMap", BuildInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;
        public static ManualLogSource Log => Instance.Logger;
        public static string Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public ModdedMapScreen Map;

        internal void Awake()
        {
            Settings.Init(Config);
            // Config.SettingChanged += (x, y) => InGameMap?.ReadConfig();

            Instance = this;

            // patches
            new MapScreenShowPatch().Enable();
        }

        /// <summary>
        /// Attach to the map screen
        /// </summary>
        internal void TryAttachToMapScreen(MapScreen screen)
        {
            if (Map != null)
            {
                return;
            }

            Map = ModdedMapScreen.AttachTo(screen.gameObject);
        }
    }
}
