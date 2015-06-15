using UnityEngine;
using System.Collections;

public class RoleControl : MonoBehaviour {

    ShootManage _shoot = null;

	// Use this for initialization
	void Start () {
        _shoot = GetComponentInChildren<ShootManage>();
        if (_shoot == null)
        {
            Debug.LogError("Shoot Not Found");
        }
	}
	
	// Update is called once per frame
	void Update () {
        ShootControl();
        //WeaponControl();
	}


    /*void WeaponControl() {
        if (Input.GetKey)
        {
            _shoot.RunForce();
        }
    }*/
    // 可以拉成一個class

    /*void ShootControl()  // 2P
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _shoot.Fire();
        }
    }*/
    Vector3 _relative;
    void ShootControl() 
    {
        // 改成用 OnMouseDown
        if (Input.GetMouseButtonDown(0)) 
        {
            _shoot.RunForce();
        }

        if (Input.GetMouseButton(0))
        {
            _relative = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _shoot.transform.rotation = Quaternion.Euler(Vector3.forward * Mathf.Atan2(_relative.y, _relative.x) * Mathf.Rad2Deg);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _shoot.Fire();
        }
    }

}
