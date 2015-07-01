using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SelectManage : MonoBehaviour {
    List<SelectMonsterControl> _players = null;
    int _playerNum = 0;

    void Awake() {
        this._playerNum = Mathf.Clamp( PassData.PlayerAmount, 2, 4);
    }

    void Start() {
        SelectMonsterControl[] players = GetComponentsInChildren<SelectMonsterControl>();
        this._players = new List<SelectMonsterControl>(players);
        foreach (SelectMonsterControl player in players)
        {
            int index = player.name[player.name.Length - 1] - 49;
            this._players[index] = player ;
        }
        ErrorLog.CheckComponentExist(this._players, "MonsterControl", this.name);

        for (int i = 0; i < this._players.Count; i++) {
            this._players[i].Initial();
            if (i >= this._playerNum )
                this._players[i].Work = false;
        }
    }

    void Update() {
        if (IsAllReady())
            Application.LoadLevel(2);
    }

    bool IsAllReady() {
        for (int i = 0; i < this._playerNum; i++)
        {
            if (this._players[i].Ready == false)
            {
                return false; 
            }
        }
        return true;
    }
}
