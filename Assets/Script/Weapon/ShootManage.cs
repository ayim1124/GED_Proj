using UnityEngine;
using System.Collections;

public class ShootManage : MonoBehaviour {
    float _speedBase; // 原始冷卻時間
    public float Speed{ // 實際冷卻時間
        get { return Mathf.Lerp(_speedBase, 0, BaseDefine.g_attackSpeedConvertPercent * this._attribute.AttackSpeed.Current); }
    }
    GameObject _bullet = null;
    SpriteRenderer _icon; // 子彈發射位置
    ShootForceControl _forceControl = null;

    float _reShootTime = 0f; // 子彈冷卻時間
    bool _canShoot = true; 
    bool CanShoor{ 
        get{ return _canShoot; }
    }
    int _currentBullet = 0;

    PlayerAttirbute _attribute = null;

    void Start() {
        this._icon = GetComponentInChildren<SpriteRenderer>();
        this._forceControl = GetComponent<ShootForceControl>();

        this._attribute = GetComponentInParent<PlayerAttirbute>();
        ErrorLog.CheckComponentExist(this._attribute, "PlayerAttribte", this.name);
        
    }

    void SetBulletByAttribute() {
        this._bullet = this._attribute.GetBullet(this._currentBullet);
        if( ErrorLog.CheckComponentExist( this._bullet, "Bullet", "player" ) )
            this._speedBase = this._bullet.GetComponent<BulletManage>().IntervalTime;
    }
    
    void Update()
    {
        if (_canShoot == false) 
        {
            this._reShootTime -= Time.deltaTime;
            if (this._reShootTime <= 0)
                this._canShoot = true;
        }
    }

    public void SetBullet(GameObject bullet) {
        this._bullet = bullet;
        this._speedBase = this._bullet.GetComponent<BulletManage>().IntervalTime;
    }

    public void NextBullet(bool UpOrDown = true) {
        if (UpOrDown)
            this._currentBullet++;
        else 
            this._currentBullet--;
        SetBulletByAttribute();
    }

    public void Fire()
    {
        if( this._bullet == null )
            SetBulletByAttribute();

        if (this._forceControl.Enable)
        {
            this._forceControl.Enable = false;
            FireBullet();
            this._canShoot = false;
            this._reShootTime = Speed;
        }
    }
    void FireBullet()
    {
        GameObject bullet = Instantiate(_bullet, _icon.transform.position, transform.rotation) as GameObject;
        if (bullet.tag == "Untagged")
            bullet.tag = "Bullet";
        BulletManage bulletCtrl = bullet.GetComponent<BulletManage>();
        bulletCtrl.Speed *= (1 + _forceControl.Force * 0.02f);
        bulletCtrl.Attack = Mathf.CeilToInt(bulletCtrl.Attack * (1 + this._attribute.Attack.Current * 0.01f));
        PlaySound();
    }
    protected virtual void PlaySound() {
        SoundManage.Instance.Shoot.Play();
    }

    public void RunForce() {
        if (this._canShoot)
        {
            this._forceControl.Enable = true;
        }
    }

}
