using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttirbute : MonoBehaviour {
    List<MonsterAttribute> _monsters = null;
    int _star = 0;
    MaxAndCurrent _hp = new MaxAndCurrent();
    public int Hp { 
        get { return _hp.Current; }
        //set { _hp.Current = value; }
    }
    MaxAndCurrent _attack = new MaxAndCurrent();
    public int Attack { 
        get { return _attack.Current; }
        set { _attack.Current = value; }
    }
    MaxAndCurrent _attackSpeed = new MaxAndCurrent();
    public int AttackSpeed { 
        get { return _attackSpeed.Current; }
        set { _attackSpeed.Current = value; }
    }
    MaxAndCurrent _moveSpeed = new MaxAndCurrent();
    public int MoveSpeed { 
        get { return _moveSpeed.Current; }
        set { _moveSpeed.Current = value; }
    }
    // current buttle;

	// Use this for initialization
	void Start () {
        MonsterAttribute[] monsters = GetComponentsInChildren<MonsterAttribute>();
        _monsters = new List<MonsterAttribute>(monsters);
       
        Initial();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initial() {
        _star = 0;
        int hp = 0;
        int atkMax = 0;
        int atkCur = 0;
        int mvMax = 0;
        int mvCur = 0;
        int asMax = 0;
        int asCur = 0;
        foreach (MonsterAttribute monster in _monsters)
        {
            _star += monster.Star;
            hp += monster.HP;
            atkMax += monster.Attack.Max;
            atkCur += monster.Attack.Current;
            mvMax += monster.MoveSpeed.Max;
            mvCur += monster.MoveSpeed.Current;
            asMax += monster.AttackSpeed.Max;
            asCur += monster.AttackSpeed.Current;
        }
        if (_star > 5)
            Debug.LogError("star over range");
        _hp.initial(hp);
        _attack.initial(atkMax, atkCur);
        _attackSpeed.initial(asMax, asCur);
        _moveSpeed.initial(mvMax, mvCur);
    }

    void ApplyDamage(int damage = 0)
    {
        _hp.Current -= damage;
    }
}
