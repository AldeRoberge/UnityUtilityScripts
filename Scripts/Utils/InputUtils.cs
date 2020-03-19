using System.Collections.Generic;
using UnityEngine;

namespace PlayerInput
{
    public enum InputType
    {
        X,
        Y,
        A,
        B,
        Start,
        Back,
        Start2,
        Back2,
        DPadUp,
        DPadRight,
        DPadDown,
        DPadLeft,
        DPad,
        Heart,
        LeftButton,
        RightButton,
        LeftTrigger,
        RightTrigger,
        LeftJoystick,
        RightJoystick
    }

    


    public class InputUtils
    {
        public static InputToSprite X = new InputToSprite(InputType.X, "X", "<sprite=0>");
        public static InputToSprite Y = new InputToSprite(InputType.Y, "Y", "<sprite=1>");
        public static InputToSprite A = new InputToSprite(InputType.A, "A", "<sprite=2>");
        public static InputToSprite B = new InputToSprite(InputType.B, "B", "<sprite=3>");
        public static InputToSprite Start = new InputToSprite(InputType.Start, "Start", "<sprite=4>");
        public static InputToSprite Back = new InputToSprite(InputType.Back, "Back", "<sprite=5>");
        public static InputToSprite Start2 = new InputToSprite(InputType.Start2, "Start", "<sprite=6>");
        public static InputToSprite Back2 = new InputToSprite(InputType.Back2, "Back", "<sprite=7>");
        public static InputToSprite DPadUp = new InputToSprite(InputType.DPadUp, "DPad Haut", "<sprite=8>");
        public static InputToSprite DPadRight = new InputToSprite(InputType.DPadRight, "DPad Droit", "<sprite=9>");
        public static InputToSprite DPadDown = new InputToSprite(InputType.DPadDown, "DPad Bas", "<sprite=10>");
        public static InputToSprite DPadLeft = new InputToSprite(InputType.DPadLeft, "DPad Gauche", "<sprite=11>");
        public static InputToSprite DPad = new InputToSprite(InputType.DPad, "DPad", "<sprite=12>");
        public static InputToSprite Heart = new InputToSprite(InputType.Heart, "Coeur", "<sprite=13>");

        public static InputToSprite LeftButton =
            new InputToSprite(InputType.LeftButton, "Boutton de gauche", "<sprite=14>");

        public static InputToSprite RightButton =
            new InputToSprite(InputType.RightButton, "Boutton de droit", "<sprite=15>");

        public static InputToSprite LeftTrigger =
            new InputToSprite(InputType.LeftTrigger, "Gachette gauche", "<sprite=16>");

        public static InputToSprite RightTrigger =
            new InputToSprite(InputType.RightTrigger, "Gachette droit", "<sprite=17>");

        public static InputToSprite LeftJoystick =
            new InputToSprite(InputType.LeftJoystick, "Joystick droit", "<sprite=18>");

        public static InputToSprite RightJoystick =
            new InputToSprite(InputType.RightJoystick, "Joystick droit", "<sprite=19>");

        public static List<InputToSprite> All = new List<InputToSprite>()
        {
            X, Y, A, B, Start, Back, Start2, Back2, DPadUp, DPadRight, DPadDown, DPadLeft, DPad, Heart, LeftButton,
            RightButton, LeftTrigger, RightTrigger, LeftJoystick, RightJoystick
        };


        public static InputToSprite FromInputType(InputType inputType)
        {
            foreach (InputToSprite inputToSprite in All)
            {
                if (inputToSprite.InputType == inputType)
                {
                    return inputToSprite;
                }
            }

            Debug.LogError("Could not find InputToSprite for InputType : '" + inputType + "'.");
            return null;
        }
    }

    public class InputToSprite
    {
        public InputType InputType;
        public string name;
        public string sprite;

        public InputToSprite(InputType input, string name, string sprite)
        {
            InputType = input;
            this.name = name;
            this.sprite = sprite;
        }
    }
}