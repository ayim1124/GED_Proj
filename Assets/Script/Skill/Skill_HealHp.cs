using UnityEngine;
using System.Collections;

public class Skill_HealHp : SkillBase {
    public int HealValue = 500;
    
    protected override void Initial()
    {
        this._cooldown = 15;
        this._durationTime = 0f;
    }

    public override void Cast()
    {
        this._attribute.HealHp(HealValue);
    }
}
