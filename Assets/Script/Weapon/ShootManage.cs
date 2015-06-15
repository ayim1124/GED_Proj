using UnityEngine;
using System.Collections;

public class ShootManage : MonoBehaviour {
    float _speedBase;
    public float Speed{
        get { return Mathf.Lerp(_speedBase, 0, FightManage.g_attackSpeedConvertPercent * _attribute.AttackSpeed); }
    }
    public GameObject Bullet = null;
    SpriteRenderer _icon;
    ShootForceControl _forceControl = null;

    float _reShootTime = 0f; // 子彈冷卻時間
    bool _canShoot = true; 
    bool CanShoor{ 
        get{ return _canShoot; }
    }

    PlayerAttirbute _attribute = null;

    void Start() {
        _icon = GetComponentInChildren<SpriteRenderer>();
        _forceControl = GetComponent<ShootForceControl>();
        if (Bullet == null)
            Debug.LogError("Bullet Not Found");
        _attribute = GetComponentInParent<PlayerAttirbute>();
        if (_attribute == null)
            Debug.LogError("Attribute Not Found");
        _speedBase = Bullet.GetComponent<BulletManage>().IntervalTime;
    }
    
    void Update()
    {
        if (_canShoot == false) 
        {
            _reShootTime -= Time.deltaTime;
            if (_reShootTime <= 0)
                _canShoot = true;
        }
    }

    public void SetBullet(GameObject bullet) {
        Bullet = bullet;
        _speedBase = Bullet.GetComponent<BulletManage>().IntervalTime;
    }

    public void Fire()
    {
        if (_forceControl.Enable)
        {
            _forceControl.Enable = false;
            FireBullet();
            _canShoot = false;
            _reShootTime = Speed;
        }
    }
    void FireBullet()
    {
        GameObject bullet = Instantiate(Bullet, _icon.transform.position, transform.rotation) as GameObject;
        if (bullet.tag == "Untagged")
            bullet.tag = "Bullet";
        BulletManage bulletCtrl = bullet.GetComponent<BulletManage>();
        bulletCtrl.Speed *= (1 + _forceControl.Force * 0.02f);
        bulletCtrl.Attack = Mathf.CeilToInt(bulletCtrl.Attack * (1 + _attribute.Attack * 0.01f));
        PlaySound();
    }
    protected virtual void PlaySound() { ;}

    public void RunForce() {
        if (_canShoot)
        {
            _forceControl.Enable = true;
        }
    }

}
