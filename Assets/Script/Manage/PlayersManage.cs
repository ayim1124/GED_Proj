using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayersManage : MonoBehaviour {
    static List<PlayerAttirbute> _players = null;
    public static int PlayerAmount { get; set; }
    public Text TextWinner;
    static bool _isFinish = false;

    void Update() {
        if (_isFinish) {
            Victory();
            _isFinish = false;
        }
    }

    public void Initial() {
        _players = new List<PlayerAttirbute>(GetComponentsInChildren<PlayerAttirbute>());
        PlayerAmount = PassData.PlayerAmount;
        if (PlayerAmount != _players.Count)
            Debug.Log("PlayerAmount Error");
    }

    public static void DeadHandle( GameObject sender ) {
        PlayerAttirbute attribute = sender.GetComponent<PlayerAttirbute>();
        if (attribute != null) {
            _players.Remove(attribute);
            PlayerAmount--;
        }
        if (PlayerAmount == 1)
            _isFinish = true;
    }

    void Victory()
    {
        _players[0].gameObject.GetComponent<DamageHandle>().IgnorePercent = 100;
        RoleControl control = _players[0].gameObject.GetComponent<RoleControl>();
        control.enabled = false;
        TextWinner.text = control.Player.ToString() + " Winner";
        TextWinner.enabled = true;
        Invoke("LoadMenu", 3f);
    }

    void LoadMenu() {
        SoundManage.Instance.Fight.Stop();
        Application.LoadLevel(0);
    }
}
