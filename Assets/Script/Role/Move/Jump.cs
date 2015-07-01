using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    Transform _role = null;
    public float JumpSpeed = 3.2f;
    float _extra;
    bool _jump = false;

    void Start() {
        _role = transform.parent;
        if (_role == null)
            Debug.Log("can't find move target");
    }

    void Update () {
        if (_jump)
        {
            _role.Translate(Vector3.up * Time.deltaTime * (JumpSpeed+_extra));
        }
	}
    
    public void Begin( float extra = 0 ) {
        this._extra = extra;
        if (_jump == false)
            _jump = true;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name != "LandUp")
        {
            this._extra = 0;
            _jump = false;
        }
    }
}
