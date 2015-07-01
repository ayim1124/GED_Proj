/**
 * 架構不太好 還要再修
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerIndex{ P1, P2, P3, P4 };

public class SelectMonsterControl : MonoBehaviour {
    public PlayerIndex Player;
    List<Select_MonsterUnit> _monsters = null;
    public GameObject Border;
    public Select_MonsterLib Lib;
    public static PassData Data;
    ControllerBase _controller = null;
    int _index = 0;
    int _monstersIndex = 0;
    int _star = 0;
    bool _work = true;
    public bool Work { 
        set {
            this._work = value; 
            gameObject.SetActive(this._work); 
        } 
    }
    public bool Ready { get; private set; }
    List<int> saveData = null;

	// Use this for initialization
	void Start () {
        this._controller = ControllerFactory.create(Player);
        ErrorLog.CheckComponentExist(this._controller, "Controller", this.name);
        saveData = PlayerIndexSelect.SaveData(Player);
	}

    public void Initial() {
        Ready = false;
        Select_MonsterUnit[] monsters = GetComponentsInChildren<Select_MonsterUnit>();
        this._monsters = new List<Select_MonsterUnit>(monsters);
        foreach (Select_MonsterUnit monster in monsters)
        {
            int index = monster.name[monster.name.Length - 1] - 48;
            this._monsters[index] = monster;
        }
        ErrorLog.CheckComponentExist(this._monsters, "Monsters", this.name);
    }

    void Update() {
        if (this._work && Ready==false)
        {
            if (Input.GetKeyDown(this._controller.Left))
            {
                NextIndex(false);
            }
            else if (Input.GetKeyDown(this._controller.Right))
            {
                NextIndex(true);
            }
            else if (Input.GetKeyUp(this._controller.Jump))
            {
                Select();
            }
            else if (Input.GetKeyUp(this._controller.Fire)) 
            {
                Cancel();
            }
            else if (Input.GetKeyUp(this._controller.Skill))
            {
                if (this._monstersIndex > 0)
                {
                    ReadyDeal();
                }
            }
        }
    }

    void NextIndex( bool next ) {
        if (next)
            this._index++;
        else
            this._index--;
        if (this._index < 0)
            this._index += Lib.Count;
        this._index %= Lib.Count;
        Border.transform.position = Lib[this._index].transform.position;
    }

    void Select() {
        Select_MonsterUnit unit = Lib[ this._index ];
        if ((this._star + unit.Star) <= BaseDefine.g_maxStar && this._monstersIndex < this._monsters.Count) {
            this._monsters[this._monstersIndex].SetUnit(unit.Icon, unit.ID, unit.Star);
            this._monstersIndex++;
            this._star += unit.Star;
        }
    }

    void Cancel() {
        if (this._monstersIndex > 0) {
            this._star -= this._monsters[this._monstersIndex-1].Star;
            this._monsters[this._monstersIndex-1].ResetUnit();
            this._monstersIndex--;
        }
    }

    void ReadyDeal() {
        for (int i = 0; i < this._monsters.Count; i++) {
            this.saveData[i] = this._monsters[i].ID;
            this._monsters[i].ReadyDeal();
        }

        Ready = true;
    }
}
