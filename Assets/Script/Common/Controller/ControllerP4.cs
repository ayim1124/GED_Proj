using UnityEngine;
using System.Collections;

public class ControllerP4 : ControllerBase {
    protected override void Initial()
    {
        Up = KeyCode.I;
        Down = KeyCode.Comma;
        Left = KeyCode.J;
        Right = KeyCode.L;
        Fire = KeyCode.O;
        Jump = KeyCode.K;
        Skill = KeyCode.P;
    }
}
