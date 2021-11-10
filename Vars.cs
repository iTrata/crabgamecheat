using System;
using System.Collections.Generic;
using System.Text;

namespace CrabGameCheat
{
    class Vars
    {

        // hack toogles & utility variables
        public static bool InGame;
        public static bool AirJump;
        public static bool OmegaJump;
        public static bool ClickTp;
        public static bool Speed;
        public static bool NoClip;
        public static bool Hover;
        public static int CurId;
        public static int UserSelect;
        public static bool MainToggle;
        public static int KAS;
        public static bool PlayerEsp;
        public static bool HighlightPlayer;
        public static string HighlightPlayerName;
        public static bool PlatformEsp;
        public static bool GodMode;
        public static bool NoFall;
        public static bool NoKnockback;
        public static int SpeedMultiplier = 3;
        public static bool OmegaPunch;
        public static bool RainbowText = true;
        public static bool RainbowTop = true;
        public static bool SettingKey;
        public static UnityEngine.KeyCode clientkey = UnityEngine.KeyCode.RightShift;
        public static string bindtext;
        public static bool NoPuchCooldown;
        public static bool NoPunchShake;
        public static bool NoFreeze;
        public static bool ShowHacks = true;
        public static string[] AllHacks = new string[] { "bruhwhyru looking at my code xd its opensorucesbfhsa","AirJump","OmegaJump", "ClickTp", "SwimFly", "Hover", "Player esp", "Highlight player", "Platform esp", "GodMode"
            , "NoFall", "Anti knockback", "OmegaPunch", "No punch cooldown", "No Punch Shake","Speed" , "NoFreeze"};
        public static int TotalToggleHacks = 17;
        public static bool[] AllActiveHacks = new bool[] { false,false, false, false, false, false, false, false, false, false, false, false, false, false , false, false, false};
        public static int CurrentHacksDrawPosition;
        public static List<UnityEngine.Vector3> WaypointPos = new List<UnityEngine.Vector3>();
        public static List<string> WaypointName = new List<string>();
        public static int SelectedWaypoint;
        public static int SequentialWaypointNumbers;

        public static UnityEngine.Color backcolor = UnityEngine.Color.black;
        public static UnityEngine.Color topcolor = currentrainbowcolor;
        public static UnityEngine.Color currentrainbowcolor;
        public static UnityEngine.Color textColor = UnityEngine.Color.green;

    }
}
