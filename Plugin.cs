using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using HarmonyLib;
using System;

namespace CrabGameCheat
{
    [BepInPlugin("org.stikosek.crabgamecheat", "stikosek crab game cheat", "0.0.0.4")]
    [BepInProcess("Crab Game.exe")]
    public class Plugin : BasePlugin
    {

        





        public override void Load()
        {
            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

           

            GuiObject.CreateInstance(this);

            HackUtilities.StopAnticheat();
        }


        public void OnUpdate()
        {

            HackUtilities.Update();
            Vars.InGame = PlayerMovement.Instance != null;
           
        }
       
       
    }


    

}