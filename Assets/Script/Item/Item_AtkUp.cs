using UnityEngine;
using System.Collections;

public class Item_AtkUp : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Other.GetComponent<PlayerAttirbute>().Attack += 10;
        }
        Destroy(gameObject);
    }
}
