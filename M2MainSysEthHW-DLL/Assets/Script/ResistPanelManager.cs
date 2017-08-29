using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class ResistPanelManager : MonoBehaviour {

    public MainSysPanel BckMainPanel;
    public ResistPanelManager ResistSelfPanel;

    public GameObject Player;

    public Button StartMotionBtn;
    public Button PauseMotionBtn;
    public Button StopMotionBtn;
    public Button ReturnMain;
        
    public InputField ResistTorValue;
    public InputField CwLimitValueX;
    public InputField CcwLimitValueX;
    public InputField CwLimitValueY;
    public InputField CcwLimitValueY;

    public static int UI_ResistVal;
    public static int UI_CwLimValX;
    public static int UI_CcwLimValX;
    public static int UI_CwLimValY;
    public static int UI_CcwLimValY;

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
        ResistSelfPanel.gameObject.SetActive(false);
        Player.SetActive(false);
    }

    void EMStopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void StartMotionBtnClick()
    {
        UI_ResistVal = int.Parse(ResistTorValue.text);
        DynaLinkHS.CmdResistLT(UI_ResistVal);
        UI_CwLimValX = int.Parse(CwLimitValueX.text);
        UI_CwLimValY = int.Parse(CwLimitValueY.text);
        DynaLinkHS.ChgCwLimitFun(UI_CwLimValX, UI_CwLimValY);
        UI_CcwLimValX = int.Parse(CcwLimitValueX.text);
        UI_CcwLimValY = int.Parse(CcwLimitValueY.text);
        DynaLinkHS.ChgCcwLimitFun(UI_CcwLimValX, UI_CcwLimValY);
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
