using UnityEngine;
using System.Collections;

public class BulletEffect_ScaleUp : BulletEffectBase
{
    public float MaxScale = 1.5f;
    bool _isScaleUp = true;

    protected override void Effect()
    {
        if( this._isScaleUp )
            transform.localScale *= 1.02f;
        else
            transform.localScale *= 0.9f;

        if (transform.localScale.x >= MaxScale)
        {
            this._isScaleUp = false;
        }
        else if( transform.localScale.x <= 0.05f )
        {
            base.Effect(); // destroy
        }
    }
}
