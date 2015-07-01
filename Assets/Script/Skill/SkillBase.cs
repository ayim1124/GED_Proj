using UnityEngine;
using System.Collections;

public abstract class SkillBase : MonoBehaviour {
    bool _canUse = true;
    protected bool _specailLock = false;
    float _reCastTime = 0;
    protected float _cooldown = 0;
    protected float _durationTime = 0;
    protected PlayerAttirbute _attribute = null;

	// Use this for initialization
	void Start () {
        this._attribute = GetComponentInParent<PlayerAttirbute>();
        ErrorLog.CheckComponentExist( this._attribute, "PlayerAttribte", this.name);
        Initial();
	}

    void Update() {
        if (this._canUse == false) {
            this._reCastTime -= Time.deltaTime;
            if (this._reCastTime <= 0)
                this._canUse = true;
        }
    }

    /// <summary>
    /// set Cooldown, DurationTime
    /// </summary>
    protected abstract void Initial();

    public virtual void UseSkill() {
        if (this._canUse && this._specailLock == false )
        {
            this._canUse = false;
            this._reCastTime = this._cooldown;
            Cast();
            if( this._durationTime > 0 )
                Invoke("ResetSkillEffect", this._durationTime);
        }
    }
    public abstract void Cast();

    protected virtual void ResetSkillEffect() {;}
}
