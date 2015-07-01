using UnityEngine;
using System.Collections;

public class ControllerP2 : ControllerBase {
    protected override void Initial()
    {
        Up = KeyCode.W;
        Down = KeyCode.X;
        Left = KeyCode.A;
        Right = KeyCode.D;
        Fire = KeyCode.E;
        Jump = KeyCode.S;
        Skill = KeyCode.R;
    }
}
