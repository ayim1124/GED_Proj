using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour {
    int _value = 0;
    public int Qa {
        set { _value = value; }
        get { return _value; }
    }
}
