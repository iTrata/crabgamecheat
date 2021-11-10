using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using HarmonyLib;


namespace CrabGameCheat
{
    public class MovementHacks
    {
        public static void SwimFly(bool activate)
        {
           

            if (activate)
            {
                PlayerMovement.Instance.underWater = true;
                PlayerMovement.Instance.swimSpeed = 4666f;
                Vars.AllActiveHacks[4] = true;

            }
            else
            {
                PlayerMovement.Instance.underWater = false;
                Vars.AllActiveHacks[4] = false;

            }
        }

        public static void NoClip(bool activate)
        {
            if (activate)
            {
                Vars.AllActiveHacks[15] = true;
                PlayerMovement.Instance.maxWalkSpeed = PlayerMovement.Instance.maxWalkSpeed * Vars.SpeedMultiplier;
                PlayerMovement.Instance.moveSpeed = PlayerMovement.Instance.moveSpeed * Vars.SpeedMultiplier;
                PlayerMovement.Instance.maxRunSpeed = PlayerMovement.Instance.maxRunSpeed * Vars.SpeedMultiplier;
                PlayerMovement.Instance.maxSpeed = PlayerMovement.Instance.maxSpeed * Vars.SpeedMultiplier;
                PlayerMovement.Instance.maxSlopeAngle = PlayerMovement.Instance.maxSlopeAngle * Vars.SpeedMultiplier;
                PlayerMovement.Instance.slowDownSpeed = PlayerMovement.Instance.slowDownSpeed * Vars.SpeedMultiplier;
            }
            else
            {
                Vars.AllActiveHacks[15] = false;
                PlayerMovement.Instance.maxWalkSpeed = PlayerMovement.Instance.maxWalkSpeed;
                PlayerMovement.Instance.moveSpeed = PlayerMovement.Instance.moveSpeed;
                PlayerMovement.Instance.maxRunSpeed = PlayerMovement.Instance.maxRunSpeed;
                PlayerMovement.Instance.maxSpeed = PlayerMovement.Instance.maxSpeed;
                PlayerMovement.Instance.maxSlopeAngle = PlayerMovement.Instance.maxSlopeAngle;
                PlayerMovement.Instance.slowDownSpeed = PlayerMovement.Instance.slowDownSpeed;
            }
        }

        public static void AirJump(bool activate)
        {
            if (activate)        
            {
                Vars.AllActiveHacks[1] = true;
                if (Input.GetKeyDown("space"))
                {

                    PlayerMovement.Instance.PushPlayer(new Vector3(0, 50f, 0));

                }
            }
            else
            {
                Vars.AllActiveHacks[1] = false;
            }
           
        }

        public static void Hover(bool activate)
        {
            if (activate)
            {
                UnityEngine.Object.FindObjectOfType<PlayerMovement>().GetRb().velocity = new Vector3(0f, 1f, 0f);
                Vars.AllActiveHacks[5] = true;
            }
            else
            {
                Vars.AllActiveHacks[5] = false;
            }

        }

        public static void ClickTp(bool activate)
        {
            if (activate)
            {
                Vars.AllActiveHacks[3] = true;
            }
            else
            {
                Vars.AllActiveHacks[3] = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && activate)
            {

                UnityEngine.Object.FindObjectOfType<PlayerMovement>().GetRb().position = HackUtilities.FindTpPos();



            }
        }

        public static void OmegaJump(bool activate)
        {
            if (activate)
            {
                PlayerMovement.Instance.jumpForce = 1100;
                Vars.AllActiveHacks[2] = true;
            }
            else
            {
                PlayerMovement.Instance.jumpForce = 400;
                Vars.AllActiveHacks[2] = false;
            }
        }

        public static void NoPunchCooldown(bool activate)
        {
            if (activate)
            {
                PlayerMovement.Instance.punchPlayers.ready = true;


            }
            else
            {
                
            }
           
        }

        public static void NoFreeze(bool activate)
        {
            if (activate && Vars.InGame && PersistentPlayerData.frozen)
            {
                PersistentPlayerData.frozen = false;
                Vars.AllActiveHacks[17] = true;

            }
            else
            {
                Vars.AllActiveHacks[17] = false;
            }

        }

        public static void NoPunchShake(bool activate)
        {
            if (activate)
            {
                CurrentSettings.Instance.UpdateCamShake(false);
            }
            else
            {
                CurrentSettings.Instance.UpdateCamShake(true);
            }
        }

            public static void OmegaPunch(bool activate)
        {
            if (activate)
            {
                
                PlayerMovement.Instance.punchPlayers.maxDistance = 5000f;
                
            }
            else
            {
                
                PlayerMovement.Instance.punchPlayers.maxDistance = PlayerMovement.Instance.punchPlayers.maxDistance;
                
            }

        }

    }

    public class HackUtilities
    {
        public static Vector3 FindTpPos()
        {
            Transform playerCam = PlayerMovement.Instance.playerCam;
            RaycastHit raycastHit;
            if (Physics.Raycast(playerCam.position, playerCam.forward, out raycastHit, 5000f))
            {
                Vector3 b = Vector3.zero;
                if (raycastHit.collider.gameObject.layer != null)
                {
                    b = Vector3.one;
                }
                return raycastHit.point + b;
            }
            return Vector3.zero;
        }

