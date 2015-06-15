using UnityEngine;
using System.Collections;

public class ShootForceControl : MonoBehaviour {
    public Transform IconTrans = null;
    bool _enable;
    public bool Enable
    {
        get { return _enable; }
        set {
            _enable = value;
            enabled = _enable;
            _forceBar.Visible = _enable;
        }
    }
    public int Force {
        get { return _forceBar.Percent; }
    }
    public int MaxForce = 60; // 之後改成屬性
    ForceBar _forceBar = null;

	// Use this for initialization
	void Start () {
        _forceBar = GetComponentInChildren<ForceBar>();
        Enable = false;
	}

	void Update () {
        if (_enable) {
            _forceBar.transform.position = IconTrans.position + Vector3.up * 0.5f;
            _forceBar.transform.rotation = Quaternion.identity;
            _forceBar.Percent = Mathf.RoundToInt(Mathf.PingPong(Time.time * 100, MaxForce));
        }
	}
}
