using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class VectorTorPanelManager : MonoBehaviour {

    public MainSysPanel BckMainPanel;
    public VectorTorPanelManager VectorTorSelfPanel;

    public GameObject Player;
    public GameObject Beacon;

    public Button StartMotionBtn;
    public Button PauseMotionBtn;
    public Button StopMotionBtn;
    public Button ReturnMain;
        
    public InputField MaxAssistTorInput;
    public InputField TrgXPosInput;
    public InputField TrgYPosInput;

    public static int UI_MaxTorVal;
    public static int UI_XPosVal;
    public static int UI_YPosVal;

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
        VectorTorSelfPanel.gameObject.SetActive(false);
        Player.SetActive(false);
        Beacon.SetActive(false);
    }

    void EMStopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void StartMotionBtnClick()
    {
        float xPos;
        float yPos;
        UI_MaxTorVal = int.Parse(MaxAssistTorInput.text);
        UI_XPosVal = int.Parse(TrgXPosInput.text);
        UI_YPosVal = int.Parse(TrgYPosInput.text);
       
        DynaLinkHS.CmdSyncVectorTorqueAst(UI_XPosVal, UI_YPosVal, UI_MaxTorVal);
        xPos = UI_XPosVal / ModulePara.TrgXPosScale - 900;
        yPos = UI_YPosVal / ModulePara.TrgYPosScale - 270;
        Beacon.transform.localPosition = new Vector3(xPos, yPos,0);
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
