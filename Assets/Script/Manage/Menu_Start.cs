using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Menu_Start : MonoBehaviour {
    Image _start = null;
    bool _visible = false;
    /// <summary>
    /// 因為隱藏Image時Text無法跟著隱藏
    /// 所以直接把物件disabled
    /// </summary>
    public bool Visible
    {
        set {
            this._visible = value;
            SetVisible();
        }
    }
    void SetVisible()
    {
        gameObject.SetActive(this._visible);
    }
        

	// Use this for initialization
	void Start () {
        this._start = GetComponent<Image>();
        ErrorLog.CheckComponentExist(this._start, "Image", this.name);
	}
	
    public void OnClick( int num ){
        PassData.PlayerAmount = num;
        Application.LoadLevel(1);
    }
}
