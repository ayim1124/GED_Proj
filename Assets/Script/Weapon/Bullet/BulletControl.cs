using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
    BulletManage _bullet = null; // 也許該用委託?

    void Start() {
        this._bullet = GetComponentInParent<BulletManage>();
        ErrorLog.CheckComponentExist(this._bullet, "BulletManage", this.name);

        Initial();
    }
    protected virtual void Initial(){;}

    void Update()
    {
        _bullet.transform.Translate(_bullet.Speed * Time.deltaTime, 0, 0);
        if (_bullet.transform.localPosition.y <= BaseDefine.g_minHeight - 1 
            || _bullet.transform.localPosition.x >= BaseDefine.g_width + 1
            || _bullet.transform.localPosition.x <= -BaseDefine.g_width - 1)
        {
            Destroy(_bullet.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        Active();
    }
    protected virtual void Active() {
        _bullet.Effect();
        Destroy(gameObject);
    } 
}
