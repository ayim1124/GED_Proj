using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    Transform _role = null;
    public float JumpSpeed = 5f;
    bool _jump = false;

    void Start() {
        _role = transform.parent;
        if (_role == null)
            Debug.Log("can't find move target");
    }

    void Update () {
        if (_jump)
        {
            _role.Translate(Vector3.up * Time.deltaTime * JumpSpeed);
        }
	}
    
    public void Begin() {
        if (_jump == false)
            _jump = true;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        _jump = false;
    }
}
