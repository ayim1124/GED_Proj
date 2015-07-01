using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour {
	void Update () {
        transform.Rotate(Vector3.forward* Time.deltaTime * 720f);
	}
}
