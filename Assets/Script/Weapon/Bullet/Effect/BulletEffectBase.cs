using UnityEngine;
using System.Collections;

public class BulletEffectBase : MonoBehaviour {
    public GameObject BombEffect = null;
    protected bool _isWork = false;
    int _damage = 0;

	// Use this for initialization
	void Start () {
        this._isWork = false;
        renderer.enabled = false;
        collider2D.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (this._isWork)
        {
            Effect();
        }
	}
    protected virtual void Effect()
    {
        if (BombEffect != null)
            Instantiate(BombEffect, transform.position, Quaternion.identity);
        this._isWork = false;
        SoundManage.Instance.Bomb.Play();
        Destroy(transform.parent.gameObject, 0.03f);
    }

    public virtual void Begin(int damage)
    {
        _damage = damage;
        renderer.enabled = true;
        collider2D.enabled = true;
        _isWork = true;
    }
   

    void OnTriggerEnter2D(Collider2D Other)
    {
        if( Other.tag == "AI" || Other.tag == "Player" )
            Other.SendMessage("ApplyDamage", _damage, SendMessageOptions.DontRequireReceiver);
    }
}
