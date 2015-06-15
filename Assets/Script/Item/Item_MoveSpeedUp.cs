using UnityEngine;
using System.Collections;

public class Item_MoveSpeedUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Other.GetComponent<PlayerAttirbute>().MoveSpeed += 20;
        }
        Destroy(gameObject);
    }
}
