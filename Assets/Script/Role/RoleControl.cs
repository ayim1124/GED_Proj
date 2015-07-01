using UnityEngine;
using System.Collections;

public class RoleControl : MonoBehaviour {
    Move _move = null;
    ShootManage _shoot = null;
    SkillManage _skill = null;
    public PlayerIndex Player;
    ControllerBase _controller = null;

	// Use this for initialization
	void Start () {
        this._shoot = GetComponentInChildren<ShootManage>();
        ErrorLog.CheckComponentExist(this._shoot, "ShootManage", this.name);
        this._shoot.transform.rotation = Quaternion.identity;
        this._angleZ = 0;
          
        this._move = GetComponent<Move>();
        ErrorLog.CheckComponentExist(this._move, "Move", this.name);

        this._skill = GetComponentInChildren<SkillManage>();
        ErrorLog.CheckComponentExist(this._skill, "SkillManage", this.name);

        this._controller = ControllerFactory.create(Player);
        ErrorLog.CheckComponentExist(this._controller, "Controller", this.name);
	}
	
	// Update is called once per frame
	void Update () {
        ShootControl();
        ChangeBulletControl();
        MoveControl();
        SkillControl();
	}

    enum ConditionFlags { None, Fire, Skill };
    ConditionFlags _flags = ConditionFlags.None;

    #region Weapon
    Vector3 _relative;
    float _angleZ = 0;

    void ShootControl()
    {
        if (Input.GetKeyDown(this._controller.Fire)) {
            if (this._flags == ConditionFlags.None)
            {
                this._flags = ConditionFlags.Fire;
                this._shoot.RunForce();
            }
        }else if (Input.GetKeyUp(this._controller.Fire)) {
            if (this._flags == ConditionFlags.Fire)
            {
                this._flags = ConditionFlags.None;
                _shoot.Fire();
            }
        }

        if (this._flags != ConditionFlags.Skill)
        {
            if (Input.GetKey(this._controller.Up))
                NextAngle(true);
            else if (Input.GetKey(this._controller.Down))
                NextAngle(false);
        }
    }
    float _speedAngle = 1.8f;
    void NextAngle(bool next) {
        if (next)
            this._angleZ += _speedAngle;
        else
            this._angleZ -= _speedAngle;
        this._shoot.transform.rotation = Quaternion.Euler(Vector3.forward * this._angleZ);
    }

    /* 單機使用
    //
    void ShootControl() 
    {
        //暫時先用位置判定
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 57 ) 
        {
            this._flags = ConditionFlags.Fire;
            this._shoot.RunForce();
        }

        if (this._flags == ConditionFlags.Fire)
        {
            if (Input.GetMouseButton(0))
            {
                _relative = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                _shoot.transform.rotation = Quaternion.Euler(Vector3.forward * Mathf.Atan2(_relative.y, _relative.x) * Mathf.Rad2Deg);
            }

            if (Input.GetMouseButtonUp(0))
            {
                this._flags == ConditionFlags.None;
                _shoot.Fire();
            }
        }
    }
    */

    void ChangeBulletControl() {
        if (this._flags == ConditionFlags.Skill) {
            if (Input.GetKeyUp(this._controller.Up)) {
                Debug.Log( "change" );
                this._shoot.NextBullet();
            }
        }
    }
    #endregion

    void MoveControl() {
        if (this._flags != ConditionFlags.Skill)
        {
            if (Input.GetKey(this._controller.Left))
            {
                //transform.rotation = Quaternion.Euler(Vector3.up*180);
                this._move.Left();
            }
            else if (Input.GetKey(this._controller.Right))
            {
                //transform.rotation = Quaternion.Euler(Vector3.zero);
                this._move.Right();
            }
        }

        if (Input.GetKeyDown(this._controller.Jump)) {
            this._move.Jump();
        }
    }

    void SkillControl() {
        if (Input.GetKeyDown(this._controller.Skill))
            if (this._flags == ConditionFlags.None)
                this._flags = ConditionFlags.Skill;
        if (this._flags == ConditionFlags.Skill) {
            if (Input.GetKeyUp(this._controller.Left))
                this._skill.UseSKill(0);
            else if (Input.GetKeyUp(this._controller.Down))
                this._skill.UseSKill(1);
            else if (Input.GetKeyUp(this._controller.Right))
                this._skill.UseSKill(2);

            if (Input.GetKeyUp(this._controller.Skill))
                if (this._flags == ConditionFlags.Skill)
                    this._flags = ConditionFlags.None;
        }
    }
}
