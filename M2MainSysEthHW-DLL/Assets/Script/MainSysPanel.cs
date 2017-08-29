using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class MainSysPanel : MonoBehaviour {

    public MainSysPanel MainPanel;
    public SettingPanelManager SettingPanel;
    public MassSimPanelManager MassPanel;
    public VectorTorPanelManager VectorTorPanel;
    public VectorTorTrapPanelManager VectorTorTrapPanel;
    public ResistPanelManager ResistPanel;
    public AssistPanelManager AssistPanel;
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
    public Button VectorTorModeBtn;
    public Button SettingModeBtn;
    public Button PassiveModeBtn;
    public Button ResistLTModeBtn;
    public Button AssistLTModeBtn;
    public Button VectorTorTrapModeBtn;
    public Button PassiveCirModeBtn;
    public Button TraceRePlayModeBtn;
    public Button TestModeBtn;
    // Use this for initialization
    void Start()
    {
        ConnectNetBtn.onClick.AddListener(ConnectNetBtnClick);
        DisConnectNetBtn.onClick.AddListener(DisConnectNetBtnClick);
        SettingModeBtn.onClick.AddListener(SettingModeBtnClick);
        PassiveModeBtn.onClick.AddListener(PassiveModeBtnClick);
        ResistLTModeBtn.onClick.AddListener(ResistLTModeBtnClick);
        ExitAppBtn.onClick.AddListener(ExitAppBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConnectNetBtnClick()
    {
        DynaLinkCore.ConnectClick();
    }

    void DisConnectNetBtnClick()
    {
        DynaLinkCore.StopSocket();
    }

    void PassiveModeBtnClick()
    {
        PassiveMotionPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
        Beacon.SetActive(true);
        redpoint.SetActive(true);
    }
 
    void ResistLTModeBtnClick()
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
