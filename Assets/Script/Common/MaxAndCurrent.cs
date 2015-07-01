using UnityEngine;
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

    int _origin;
    public int Origin {
        get { return _current; }
        set{ _current = Mathf.Clamp(value, 0, Max); }  
    }

    public int Extra { get; set; }

    int _current;
    public int Current {
        get { return Mathf.Clamp((Origin+Extra), 0, Max); }
    }

    public MaxAndCurrent(int max = 100, int cur = 100)
    {
        Max = max;
        Origin = cur;
    }

    public void initial( int max, int cur = -1 ) {
        Max = max;
        if (cur == -1)
            Origin = max;
        else
            Origin = cur;
    }
}
