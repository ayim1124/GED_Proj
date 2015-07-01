using UnityEngine;
using System.Collections;

public class ControllerP1 : ControllerBase {
    protected override void Initial()
    {
        Up = KeyCode.UpArrow;
        Down = KeyCode.DownArrow;
        Left = KeyCode.LeftArrow;
        Right = KeyCode.RightArrow;
        Fire = KeyCode.RightShift;
        Jump = KeyCode.Return;
        Skill = KeyCode.Slash;
    }
}
