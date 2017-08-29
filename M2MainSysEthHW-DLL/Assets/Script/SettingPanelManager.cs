using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class SettingPanelManager : MonoBehaviour {

    public MainSysPanel BckMainPanel;
    public SettingPanelManager SettingSelfPanel;

    public Button HomeCalBtn;
    public Button PauseBtn;
    public Button StopBtn;
    public Button ReturnMain;
    public Button ClearFault;
    public Button ClearAlm;
    // Use this for initialization
    void Start ()
    {
        HomeCalBtn.onClick.AddListener(HomeCalBtnClick);
        PauseBtn.onClick.AddListener(PauseBtnClick);
        StopBtn.onClick.AddListener(StopBtnClick);
        ReturnMain.onClick.AddListener(ReturnMainBtnClick);
        ClearFault.onClick.AddListener(ClearFaultClick);
        ClearAlm.onClick.AddListener(ClearAlmClick);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ReturnMainBtnClick()
    {
        BckMainPanel.gameObject.SetActive(true);
        SettingSelfPanel.gameObject.SetActive(false);
    }

    void EMStopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void HomeCalBtnClick()
    {
        DynaLinkHS.CmdClearAlm();
        DynaLinkHS.CmdServoOff();
        DynaLinkHS.CmdHomeCal();
    }
    void PauseBtnClick()
    {
        DynaLinkHS.CmdPauseMotion();
    }
    void StopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }
    void ClearFaultClick()
    {
        DynaLinkHS.CmdClearFault();
    }

    void ClearAlmClick()
    {
        DynaLinkHS.CmdClearAlm();
    }
}
