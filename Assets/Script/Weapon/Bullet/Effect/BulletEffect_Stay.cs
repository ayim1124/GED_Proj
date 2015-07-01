using UnityEngine;
using System.Collections;

public class BulletEffect_Stay : BulletEffectBase
{
    public float StayTime = 3f;
    float _resetTime = 0.5f;
    
    protected override void Effect()
    {
        Invoke("InvokeEffect", StayTime);
        this._isWork = false;
    }
    void InvokeEffect(){
        base.Effect();
    }

    public override void Begin(int damage)
    {
        InvokeRepeating("ResetCollider", 0f, this._resetTime);
        base.Begin(damage);
    }

    void ResetCollider() {
        collider2D.enabled = false;
        collider2D.enabled = true;
    }
}
