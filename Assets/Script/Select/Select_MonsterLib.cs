using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Select_MonsterLib : MonoBehaviour {
    List<Select_MonsterUnit> _monsters = null;
    public Select_MonsterUnit this[int index]
    {
        get { return this._monsters[index]; }
        private set { this._monsters[index] = value; }
    }
    public int Count { get { return this._monsters.Count; } }

    void Awake() {
        Select_MonsterUnit[] monsters = GetComponentsInChildren<Select_MonsterUnit>();
        this._monsters = new List<Select_MonsterUnit>(monsters);
        foreach (Select_MonsterUnit monster in monsters)
        {
            int index = monster.name[monster.name.Length - 1] - 48;
            this._monsters[index] = monster;
        }
        ErrorLog.CheckComponentExist(this._monsters, "Monsters", this.name);
    }
}
