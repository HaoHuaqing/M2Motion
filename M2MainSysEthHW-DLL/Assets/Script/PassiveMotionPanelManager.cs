using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class PassiveMotionPanelManager : MonoBehaviour
{
    public MainSysPanel BckMainPanel;
    public PassiveMotionPanelManager PassiveSelfPanel;

    public GameObject Player;
    public GameObject Beacon;

    public Button StartMotionBtn;
    public Button StopMotionBtn;
    public Button ReturnMain;

    public InputField PassiveSpeed;
    public InputField TrgXPosInput;
    public InputField TrgYPosInput;
    public InputField RedpointX;
    public InputField RedpointY;

    public static int UI_PassiveSpd;
    public static int UI_XPosVal;
    public static int UI_YPosVal;
    public static bool SendUpBit;
    public static bool SendDwnBit;

    private bool flag = false;
    public static int Red_XPosVal;
    public static int Red_YPosVal;
    public InputField outPath;
    static List<string> mWriteTxt = new List<string>();
    public GameObject redpoint;

    // Use this for initialization
    void Start()
    {
        ReturnMain.onClick.AddListener(ReturnMainBtnClick);
        StartMotionBtn.onClick.AddListener(StartMotionBtnClick);
        StopMotionBtn.onClick.AddListener(StopMotionBtnClick);
        //GameObject redpoint = GameObject.Find("redpoint");
        //redpoint.transform.localPosition = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            string[] temp = {DynaLinkHS.StatusMotRT.PosDataJ1.ToString(), ",", DynaLinkHS.StatusMotRT.PosDataJ2.ToString(), ",", DynaLinkHS.StatusMotRT.SpdDataJ1.ToString(), ",",
                DynaLinkHS.StatusMotRT.SpdDataJ2.ToString(), ",", DynaLinkHS.StatusMotRT.TorDataJ1.ToString(),",",DynaLinkHS.StatusMotRT.TorDataJ2.ToString(), "\r\n" };
            foreach (string t in temp)
            {
                using (StreamWriter writer = new StreamWriter(outPath.text, true, Encoding.UTF8))
                {
                    writer.Write(t);
                }
                mWriteTxt.Remove(t);
            }
            print(outPath.ToString());
        }
    }

    void ReturnMainBtnClick()
    {
        BckMainPanel.gameObject.SetActive(true);
        PassiveSelfPanel.gameObject.SetActive(false);
        Player.SetActive(false);
        Beacon.SetActive(false);
        redpoint.SetActive(false);
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

        float RedX;
        float RedY;
        redpoint.SetActive(true);
        Red_XPosVal = int.Parse(RedpointX.text);
        Red_YPosVal = int.Parse(RedpointY.text);
        RedX = Red_XPosVal / ModulePara.TrgXPosScale - 900;
        RedY = Red_YPosVal / ModulePara.TrgYPosScale - 270;
        redpoint.transform.localPosition = new Vector3(RedX, RedY, 0);

        //DynaLinkHS.CmdClearAlm();
        //DynaLinkHS.CmdServoOn();
        DynaLinkHS.CmdLinePassive(UI_XPosVal, UI_YPosVal, UI_PassiveSpd);
        flag = false;
    }
    void PauseMotionBtnClick()
    {
        //DynaLinkHS.CmdPauseMotion();
        DynaLinkHS.CmdServoOn();
    }
    void StopMotionBtnClick()
    {        
        DynaLinkHS.CmdServoOff();
        flag = true;
    }

}
