using BepInEx;
using Photon.Pun;
using MakeGameWindowed.Important.Patching;
using System;
using UnityEngine;
using Utilla;
using UnityEngine.UI;

namespace MakeGameWindowed
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.14")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }
        public static bool IsEnabled { get; private set; }
        public static bool IsRoomModded { get; private set; }

        public void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        public void OnEnable()
        {
            TogglePatches(true);
        }

        public void OnDisable()
        {
            TogglePatches(false);
        }

        private void TogglePatches(bool enable)
        {
            if (enable)
            {
                HarmonyPatches.ApplyHarmonyPatches();
                IsEnabled = true;
            }
            else
            {
                HarmonyPatches.RemoveHarmonyPatches();
                IsEnabled = false;
            }
        }

        public void OnGameInitialized(object sender, EventArgs e)
        {
            
        }
        bool isFullscreen = true;
        void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 150, 50), isFullscreen ? "Windowed" : "Fullscreen"))
            {
                isFullscreen = !isFullscreen;
                if (isFullscreen)
                {
                    Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, FullScreenMode.FullScreenWindow);
                }
                else
                {
                    Screen.fullScreenMode = FullScreenMode.Windowed;
                }
            }
        }
    }

    public class PluginInfo
    {
        internal const string
            GUID = "poudll.makegamewindowed",
            Name = "MakeGameWindowed",
            Version = "1.0.0";
    }
}