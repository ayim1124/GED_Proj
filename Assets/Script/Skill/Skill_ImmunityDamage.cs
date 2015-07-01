using UnityEngine;
using System.Collections;

public class Skill_ImmunityDamage : SkillBase {
    DamageHandle _damageHandle = null;

    protected override void Initial()
    {
        this._damageHandle = GetComponentInParent<DamageHandle>();
        ErrorLog.CheckComponentExist(this._damageHandle, "DamageHandle", this.name);

        this._cooldown = 25;
        this._durationTime = 3;
    }

    public override void Cast()
    {
        SpriteRenderer icon = this._attribute.GetComponent<SpriteRenderer>();
        icon.color = Color.yellow;
        this._damageHandle.IgnorePercent += 100;
    }

    protected override void ResetSkillEffect()
    {
        SpriteRenderer icon = this._attribute.GetComponent<SpriteRenderer>();
        icon.color = Color.white;
        this._damageHandle.IgnorePercent -= 100;
    }
}
