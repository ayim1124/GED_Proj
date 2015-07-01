// 此class務必與角色控制放在同一個物件

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    PlayerAttirbute _attribute = null;
    public float Speed
    {
        get { return BaseDefine.g_moveSpeedMax*this._attribute.MoveSpeed.Current / 100f + BaseDefine.g_moveSpeedMin*(1-this._attribute.MoveSpeed.Current / 100f); }
    }
    Jump _jump = null;

    void Start() {
        _jump = GetComponentInChildren<Jump>();
        ErrorLog.CheckComponentExist(this._jump, "Jump", this.name);
         
        _attribute = GetComponentInParent<PlayerAttirbute>();
        ErrorLog.CheckComponentExist(this._attribute, "Attribute", this.name);
    }

    void Update () {
        if (transform.position.x >= BaseDefine.g_width)
            transform.position = new Vector3(BaseDefine.g_width, transform.position.y, 0);
        else if (transform.position.x <= -BaseDefine.g_width)
            transform.position = new Vector3(-BaseDefine.g_width, transform.position.y, 0);
	}

    public void Left() {
        transform.Translate(Vector3.left * Time.deltaTime * Speed);
    }

    public void Right() {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }

    public void Begin() {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }

    public void Jump()
    {
        _jump.Begin();
    }
}
