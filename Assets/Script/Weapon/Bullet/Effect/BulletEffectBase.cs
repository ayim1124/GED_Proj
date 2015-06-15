using UnityEngine;
using System.Collections;

public class BulletEffectBase : MonoBehaviour {
    bool _isWork = false;
    int _damage = 0;

	// Use this for initialization
	void Start () {
        _isWork = false;
        renderer.enabled = false;
        collider2D.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (_isWork)
        {
            Effect();
        }
	}
    protected virtual void Effect() {
        Destroy(transform.parent.gameObject);
    }

    public void Begin(int damage)
    {
        _damage = damage;
        renderer.enabled = true;
        collider2D.enabled = true;
        _isWork = true;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if( Other.tag == "AI" || Other.tag == "Player" )
            Other.SendMessage("ApplyDamage", _damage);
    }
}
