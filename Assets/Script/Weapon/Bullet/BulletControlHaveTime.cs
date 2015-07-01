using UnityEngine;
using System.Collections;

public class BulletControlHaveTime : BulletControl {
    public float LimitTime = 3f;
    
    protected override void Initial()
    {
        Invoke("Active", LimitTime);
    }

    protected override void Active()
    {
        base.Active();
        CancelInvoke();
    }
}
