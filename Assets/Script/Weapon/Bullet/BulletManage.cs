using UnityEngine;
using System.Collections;

public class BulletManage : MonoBehaviour {
    BulletControl _control = null;
    BulletEffectBase _effect = null;
    
    public int Attack = 100;
    public float Speed = 3f;
    public float IntervalTime = 1f;
	
    // Use this for initialization
	void Start () {
        _control = GetComponentInChildren<BulletControl>();
        _effect = GetComponentInChildren<BulletEffectBase>();
        if (_control == null || _effect == null)
            Debug.LogError("Bullet don't set");
	}

    public void Effect() {
        rigidbody2D.isKinematic = true;
        transform.Translate(Vector3.zero);
        _effect.Begin(Attack);
    }
}
