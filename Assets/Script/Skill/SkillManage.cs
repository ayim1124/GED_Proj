// 在需要的obj底下增加新物件置放
using UnityEngine;
using System.Collections;

public class SkillManage : MonoBehaviour {
    PlayerAttirbute _attribute = null;

	// Use this for initialization
	void Start () {
        this._attribute = GetComponentInParent<PlayerAttirbute>();
        ErrorLog.CheckComponentExist(this._attribute, "PlayerAttribte", this.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UseSKill( int index ) {
        SkillBase skill = this._attribute.GetSkill(index);
        if (skill != null)
            skill.UseSkill();
    }
}
