using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CrabGameCheat.StikosekGuiUtilities
{
    public class DrawGui
    {
        //GIANT THANKS TO JNNJ#2664 FOR LETTING ME USE SOME OF HIS CODE
        // CHECK HIM OUT PLEASE https://github.com/DasJNNJ/ https://discord.gg/xuZwJjpFEN (his discord server)
        //HE IS A REALLY COOL GUY

        public static void DrawColor(Color color, Rect rect)
        {
            Texture2D tex = new Texture2D(1, 1);

            tex.SetPixel(1, 1, color);

            tex.wrapMode = TextureWrapMode.Repeat;
            tex.Apply();

            GUI.DrawTexture(rect, tex);
        }

        public static void DrawText(string text, Rect pos, int fontSize, Color textColor)
        {
            GUIStyle style = GetTextStyle(fontSize, textColor);

            GUI.Label(pos, text, style);
        }

        public static GUIStyle GetTextStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,
                alignment = TextAnchor.MiddleLeft,
            };

            style.normal.textColor = textColor;

            return style;
        }

        public static GUIStyle GetSecondTextStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,
                alignment = TextAnchor.MiddleCenter,
            };

            style.normal.textColor = textColor;

            return style;
        }


        public static GUIStyle GetHackTextStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,
                alignment = TextAnchor.MiddleLeft,
            };

            style.normal.textColor = textColor;

            return style;
        }

        public static GUIStyle GetToggleStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.toggle)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,

            };

            style.normal.textColor = textColor;

            return style;
        }

        public static GUIStyle GetButtonStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.button)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,
                alignment = TextAnchor.MiddleCenter,

            };

            style.normal.textColor = textColor;



            return style;
        }

        public static GUIStyle GetWindowStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.window)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,




            };

            style.normal.textColor = textColor;


            return style;
        }

        private static Rect CalcTextSize(float x, float y, GUIStyle style, string text)
        {
            Vector2 size = style.CalcSize(new GUIContent(text));
            float textWidth = size.x * 2;
            float textHeight = size.y * 2;

            return new Rect(x, y, textWidth, textHeight);
        }

        public static void DrawWindowBackground(Color top, Color rest, Rect rect, int TopBarThickness, string Title)
        {


            //Draw main background
            DrawGui.DrawColor(rest, new Rect(0, TopBarThickness, rect.width, rect.height - TopBarThickness));

            //Draw top bar
            DrawGui.DrawColor(top, new Rect(0, 0, rect.width, TopBarThickness));

            DrawGui.DrawText(Title, new Rect(0, 0, rect.width, TopBarThickness), TopBarThickness - 3, Color.black);


        }

        public static Color MakeColorTransparent(Color color)
        {
            color.a = 0.3f;
            return color;
        }

        public static void DrawFullScreenColor(Color color)
        {
            Texture2D tex = new Texture2D(1, 1);

            tex.SetPixel(1, 1, color);

            GUI.Box(new Rect(0, 0, Screen.width + 100, Screen.height + 100), tex);
        }




    }
    //usage
    // // .25f is the speed

    //Getting the color
    //
    public class RainbowColor
    {
        private Color color;

        public float Speed;

        public RainbowColor(float speed = 0.25f)
        {
            Speed = speed;
            color = Color.HSVToRGB(.34f, .84f, .67f);
        }

        public Color GetColor()
        {
            Color.RGBToHSV(color, out float h, out float s, out float v);
            return color = Color.HSVToRGB(h + Time.deltaTime * Speed, s, v);
        }

    }
}
