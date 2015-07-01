using UnityEngine;
using System.Collections;

public class EffectDestory : MonoBehaviour {
    public float Time = 1f;

	void Start () {
        Destroy(gameObject, Time);
	}
}
