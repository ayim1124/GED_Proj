using UnityEngine;
using System.Collections;

public abstract class ItemBase : MonoBehaviour
{
    float _indestructibleTime = 0.6f;

    // Use this for initialization
    void Start()
    {
        collider2D.enabled = false;
        Invoke("enableCollider", _indestructibleTime);
    }
    void enableCollider()
    {
        collider2D.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            Effect(Other);        
        }
        Destroy(gameObject);
    }
    protected abstract void Effect( Collider2D Other );
}
