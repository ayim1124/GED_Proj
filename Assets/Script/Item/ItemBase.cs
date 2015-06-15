using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour {

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
           // Other.GetComponent<PlayerAttirbute>().AddAttackSpead(100);          
        }
        Destroy(gameObject);
    }
}
