﻿using UnityEngine;
using System.Collections;

public class MaxAndCurrent{
    int _max;
    public int Max { 
        get{ return _max; }
        set {
            if (value < 1)
                value = 1;
            _max = value;

            if (_current > _max)
                _current = _max;
        } 
    }
    
    int _current;
    public int Current {
        get { return _current; }
        set {
            _current = Mathf.Clamp(value, 0, _max);
        }
    }

    public void initial( int max, int cur = -1 ) {
        Max = max;
        if (cur == -1)
            Current = max;
        else
            Current = cur;
    }

    public MaxAndCurrent( int max = 100, int cur = 100 )
    {
        Max = max;
        Current = cur;
    }
}
