using UnityEngine;
using System.Collections;

public class ControllerP3 : ControllerBase {
    protected override void Initial()
    {
        Up = KeyCode.Keypad8;
        Down = KeyCode.Keypad2;
        Left = KeyCode.Keypad4;
        Right = KeyCode.Keypad6;
        Fire = KeyCode.KeypadPlus;
        Jump = KeyCode.Keypad5;
        Skill = KeyCode.Keypad9;
    }
}
