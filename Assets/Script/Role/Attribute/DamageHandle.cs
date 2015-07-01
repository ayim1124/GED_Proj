// 需與HpManage放在同個物件

using UnityEngine;
using System.Collections;

public class DamageHandle : MonoBehaviour {
    HpManage _hp = null;
    int _ignorePercent;
    public int IgnorePercent {
        get { return this._ignorePercent; }
        set { this._ignorePercent = value; }
    } // 暫時用來替代無敵 以後要避免重複使用的情況

    void Start() {
        this._hp = GetComponent<HpManage>();
        ErrorLog.CheckComponentExist(this._hp, "HpManage", this.name);
        IgnorePercent = 0;
    }

    public void ApplyDamage( int damage = 0 ) {
        this._hp.Current -= Mathf.FloorToInt(damage * Mathf.Clamp01(1f - this._ignorePercent * 0.01f));
    }
}
