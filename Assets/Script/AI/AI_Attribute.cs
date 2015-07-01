using UnityEngine;
using System.Collections;

public class AI_Attribute : MonoBehaviour {

    public int DebugHp = 3000;
    HpManage _hp = null;

	// Use this for initialization
	void Start () {
        this._hp = GetComponent<HpManage>();
        this._hp.Initial(DebugHp);
	}
}
