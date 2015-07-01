// 增加敵人後 需要把playerAttribute繼承原始的UnitAttribute

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttirbute : MonoBehaviour {
    MonstersManage _monsters = null;
    //int _star = 0;
    HpManage _hp = null;
    public MaxAndCurrent Attack = null;
    public MaxAndCurrent AttackSpeed = new MaxAndCurrent();
    public MaxAndCurrent MoveSpeed = new MaxAndCurrent();
    List< GameObject > _bullets = null; // Get寫成function for ReadOnly
    public GameObject GetBullet(int index) {
        if (index < 0)
            index += this._bullets.Count;
        return this._bullets[index % this._bullets.Count];
    }
    List<SkillBase> _skill = null;
    public SkillBase GetSkill(int index) {
        return this._skill[index];
    }

    public void Initial()
    {
        this._hp = GetComponent<HpManage>();
        ErrorLog.CheckComponentExist(this._hp, "HpManage", this.name);

        this._monsters = GetComponentInChildren<MonstersManage>();
        ErrorLog.CheckComponentExist(this._monsters, "MonstersManage", this.name);

        this._bullets = new List<GameObject>();
        this._skill = new List<SkillBase>();

        SetAttribute();
    }

    void SetAttribute() {
        this._hp.Initial(this._monsters.MaxHp);
        this.Attack = new MaxAndCurrent(_monsters.MaxAttack, _monsters.Attack);
        this.AttackSpeed = new MaxAndCurrent(_monsters.MaxAttackSpeed, _monsters.AttackSpeed);
        this.MoveSpeed = new MaxAndCurrent(_monsters.MaxMoveSpeed, _monsters.MoveSpeed);
        for (int i = 0; i < this._monsters.Size; i++)
        {
            if (this._monsters[i].ID != 0)
            {
                if (ErrorLog.CheckComponentExist(this._monsters[i].Bullet, "Bullet"))
                    this._bullets.Add(this._monsters[i].Bullet);

                _skill.Add(this._monsters[i].GetComponent<SkillBase>());
            }
        }
    }

    public void HealHp(int value = 0) {
        this._hp.Current += value;
    }
}
