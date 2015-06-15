using UnityEngine;
using System.Collections;

public class AI_Attribute : MonoBehaviour {

    public int hp = 3000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ApplyDamage(int damage = 0)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy(gameObject);
    }
}
