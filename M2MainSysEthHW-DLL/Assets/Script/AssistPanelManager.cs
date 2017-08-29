using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class AssistPanelManager : MonoBehaviour {

    public MainSysPanel BckMainPanel;
    public AssistPanelManager AssistSelfPanel;

    public GameObject Player;

    public Button StartMotionBtn;
    public Button PauseMotionBtn;
    public Button StopMotionBtn;
    public Button ReturnMain;
        
    public InputField AssistTorValue;

    public static int UI_AssistVal;

    // Use this for initialization
    void Start ()
    {
        ReturnMain.onClick.AddListener(ReturnMainBtnClick);
        StartMotionBtn.onClick.AddListener(StartMotionBtnClick);
        PauseMotionBtn.onClick.AddListener(PauseMotionBtnClick);
        StopMotionBtn.onClick.AddListener(StopMotionBtnClick);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void ReturnMainBtnClick()
    {
        BckMainPanel.gameObject.SetActive(true);
        AssistSelfPanel.gameObject.SetActive(false);
        Player.SetActive(false);
    }

    void EMStopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void StartMotionBtnClick()
    {
        UI_AssistVal = int.Parse(AssistTorValue.text);
        DynaLinkHS.CmdAssistLT(UI_AssistVal);
    }
    void PauseMotionBtnClick()
    {
        DynaLinkHS.CmdPauseMotion();
    }
    void StopMotionBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }
}
