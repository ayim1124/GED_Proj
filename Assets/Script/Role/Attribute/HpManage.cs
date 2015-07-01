// 有血量的角色請把此腳本加入同物件上
// 若要有損血的功能請加入DamageHandle

using UnityEngine;
using System.Collections;

public class HpManage : MonoBehaviour {
    MaxAndCurrent _hp = new MaxAndCurrent();
    public int Current
    {
        get { return this._hp.Current; }
        set {
            this._hp.Origin = value;
            UpdateDisplay();

            if (Current == 0)
                DeadHandle();
        }
    }

   // public bool Visible;
    Number _display = null;

    void Awake() {
        this._display = GetComponentInChildren<Number>();
        this._display.Initial();
    }

    public void Initial( int maxHp ) {
        this._hp.initial(maxHp);
        UpdateDisplay();
    }

    protected virtual void DeadHandle() {
        PlayersManage.DeadHandle(gameObject);
        Destroy(this.gameObject);
    }

    void UpdateDisplay() {
        if (_display != null)
            this._display.Num = Current;
    }
}
