using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class TestModePanelManager : MonoBehaviour
{
    public MainSysPanel BckMainPanel;
    public TestModePanelManager TestSelfPanel;

    public GameObject Player;
    public GameObject Beacon;

    public Button StartMotionBtn;
    public Button PauseMotionBtn;
    public Button StopMotionBtn;
    public Button ReturnMain;

    public InputField PassiveSpeed;
    public InputField TrgXPosInput;
    public InputField TrgYPosInput;

    public static int UI_PassiveSpd;
    public static int UI_XPosVal;
    public static int UI_YPosVal;
    public static bool SendUpBit;
    public static bool SendDwnBit;
    // Use this for initialization
    void Start()
    {
        ReturnMain.onClick.AddListener(ReturnMainBtnClick);
        StartMotionBtn.onClick.AddListener(StartMotionBtnClick);
        PauseMotionBtn.onClick.AddListener(PauseMotionBtnClick);
        StopMotionBtn.onClick.AddListener(StopMotionBtnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReturnMainBtnClick()
    {
        BckMainPanel.gameObject.SetActive(true);
        TestSelfPanel.gameObject.SetActive(false);
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
        UI_PassiveSpd = int.Parse(PassiveSpeed.text);
        UI_XPosVal = int.Parse(TrgXPosInput.text);
        UI_YPosVal = int.Parse(TrgYPosInput.text);
        xPos = UI_XPosVal / ModulePara.TrgXPosScale - 900;
        yPos = UI_YPosVal / ModulePara.TrgYPosScale - 270;
        Beacon.transform.localPosition = new Vector3(xPos, yPos, 0);

        DynaLinkHS.CmdTestMode(UI_XPosVal, UI_YPosVal, UI_PassiveSpd);      
    }
    void PauseMotionBtnClick()
    {
        //DynaLinkHS.CmdPauseMotion();
        DynaLinkHS.CmdServoOn();
    }
    void StopMotionBtnClick()
    {        
        DynaLinkHS.CmdServoOff();       
    }

}
