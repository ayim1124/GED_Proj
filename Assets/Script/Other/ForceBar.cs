/**
 *  給予Percent
 *  Foreground會移動到相對的位置
 */

using UnityEngine;
using System.Collections;

public class ForceBar : MonoBehaviour {

    public float MaxWeight = 0.6f;
    public GameObject Background = null;
    public GameObject Foreground = null;

    int _percent;
    public int Percent
    {
        get{ return _percent; }
        set
        {
            _percent = value;
            Foreground.transform.localPosition = Vector3.right * (-MaxWeight / 2 + MaxWeight * _percent * 0.01f);
        }
    }
    bool _visible;
    public bool Visible {
        get { return _visible; }
        set 
        { 
            _visible = value;
            Background.renderer.enabled = _visible;
            Foreground.renderer.enabled = _visible;
        }
    }

	// Use this for initialization
	void Start () {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        if (Background == null) 
            Background = FindGameObjectByTag(sprites, "BackSprite");
       
        if (Foreground == null) 
            Foreground = FindGameObjectByTag(sprites, "ForwardSprite");   
        
        if (Background == null || Foreground == null ) 
            Debug.LogError("ForceBar object not define");

        Percent = 0;
        Visible = true;
	}
    GameObject FindGameObjectByTag( SpriteRenderer[] sprites, string tagName ) {
        foreach (SpriteRenderer sprite in sprites)
            if (sprite.tag == tagName)
                return sprite.gameObject;
        return null;
    }
}
