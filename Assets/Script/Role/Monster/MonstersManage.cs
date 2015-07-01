using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MonstersManage : MonoBehaviour {
    public int Size { get { return _monsters.Count; } }
    List<MonsterAttribute> _monsters = null;
    public MonsterAttribute this[ int index ] {
        get { return this._monsters[index]; }
        private set { this._monsters[index] = value; }
    }

    public int Star{ get; private set; }
    public int MaxHp { get; private set; }
    public int Attack{ get; private set; }
    public int MaxAttack { get; private set; }
    public int AttackSpeed{ get; private set; }
    public int MaxAttackSpeed { get; private set; }
    public int MoveSpeed { get; private set; }
    public int MaxMoveSpeed { get; private set; }

    public void Initial()
    {
        MonsterAttribute[] monsters = GetComponentsInChildren<MonsterAttribute>();
        this._monsters = new List<MonsterAttribute>(monsters);

        foreach (MonsterAttribute monster in monsters)
        {
            int index = monster.name[monster.name.Length - 1] - 48;
            this._monsters[index] = monster;
        }

        if (this._monsters == null || this._monsters.Count == 0)
            Debug.LogError("Monsters not set yet");
    }

    public void SetAttribute() {
        Star = 0;
        MaxHp = 0;
        Attack = 0;
        MaxAttack = 0;
        AttackSpeed = 0;
        MaxAttackSpeed = 0;
        MoveSpeed = 0;
        MaxMoveSpeed = 0;
        foreach (MonsterAttribute monster in _monsters)
        {
            if (monster.ID != 0)
            {
                Star += monster.Star;
                MaxHp += monster.HP;
                MaxAttack += monster.Attack.Max;
                Attack += monster.Attack.Current;
                MaxAttackSpeed += monster.AttackSpeed.Max;
                AttackSpeed += monster.AttackSpeed.Current;
                MaxMoveSpeed += monster.MoveSpeed.Max;
                MoveSpeed += monster.MoveSpeed.Current;
            }
        }

        if (Star > BaseDefine.g_maxStar)
            Debug.LogError("star over range");   
    }
}
