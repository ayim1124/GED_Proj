using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class IconManage : MonoBehaviour {
    public Sprite[] SetNumber = null;
    public static List<Sprite> Number = null;

    void Awake() {
        Number = new List<Sprite>( SetNumber );
    }
}
