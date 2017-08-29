using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class MassSimPanelManager : MonoBehaviour {

    public MainSysPanel BckMainPanel;
    public MassSimPanelManager MassSimSelfPanel;

    public GameObject Player;
    public Button StartMotionBtn;
    public Button PauseMotionBtn;
    public Button StopMotionBtn;
    public Button ReturnMain;
        
    public InputField MassValInput;
    public InputField ffValInput;

    public static int UI_MassVal;
    public static int UI_FfVal;

    // Use this for initialization
    void Start ()
    {
        ReturnMain.onClick.AddListener(ReturnMainBtnClick);
        StartMotionBtn.onClick.AddListener(StartMotionBtnClick);
        PauseMotionBtn.onClick.AddListener(PauseMotionBtnClick);
        StopMotionBtn.onClick.AddListener(StopMotionBtnClick);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ReturnMainBtnClick()
    {
        BckMainPanel.gameObject.SetActive(true);
        MassSimSelfPanel.gameObject.SetActive(false);
        Player.SetActive(false);
    }

    void EMStopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void StartMotionBtnClick()
    {
        UI_MassVal = int.Parse(MassValInput.text);
        UI_FfVal = int.Parse(ffValInput.text);
        DynaLinkHS.CmdMassSim(UI_MassVal, UI_FfVal);
    }
    void PauseMotionBtnClick()
    {
        DynaLinkHS.CmdPauseMotion();
    }
    void StopMotionBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void Delay(UInt64 CountDown)
    {
        do
        {
            CountDown--;
        } while (CountDown > 1);
    }
}
