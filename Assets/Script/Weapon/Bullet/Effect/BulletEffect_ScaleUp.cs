using UnityEngine;
using System.Collections;

public class BulletEffect_ScaleUp : BulletEffectBase
{
    protected override void Effect()
    {
        transform.localScale *= 1.1f;
        if (transform.localScale.x >= 2)
            base.Effect(); // destroy
    }
}
