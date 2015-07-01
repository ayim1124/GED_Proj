using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Menu_Main : MonoBehaviour {
    Menu_Start _start = null;

    public List<Button> BtnsMode;
    bool _interactable = true;
    public bool Interactable
    {
        set
        {
            this._interactable = value;
            SetInteractable();
        }
    }
    void SetInteractable()
    {
        foreach (Button btn in this.BtnsMode)
        {
            btn.interactable = this._interactable;
        }
    }

    public void Initial() {
        this._start = GetComponentInChildren<Menu_Start>();
        ErrorLog.CheckComponentExist(this._start, "Menu_Start", this.name);
    }

    public void SetMenuByStatus() {
        switch (MenuManage.Status) { 
            case MenuState.None:
                this._start.Visible = false;
                // setting隱藏
                Interactable = true;
                break;
            case MenuState.Start:
                this._start.Visible = true;
                Interactable = false;
                // setting隱藏
                break;
            case MenuState.Setting:
                break;
            default:
                break;
        }
    }

    public void OnClickStart() {
        ;
    }

    public void OnClickSetting() {
        ;
    }

    public void OnClickExit() {
        Application.Quit(); ;
    }
}
