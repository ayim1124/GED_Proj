using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class PlayerGenerator : MonoBehaviour {
    public GameObject PerfabPlayer;
    static GameObject _perfabs;
    public PlayersManage PlayerCollect;
    static PlayersManage _playerCollect;

	// Use this for initialization
	void Awake () {
        ErrorLog.CheckComponentExist(PerfabPlayer, "PerfabPlayer");
        _perfabs = PerfabPlayer;
        ErrorLog.CheckComponentExist(PlayerCollect, "PlayersManage");
        _playerCollect = PlayerCollect;
	}

    public static void Create(PlayerIndex index, Vector3 pos, Sprite image) {
        GameObject obj = Instantiate(_perfabs) as GameObject;
        obj.transform.parent = _playerCollect.transform;
        obj.transform.localPosition = pos;
        obj.name = "player"+(int)index;
        RoleControl control = obj.GetComponent<RoleControl>();
        control.Player = index;
        control.enabled = false;
        SpriteRenderer icon = obj.GetComponent<SpriteRenderer>();
        icon.sprite = image;
        PlayerAttirbute attribute = obj.GetComponent<PlayerAttirbute>();
        List<int> data = PlayerIndexSelect.SaveData(index);

        MonstersManage monsters = obj.GetComponentInChildren<MonstersManage>();
        monsters.Initial();
        
        for (int i = 0; i < monsters.Size; i++) {
            monsters[i].ID = data[i];
            monsters[i].Initial();
        }

        monsters.SetAttribute();
        attribute.Initial();
        

        control.enabled = true;
    }
}
