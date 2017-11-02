using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;
using System.Collections.Generic;

public class MainSysPanel : MonoBehaviour {

    public MainSysPanel MainPanel;
    public SettingPanelManager SettingPanel;
    public MassSimPanelManager MassPanel;
    public VectorTorPanelManager VectorTorPanel;
    public VectorTorTrapPanelManager VectorTorTrapPanel;
    public ResistPanelManager ResistPanel;
    public PassiveMotionPanelManager PassiveMotionPanel;
    public PassiveCirclePanelManager PassiveCirclePanel;
    public TestModePanelManager TestModePanel;

    public GameObject Player;
    public GameObject Beacon;
    public GameObject redpoint;

    public Button ConnectNetBtn;
    public Button DisConnectNetBtn;
    public Button ExitAppBtn;
    public Button StopUDPBtn;

    public Button MassSimModeBtn;
    public Button SettingModeBtn;


    // Use this for initialization
    void Start()
    {
        ConnectNetBtn.onClick.AddListener(ConnectNetBtnClick);
        DisConnectNetBtn.onClick.AddListener(DisConnectNetBtnClick);
        SettingModeBtn.onClick.AddListener(SettingModeBtnClick);
        MassSimModeBtn.onClick.AddListener(MassSimModeBtnClick);
        ExitAppBtn.onClick.AddListener(ExitAppBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConnectNetBtnClick()
    {
        
    }

    void DisConnectNetBtnClick()
    {
    }
 
    void MassSimModeBtnClick()
    {
        ResistPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
        Beacon.SetActive(true);
        redpoint.SetActive(true);
    }


    void SettingModeBtnClick()
    {
        SettingPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
    }

    void ExitAppBtnClick()
    {
        DynaLinkHS.CmdServoOff();
        DynaLinkCore.StopSocket();
        Application.Quit();
    }
}
