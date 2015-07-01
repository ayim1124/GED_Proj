using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill_FlashToTarget : SkillBase {
    CircleCollider2D _collider = null;
    List<GameObject> _targets = null;
    
    protected override void Initial()
    {
        this._targets = new List<GameObject>();
        this._specailLock = true;
        this._collider = gameObject.AddComponent<CircleCollider2D>();
        this._collider.radius = 1.8f;
        this._collider.isTrigger = true;
        this.gameObject.layer = 10;
        this._cooldown = 15;
        this._durationTime = 0;
    }

    public override void Cast()
    {
        this._attribute.transform.position = this._targets[0].transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this._targets.Add(other.gameObject);
        this._specailLock = false;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        this._targets.Remove(other.gameObject);
        if( this._targets.Count == 0 )
            this._specailLock = true; 
    }
}
