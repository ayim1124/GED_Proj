using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum MenuState { None, Start, Setting };

public class MenuManage : MonoBehaviour {
    Menu_Main _main = null;
    public static MenuState Status { get; private set; }
    void SetMenuByStatus(MenuState status)
    {
        MenuManage.Status = status;
        this._main.SetMenuByStatus();
    }

	// Use this for initialization
	void Start () {
        SoundManage.Instance.Menu.Play();
        this._main = GetComponentInChildren<Menu_Main>();
        ErrorLog.CheckComponentExist(this._main, "Menu_Main", this.name);
        this._main.Initial();
        SetMenuByStatus( MenuState.None );
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(1))
        {
            ClickCancel();
        }
	}
    void ClickCancel()
    {
        switch (MenuManage.Status) 
        {
            case MenuState.Start:
            case MenuState.Setting:
                SetMenuByStatus(MenuState.None);
                break;
            default:
                break;
        }
    }

    public void OnClick( GameObject sender ) {
        switch (sender.name)
        {
            case "Start":
                SetMenuByStatus(MenuState.Start);
                break;
            case "Setting":
                SetMenuByStatus(MenuState.Setting);
                break;
            default:
                break;
        }
    }
}
