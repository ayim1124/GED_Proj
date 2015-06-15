using UnityEngine;
using System.Collections;

public class LandColliderDestory : MonoBehaviour {

    GameObject _item = null;

	// Use this for initialization
	void Start () {
        _item = ItemManage.RandomGet();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Bullet")
        {
            if( _item != null )
                Instantiate(_item, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
