using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Select_MonsterUnit : MonoBehaviour {
    Image _icon = null;
    public Sprite Icon {
        get { return this._icon.sprite; }
        set { this._icon.sprite = value; }
    }
    public int ID;
    public int Star;

    // Use this for initialization
    void Awake()
    {
        this._icon = GetComponent<Image>();
        ErrorLog.CheckComponentExist(this._icon, "Image", this.name);
    }

    public void SetUnit(Sprite icon, int id, int star)
    {
        Icon = icon;
        ID = id;
        Star = star;
    }

    public void ResetUnit() {
        Icon = null;
        ID = 0;
        Star = 0;
    }

    public void ReadyDeal() {
        this._icon.color = Color.gray;
    }
}
