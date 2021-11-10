using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using HarmonyLib;


namespace CrabGameCheat
{
    public class GuiStuff
    {
    }

    public class CreateGuiGameObject
    {

       public void CreateGameObject()
        {

        }
    }

    public class GuiObject : MonoBehaviour
    {
        //GameObject shit
        public GuiObject(IntPtr ptr) : base(ptr) { }
        private Plugin loader;

        //window rect variables

        public Rect MovementRect = new Rect(5, 20, 120, 140);
        public Rect ItemsRect = new Rect(130, 20, 120, 210);
        public Rect PlayerActRect = new Rect(255, 20, 180, 130);
        public Rect Visuals = new Rect(440, 20, 120, 60);
        public Rect PlayerRect = new Rect(565, 20, 120, 160);
        public Rect SettingsRect = new Rect(690, 20, 210, 135);
        public Rect WaypointRect = new Rect(905, 20, 180, 130);

        // ESP BARIABLS

        public bool playersnapline;
        public int lineposition;
        public Vector2 scrollPosition = Vector2.zero;

        

        public static void CreateInstance(Plugin loader)
        {
            //Create GameObject
            GuiObject obj = loader.AddComponent<GuiObject>();

            obj.loader = loader;

            //Prevent Unity from deleting when a new Scene loads.
            DontDestroyOnLoad(obj.gameObject);
            obj.hideFlags |= HideFlags.HideAndDontSave;
        }

        public void Update()
        {
            loader.OnUpdate();

            
        }
        StikosekGuiUtilities.RainbowColor rainbow = new StikosekGuiUtilities.RainbowColor(0.25f);

