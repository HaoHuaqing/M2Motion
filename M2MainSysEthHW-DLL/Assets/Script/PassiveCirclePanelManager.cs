using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class PassiveCirclePanelManager : MonoBehaviour {

    public MainSysPanel BckMainPanel;
    public PassiveCirclePanelManager PassiveCircleSelfPanel;

    public GameObject Player;

    public Button StartMotionBtn;
    public Button PauseMotionBtn;
    public Button StopMotionBtn;
    public Button ReturnMain;
        
    public InputField PassiveSpeed;
    public InputField RadiusInput;
    public InputField DirInput;

    public static int UI_PassiveSpd;
    public static int UI_RadiusVal;
    public static int UI_RadiusDir;

    public enum PassiveCirPara:int
    {
        Cw=0,
        Ccw=1,
    }
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
        PassiveCircleSelfPanel.gameObject.SetActive(false);
        Player.SetActive(false);
    }

    void EMStopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void StartMotionBtnClick()
    {
        UI_PassiveSpd = int.Parse(PassiveSpeed.text);
        UI_RadiusVal = int.Parse(RadiusInput.text);
        UI_RadiusDir = int.Parse(DirInput.text);
        DynaLinkHS.CmdCirclePassive(UI_RadiusVal, UI_PassiveSpd, UI_RadiusDir);
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
