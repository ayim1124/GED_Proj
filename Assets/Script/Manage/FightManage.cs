using UnityEngine;
using System.Collections;

public sealed class FightManage : MonoBehaviour {

    //public static float g_Gravity{ get; set; }
    public const float g_minHeight = -4f;
    public const float g_width = 6.5f;

    public const float g_moveSpeedMax = 2.3f;
    public const float g_moveSpeedMin = 0.3f;
    public const float g_attackSpeedConvertPercent = 0.005f;

    void Awake() {
        //g_Gravity = 0.03f;
    }

	// Use this for initialization
    void Start()
    {

    }
}