        public void OnGUI()
        {

            // StikosekGuiUtilities.DrawGui.DrawColor(UnityEngine.Vars.textColor, new Rect(50, 50, 50, 50));


            

            Vars.currentrainbowcolor = rainbow.GetColor();
            if (Vars.RainbowTop)
            {

                Vars.topcolor = Vars.currentrainbowcolor;
            }
            

            if(Vars.RainbowText == true)
            {
                Vars.textColor = Vars.currentrainbowcolor;
            }
            
            if(Vars.ShowHacks == true && Vars.InGame)
            {
                for (int i = 1; i < Vars.AllHacks.Length; i++)
                {
                    if(Vars.AllActiveHacks[i] == true)
                    {

                        GUI.Label(new Rect(0, Screen.height - Vars.CurrentHacksDrawPosition - 25, 200, 20), Vars.AllHacks[i], StikosekGuiUtilities.DrawGui.GetHackTextStyle(18, Vars.textColor));
                        Vars.CurrentHacksDrawPosition += 20;
                    }
                    
                }
                Vars.CurrentHacksDrawPosition = 0;
            }
            
            












            GUI.Label(new Rect(Screen.width /2 - 350/2, 10, 350, 40), "Crab game cheat V0.2 [by stikosek]", StikosekGuiUtilities.DrawGui.GetSecondTextStyle(18, Vars.textColor));

            if (Vars.MainToggle)
            {
                if (Vars.InGame)
                {
                    StikosekGuiUtilities.DrawGui.DrawFullScreenColor(StikosekGuiUtilities.DrawGui.MakeColorTransparent(Color.black));
                    MovementRect = GUI.Window(0, MovementRect, (GUI.WindowFunction)DrawMovement, "Movement", StikosekGuiUtilities.DrawGui.GetWindowStyle(8,Color.white));
                    ItemsRect = GUI.Window(1, ItemsRect, (GUI.WindowFunction)DrawItems, "Items", StikosekGuiUtilities.DrawGui.GetWindowStyle(8, Color.white));
                    PlayerActRect = GUI.Window(2, PlayerActRect, (GUI.WindowFunction)DrawPlayerAct, "Player actions", StikosekGuiUtilities.DrawGui.GetWindowStyle(8, Color.white));
                    Visuals = GUI.Window(3, Visuals, (GUI.WindowFunction)DrawVisuals, "Visuals", StikosekGuiUtilities.DrawGui.GetWindowStyle(8, Color.white));
                    PlayerRect = GUI.Window(4, PlayerRect, (GUI.WindowFunction)DrawPlayer, "Player", StikosekGuiUtilities.DrawGui.GetWindowStyle(8, Color.white));
                    SettingsRect = GUI.Window(5, SettingsRect, (GUI.WindowFunction)DrawSettings, "Cheat settings", StikosekGuiUtilities.DrawGui.GetWindowStyle(8, Color.white));
                    WaypointRect = GUI.Window(6, WaypointRect, (GUI.WindowFunction)DrawWaypoints, "Waypoints", StikosekGuiUtilities.DrawGui.GetWindowStyle(8, Color.white));
                }
            }
            else
            {
                if (Vars.InGame)
                {
                    GUI.Label(new Rect(Screen.width / 2 - 250 / 2, 40, 250, 20), "to open the hacks, press RightShift", StikosekGuiUtilities.DrawGui.GetSecondTextStyle(14, Vars.textColor));
                }
                else
                {
                    GUI.Label(new Rect(Screen.width / 2 - 250 / 2, 40, 250, 20), "to use the hacks you must be playing.", StikosekGuiUtilities.DrawGui.GetSecondTextStyle(14, Vars.textColor));
                }

            }

            if (Vars.PlayerEsp)
            {
                Vars.AllActiveHacks[6] = true;
                foreach (PlayerManager player in UnityEngine.Object.FindObjectsOfType<PlayerManager>())
                {
                    if (Vars.HighlightPlayer && player.username == Vars.HighlightPlayerName)
                    {

                    }
                    else
                    {
                        //  EspShit.DrawLine(PlayerMovement.Instance.transform.position, player.transform.position, UnityEngine.Color.yellow, 1);
                        float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, player.transform.position);
                        int distanceToint = (int)distance;
                        GUIStyle style = new GUIStyle
                        {
                            alignment = TextAnchor.MiddleCenter
                        };
                        style.normal.textColor = UnityEngine.Color.white;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(player.transform.position);
                        if (w2s.z > 0f)
                        {
                            GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), player.name.Replace("(Clone)", "") + " [" + distanceToint + "m]", style);//Name Esp

                        }


                    }
                }
            }
            else
            {
                Vars.AllActiveHacks[6] = false;
            }

            for (int i = 0; i < Vars.WaypointPos.Count; i++)
            {
                
                
                   //  EspShit.DrawLine(PlayerMovement.Instance.transform.position, player.transform.position, UnityEngine.Color.yellow, 1);
                    float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, Vars.WaypointPos[i]);
                    int distanceToint = (int)distance;
                    GUIStyle style = new GUIStyle
                    {
                        alignment = TextAnchor.MiddleCenter
                    };
                    style.normal.textColor = UnityEngine.Color.white;
                    Vector3 w2s = Camera.main.WorldToScreenPoint(Vars.WaypointPos[i]);
                    if (w2s.z > 0f)
                    {
                        GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), Vars.WaypointName[i] + " [" + distanceToint + "m]", style);//Name Esp

                    }


                
            }

            if (Vars.HighlightPlayer)
            {
                Vars.AllActiveHacks[7] = true;
                foreach (PlayerManager player in UnityEngine.Object.FindObjectsOfType<PlayerManager>())
                {
                    if (player.username == Vars.HighlightPlayerName)
                    {
                        EspShit.DrawLine(PlayerStatus.Instance.transform.position, player.transform.position, UnityEngine.Color.yellow, 1);
                        float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, player.transform.position);
                        int distanceToint = (int)distance;
                        GUIStyle style = new GUIStyle
                        {
                            alignment = TextAnchor.MiddleCenter
                        };
                        style.normal.textColor = UnityEngine.Color.yellow;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(player.transform.position);
                        if (w2s.z > 0f)
                        {
                            //player.name.Replace("(Clone)", "")
                            GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), "Highlighted player" + " [" + distanceToint + "m]", style);//Name Esp

                        }


                    }

                }
            }
            else
            {
                Vars.AllActiveHacks[7] = false;
            }

            if (Vars.PlatformEsp)
            {
                Vars.AllActiveHacks[8] = true;
                foreach (GlassBreak  glassBreak in GlassManager.Instance.pieces)
                {

                    EspShit.DrawLine(PlayerStatus.Instance.transform.position, glassBreak.transform.position, UnityEngine.Color.yellow, 1);
                    float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, glassBreak.transform.position);
                    int distanceToint = (int)distance;
                    GUIStyle style = new GUIStyle
                    {
                        alignment = TextAnchor.MiddleCenter
                    };
                    style.normal.textColor = UnityEngine.Color.yellow;
                    Vector3 w2s = Camera.main.WorldToScreenPoint(glassBreak.transform.position);
                    if (w2s.z > 0f)
                    {
                        //player.name.Replace("(Clone)", "")
                        GUI.Label(new Rect(w2s.x, (float)Screen.height - w2s.y, 0f, 0f), "Breakable glass! " + " [" + distanceToint + "m]", style);//Name Esp

                    }




                }
            }
            else
            {
                Vars.AllActiveHacks[8] = false;
            }



        }

        public void DrawSettings(int windowID)
        {
            StikosekGuiUtilities.DrawGui.DrawWindowBackground(Vars.topcolor, Vars.backcolor, SettingsRect, 15, "Cheat settings");
            //Select text color shit
            GUI.Label(new Rect(5, 20, 100, 20), "Text color:", StikosekGuiUtilities.DrawGui.GetTextStyle(15, Vars.textColor));
            
            if(GUI.Button(new Rect(105, 20, 20, 20), "red", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.textColor = Color.red; Vars.RainbowText = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.red, new Rect(105, 20, 20, 20));
            if (GUI.Button(new Rect(125, 20, 20, 20), "green", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.textColor = Color.green; Vars.RainbowText = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.green, new Rect(125, 20, 20, 20));
            if (GUI.Button(new Rect(145, 20, 20, 20), "blue", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.textColor = Color.cyan; Vars.RainbowText = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.cyan, new Rect(145, 20, 20, 20));
            if (GUI.Button(new Rect(165, 20, 20, 20), "yellow", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.textColor = Color.yellow; Vars.RainbowText = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.yellow, new Rect(165, 20, 20, 20));
            if (GUI.Button(new Rect(185, 20, 20, 20), "rainbow", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.textColor = Vars.currentrainbowcolor; Vars.RainbowText = true; }
            StikosekGuiUtilities.DrawGui.DrawColor(Vars.currentrainbowcolor, new Rect(185, 20, 20, 20));

            //Select top color shit

            GUI.Label(new Rect(5, 45, 100, 20), "Top color:", StikosekGuiUtilities.DrawGui.GetTextStyle(15, Vars.textColor));

            if (GUI.Button(new Rect(105, 45, 20, 20), "red", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.topcolor = Color.red; Vars.RainbowTop = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.red, new Rect(105, 45, 20, 20));
            if (GUI.Button(new Rect(125, 45, 20, 20), "green", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.topcolor= Color.green; Vars.RainbowTop = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.green, new Rect(125, 45, 20, 20));
            if (GUI.Button(new Rect(145, 45, 20, 20), "blue", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.topcolor = Color.cyan; Vars.RainbowTop = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.cyan, new Rect(145, 45, 20, 20));
            if (GUI.Button(new Rect(165, 45, 20, 20), "yellow", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.topcolor = Color.yellow; Vars.RainbowTop = false; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.yellow, new Rect(165, 45, 20, 20));
            if (GUI.Button(new Rect(185, 45, 20, 20), "rainbow", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.topcolor = Vars.currentrainbowcolor; Vars.RainbowTop = true; }
            StikosekGuiUtilities.DrawGui.DrawColor(Vars.currentrainbowcolor, new Rect(185, 45, 20, 20));


            //Select background color shit

            GUI.Label(new Rect(5, 70, 100, 20), "back color:", StikosekGuiUtilities.DrawGui.GetTextStyle(15, Vars.textColor));

            if (GUI.Button(new Rect(105, 70, 20, 20), "black", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.backcolor = Color.black; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.black, new Rect(105, 70, 20, 20));
            if (GUI.Button(new Rect(125, 70, 20, 20), "blue", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.backcolor = Color.blue; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.blue, new Rect(125,  70, 20, 20));
            if (GUI.Button(new Rect(145, 70, 20, 20), "Gray", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.backcolor = Color.gray; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.gray, new Rect(145, 70, 20, 20));
            if (GUI.Button(new Rect(165, 70, 20, 20), "magenta", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.backcolor = Color.magenta;  }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.magenta, new Rect(165, 70, 20, 20));
            if (GUI.Button(new Rect(185, 70, 20, 20), "white", StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor))) { Vars.backcolor = Color.white; }
            StikosekGuiUtilities.DrawGui.DrawColor(Color.white, new Rect(185, 70, 20, 20));



            
            if (Vars.SettingKey == true)
            { 
                Vars.bindtext = "Press key (binding)"; 
            } 
            else 
            {
                Vars.bindtext = "Open key - Current bind: " + Vars.clientkey.ToString(); 
            }

            if (GUI.Button(new Rect(5,95,200,30),Vars.bindtext, StikosekGuiUtilities.DrawGui.GetButtonStyle(12, Vars.textColor))){
                Vars.SettingKey = true;
               
            }
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));

        }

            public void DrawPlayer(int windowID)
        {
            StikosekGuiUtilities.DrawGui.DrawWindowBackground(Vars.topcolor, Vars.backcolor, PlayerRect, 15, "Player");

            Vars.GodMode = GUI.Toggle(new Rect(5, 20, 120, 20), Vars.GodMode, "GodMode [NT]", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            Vars.NoFall = GUI.Toggle(new Rect(5, 40, 120, 20), Vars.NoFall, "NoFall", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            Vars.NoKnockback = GUI.Toggle(new Rect(5, 60, 120, 20), Vars.NoKnockback, "AntiKnockback", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            Vars.OmegaPunch = GUI.Toggle(new Rect(5, 80, 120, 20), Vars.OmegaPunch, "Omega punch", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            Vars.NoPuchCooldown = GUI.Toggle(new Rect(5, 100, 120, 20), Vars.NoPuchCooldown, "Punch cooldown", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            Vars.NoPunchShake = GUI.Toggle(new Rect(5, 120, 120, 20), Vars.NoPunchShake, "Punch shake", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            Vars.NoFreeze = GUI.Toggle(new Rect(5, 140, 120, 20), Vars.NoFreeze, "NoFreeze", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));



            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));

        }
        public void DrawVisuals(int windowID)
        {
            StikosekGuiUtilities.DrawGui.DrawWindowBackground(Vars.topcolor, Vars.backcolor, Visuals, 15, "Visuals");
            Vars.PlayerEsp = GUI.Toggle(new Rect(5, 20, 120, 20), Vars.PlayerEsp, "Player esp", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            Vars.PlatformEsp = GUI.Toggle(new Rect(5, 40, 120, 20), Vars.PlatformEsp, "Platform esp [NT]", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));

        }

        public void DrawPlayerAct(int windowID)
        {
            StikosekGuiUtilities.DrawGui.DrawWindowBackground(Vars.topcolor, Vars.backcolor, PlayerActRect, 15, "Player Actions");

            scrollPosition = GUI.BeginScrollView(new Rect(0, 20, 100, 120), scrollPosition, new Rect(0, 0, 100, 700));
            PlayerManager[] array = UnityEngine.Object.FindObjectsOfType<PlayerManager>();
            for (int i = 0; i < array.Length; i++)
            {

                if (GUI.Button(new Rect(2f, 20 * i, 90f, 20f), array[i].username, StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor)))
                {
                    Vars.UserSelect = i;
                    Vars.HighlightPlayerName = array[i].username;
                }

            }
            GUI.EndScrollView();

            if (GUI.Button(new Rect(110, 20, 60, 45), "Tp me-player", StikosekGuiUtilities.DrawGui.GetButtonStyle(8, Vars.textColor)))
            {
                PlayerMovement.Instance.transform.position = array[Vars.UserSelect].transform.position;

            }
            Vars.HighlightPlayer = GUI.Toggle(new Rect(110, 65, 60, 45), Vars.HighlightPlayer, "Highlight", StikosekGuiUtilities.DrawGui.GetToggleStyle(12, Vars.textColor));

            GUI.Label(new Rect(100, 100, 100, 20), "Sel: " + array[Vars.UserSelect].username, StikosekGuiUtilities.DrawGui.GetTextStyle(12, Vars.textColor));

            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }


        public void DrawWaypoints(int windowID)
        {

           
            StikosekGuiUtilities.DrawGui.DrawWindowBackground(Vars.topcolor, Vars.backcolor, WaypointRect, 15, "Waypoints");

            scrollPosition = GUI.BeginScrollView(new Rect(0, 20, 100, 120), scrollPosition, new Rect(0, 0, 100, 700));
           
            for (int i = 0; i < Vars.WaypointName.Count; i++)
            {

                if (GUI.Button(new Rect(2f, 20 * i, 90f, 20f), Vars.WaypointName[i], StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor)))
                {
                    
                    Vars.SelectedWaypoint = i;
                }

            }
            GUI.EndScrollView();

            if (GUI.Button(new Rect(110, 20, 60, 20), "Create", StikosekGuiUtilities.DrawGui.GetButtonStyle(10, Vars.textColor)))
            {
                Vars.WaypointName.Add("Waypoint "+Vars.SequentialWaypointNumbers);
                Vars.WaypointPos.Add(PlayerMovement.Instance.GetRb().transform.position);
                Vars.SequentialWaypointNumbers += 1;

            }
            if (GUI.Button(new Rect(110, 42, 60, 20), "Teleport", StikosekGuiUtilities.DrawGui.GetButtonStyle(10, Vars.textColor)))
            {
                PlayerMovement.Instance.GetRb().transform.position = Vars.WaypointPos[Vars.SelectedWaypoint];

            }
            if (GUI.Button(new Rect(110, 64, 60, 20), "Remove", StikosekGuiUtilities.DrawGui.GetButtonStyle(10, Vars.textColor)))
            {
                Vars.WaypointName.RemoveAt(Vars.SelectedWaypoint);
                Vars.WaypointPos.RemoveAt(Vars.SelectedWaypoint);

            }


            GUI.Label(new Rect(100, 100, 100, 20), "Sel: " + Vars.WaypointName[Vars.SelectedWaypoint], StikosekGuiUtilities.DrawGui.GetTextStyle(10, Vars.textColor));


            if ("a" == "a" && "a" == "b") { Debug.Log("dhafia"); }
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public void DrawMovement(int windowID)
        {
            StikosekGuiUtilities.DrawGui.DrawWindowBackground(Vars.topcolor, Vars.backcolor, MovementRect,15,"Movement"); 

            if (Vars.InGame)
            {
                Vars.AirJump = GUI.Toggle(new Rect(0, 15, 250, 20), Vars.AirJump, "Air jump", StikosekGuiUtilities.DrawGui.GetToggleStyle(15,Vars.textColor));
                Vars.OmegaJump = GUI.Toggle(new Rect(0, 35, 250, 20), Vars.OmegaJump, "Omega jump", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
                Vars.ClickTp = GUI.Toggle(new Rect(0, 55, 250, 20), Vars.ClickTp, "Click tp", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
                Vars.Speed = GUI.Toggle(new Rect(0, 75, 250, 20), Vars.Speed, "SwimFly", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
                Vars.NoClip = GUI.Toggle(new Rect(0, 95, 250, 20), Vars.NoClip, "Speed", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
                Vars.Hover = GUI.Toggle(new Rect(0, 115, 250, 20), Vars.Hover, "Hover", StikosekGuiUtilities.DrawGui.GetToggleStyle(15, Vars.textColor));
            }
            else
            {
                GUI.Label(new Rect(10, 60, 250, 60), "To access hacks you must be playing.");
            }
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }
        public void DrawItems(int windowID)
        {
            StikosekGuiUtilities.DrawGui.DrawWindowBackground(Vars.topcolor, Vars.backcolor, ItemsRect, 15, "Items");

            Vars.CurId = 0;
            for (int i = 0; i < 6; i++)
            {

                if (GUI.Button(new Rect(5, 30 * i + 20, 110, 30), ItemManager.GetItemById(Vars.CurId).itemName, StikosekGuiUtilities.DrawGui.GetButtonStyle(15, Vars.textColor)))
                {
                    PlayerInventory.Instance.ForceGiveItem(ItemManager.GetItemById(Vars.CurId));
                }
                Vars.CurId++;

            }
            Vars.CurId = 0;
            if ("a" == "a" && "a" == "b") { Debug.Log("dhafia"); }
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }
    }
}

