using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    PlayerAttirbute _attribute = null;
    public float Speed
    {
        get { return Mathf.Lerp(FightManage.g_moveSpeedMin, FightManage.g_moveSpeedMax, _attribute.MoveSpeed / 100f); }
    }
    Jump _jump = null;

    void Start() {
        _jump = GetComponentInChildren<Jump>();
        if (_jump == null)
            Debug.LogError("Cant find jump");
         
        _attribute = GetComponentInParent<PlayerAttirbute>();
        if (_attribute == null)
            Debug.LogError("Attribute Not Found");
    }

    void Update () {
        WalkControl();
        JumpControl();
	}
    void WalkControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }

        if (transform.position.x >= FightManage.g_width)
            transform.position = new Vector3(FightManage.g_width, transform.position.y, 0);
        else if (transform.position.x <= -FightManage.g_width)
            transform.position = new Vector3(-FightManage.g_width, transform.position.y, 0);
    }
    void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _jump.Begin();
        }
    }
}
