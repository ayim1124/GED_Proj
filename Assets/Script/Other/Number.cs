using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Number : MonoBehaviour {
    int _num = 0;
    public int Num {
        set {
            _num = (int)Mathf.Clamp(value, 0, Mathf.Pow(10, _maxDigit)-1);
            SetNumber();
        }
        get { return _num; }
    }
    List<SpriteRenderer> _numbers = null;
    const int _maxDigit = 6;
    const float _unitSize = 0.16f;

    bool _isInitial = false;
    void Start() {
        Initial();
    }
    public void Initial() {
        if (this._isInitial == false)
        {
            _numbers = new List<SpriteRenderer>();
            for (int i = 0; i < _maxDigit; i++)
            {
                AddSpriteRenderer(i);
            }
            this._isInitial = true;
        }
    }
    void AddSpriteRenderer( int index ) {
        GameObject num = new GameObject("digit" + index.ToString());
        num.transform.parent = transform;
        num.transform.localPosition = Vector3.left * index * _unitSize;
        SpriteRenderer sprite = num.AddComponent<SpriteRenderer>();
        sprite.sortingOrder = 2;
        _numbers.Add( sprite );
        
    }

    void SetNumber() {
        if (_num == 0) {
            foreach (SpriteRenderer icon in _numbers)
                icon.enabled = false;
            return;
        }

        int digit = 0;
        for (int num = _num; num >= 1; digit++, num /= 10) {
            _numbers[digit].enabled = true;
            _numbers[digit].sprite = IconManage.Number[num % 10];
        }
        for (; digit < _maxDigit; digit++)
            _numbers[digit].enabled = false;
    }
}
