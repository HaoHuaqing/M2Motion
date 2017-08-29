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
        MassSimModeBtn.onClick.AddListener(MassSimModeBtnClick);
        ConnectNetBtn.onClick.AddListener(ConnectNetBtnClick);
        DisConnectNetBtn.onClick.AddListener(DisConnectNetBtnClick);
        VectorTorModeBtn.onClick.AddListener(VectorTorModeBtnClick);
        VectorTorTrapModeBtn.onClick.AddListener(VectorTorTrapModeBtnClick);
        SettingModeBtn.onClick.AddListener(SettingModeBtnClick);
        PassiveModeBtn.onClick.AddListener(PassiveModeBtnClick);
        PassiveCirModeBtn.onClick.AddListener(PassiveCirModeBtnClick);
        ResistLTModeBtn.onClick.AddListener(ResistLTModeBtnClick);
        AssistLTModeBtn.onClick.AddListener(AssistLTModeBtnClick);
        TestModeBtn.onClick.AddListener(TestModeBtnClick);
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

    void MassSimModeBtnClick()
    {
        MassPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
    }
    void VectorTorModeBtnClick()
    {
        VectorTorPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
        Beacon.SetActive(true);
    }

    void PassiveModeBtnClick()
    {
        PassiveMotionPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
        Beacon.SetActive(true);
    }
    void PassiveCirModeBtnClick()
    {
        PassiveCirclePanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
    }
    void ResistLTModeBtnClick()
    {
        ResistPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
    }
    void AssistLTModeBtnClick()
    {
        AssistPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
    }
    void VectorTorTrapModeBtnClick()
    {
        VectorTorTrapPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
        Beacon.SetActive(true);
    }
   

    void SettingModeBtnClick()
    {
        SettingPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
    }

    void TestModeBtnClick()
    {
        TestModePanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        Player.SetActive(true);
    }

    void ExitAppBtnClick()
    {
        DynaLinkHS.CmdServoOff();
        DynaLinkCore.StopSocket();
        Application.Quit();
    }
}