        public static void Update()
        {
            if (Input.GetKeyDown(Vars.clientkey))
            {

                Vars.MainToggle = !Vars.MainToggle;
                if (Vars.MainToggle && !Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    return;
                }
                if (!Vars.MainToggle && Cursor.visible)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            if (Vars.SettingKey == true)
            {
                if (Event.current.isKey)
                {
                    Vars.clientkey = Event.current.keyCode;
                    Vars.SettingKey = false;
                }
            }




            MovementHacks.AirJump(Vars.AirJump);

            MovementHacks.OmegaJump(Vars.OmegaJump);
            MovementHacks.ClickTp(Vars.ClickTp);
            MovementHacks.SwimFly(Vars.Speed);
            MovementHacks.NoClip(Vars.NoClip);
            MovementHacks.Hover(Vars.Hover);

            MovementHacks.OmegaPunch(Vars.OmegaPunch);
            MovementHacks.NoPunchCooldown(Vars.NoPuchCooldown);
            MovementHacks.NoPunchShake(Vars.NoPunchShake);
            MovementHacks.NoFreeze(Vars.NoFreeze);

            if (Vars.GodMode == true)
            {
                Vars.AllActiveHacks[9] = true;
            }
            else
            {
                Vars.AllActiveHacks[9] = false;
            }
            if (Vars.NoFall == true)
            {
                Vars.AllActiveHacks[10] = true;
            }
            else
            {
                Vars.AllActiveHacks[10] = false;
            }
            if (Vars.NoKnockback == true)
            {
                Vars.AllActiveHacks[11] = true;
            }
            else
            {
                Vars.AllActiveHacks[11] = false;
            }
            if (Vars.OmegaPunch == true)
            {
                Vars.AllActiveHacks[12] = true;
            }
            else
            {
                Vars.AllActiveHacks[12] = false;
            }
            if (Vars.NoPuchCooldown == true)
            {
                Vars.AllActiveHacks[13] = true;
            }
            else
            {
                Vars.AllActiveHacks[13] = false;
            }
            if (Vars.NoPunchShake == true)
            {
                Vars.AllActiveHacks[14] = true;
            }
            else
            {
                Vars.AllActiveHacks[14] = false;
            }

            Vars.InGame = PlayerMovement.Instance != null;
        }


        public static void StopAnticheat()
        {

            CodeStage.AntiCheat.Detectors.SpeedHackDetector.StopDetection();
            CodeStage.AntiCheat.Detectors.WallHackDetector.StopDetection();
            CodeStage.AntiCheat.Detectors.TimeCheatingDetector.StopDetection();
            CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector.StopDetection();
            CodeStage.AntiCheat.Detectors.SpeedHackDetector.Dispose();
            CodeStage.AntiCheat.Detectors.WallHackDetector.Dispose();
            CodeStage.AntiCheat.Detectors.TimeCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector.Dispose();
        }


    }

    public class EspShit
    {
        public static void DrawLine(Vector3 start, Vector3 end, Color color, int thickness)
        {
            Material LineMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
            LineMaterial.hideFlags = HideFlags.HideAndDontSave;
            LineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
            LineMaterial.SetPass(0);
            if (thickness == 0)
            {
                return;
            }
            if (thickness == 1)
            {
                GL.Begin(1);
                GL.Color(color);
                GL.Vertex3(start.x, start.y, start.z);
                GL.Vertex3(end.x, end.y, end.z);
                GL.End();
                return;
            }
            thickness /= 2;
            GL.Begin(7);
            GL.Color(color);
            GL.Vertex3(start.x - thickness, start.y - thickness, start.z - thickness);
            GL.Vertex3(start.x + thickness, start.y + thickness, start.z + thickness);
            GL.Vertex3(end.x + thickness, end.y + thickness, end.z + thickness);
            GL.Vertex3(end.x - thickness, end.y - thickness, end.z - thickness);
            GL.End();
        }
    }

    [HarmonyPatch]
    public static class Patches
    {
        [HarmonyPatch(typeof(PlayerStatus), "DamagePlayer")]
        [HarmonyPrefix]
        public static bool DamagePlayer(int dmg, Vector3 damageDir, ulong damageDoerId, int itemId)
        {
            if (Vars.NoFall && itemId == -2)
            {
                return false;
            }

            return !Vars.GodMode;
        }

        [HarmonyPatch(typeof(ClientSend), "DamagePlayer")]
        [HarmonyPrefix]
        public static void DamagePlayer(ulong hurtPlayerId, ref int damage, Vector3 damageDir, int itemID, int objectID)
        {
            if(hurtPlayerId == ((ulong)SteamManager.Instance.PlayerSteamId) && Vars.GodMode)
            {
                damage =-100;
                return;
            }
            damage = damage;
            
        }



        [HarmonyPatch(typeof(PlayerMovement),"PushPlayer")]
        [HarmonyPrefix]
        public static bool PushPlayer()
        {
            return !Vars.NoKnockback;
        }

        [HarmonyPatch(typeof(GameManager),"PunchPlayer")]
        [HarmonyPrefix]
        public static bool PunchPlayer(ulong puncher, ulong punched, Vector3 dir)
        {
           

            return !(Vars.NoKnockback);

        }

    }
}
