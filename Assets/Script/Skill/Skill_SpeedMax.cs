using UnityEngine;
using System.Collections;

public class Skill_SpeedMax : SkillBase {
    int _maxUp = 50;
    int _extra = 100;

    protected override void Initial()
    {
        this._cooldown = 15;
        this._durationTime = 3f;
    }

    public override void Cast()
    {
        this._attribute.MoveSpeed.Max += this._maxUp;
        this._attribute.MoveSpeed.Extra += this._extra;
    }

    protected override void ResetSkillEffect()
    {
        this._attribute.MoveSpeed.Max -= this._maxUp;
        this._attribute.MoveSpeed.Extra -= this._extra;
    }
	
}
