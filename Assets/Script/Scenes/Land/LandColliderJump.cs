using UnityEngine;
using System.Collections;

public class LandColliderJump : MonoBehaviour {

    //void OnCollisionEnter2D(Collision2D collision)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Jump")
        {
            other.GetComponent<Jump>().Begin(2f);
        }
    }
}
