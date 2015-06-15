using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
    BulletManage _bullet = null; // 也許該用委託?

    void Update()
    {
        _bullet = GetComponentInParent<BulletManage>();
        if (_bullet == null)
            Debug.LogError("not find bullet");

        
        _bullet.transform.Translate(_bullet.Speed * Time.deltaTime, 0, 0);
        if (_bullet.transform.localPosition.y <= FightManage.g_minHeight - 1)
        {
            Destroy(_bullet.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        _bullet.Effect();
        Destroy(gameObject);
    }
}
