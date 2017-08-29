/********************************************************************************************
* File: Demo Application for DynaLink Cmd application
* File Task: Manager all the Data Display informtaion control
* Release data: 2017-June-15
* Release Version: V3.0.0
* Communition Protol: Ethernet, UDP/IP
* Communition Application define: DynaLink V6.2
********************************************************************************************/
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;
public class DataDispManager : MonoBehaviour
{
    public Text DispCurrentPosX;
    public Text DispCurrentPosY;
    public Text DispCurrentSpdX;
    public Text DispCurrentSpdY;
    public Text DispCurrentTorX;
    public Text DispCurrentTorY;
    public Text DispValADC1;
    public Text DispValADC2;
    public Text DispEthCounts;
    public Text DispFeedBackCounts;
    public Text BuffUse;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        DispCurrentPosX.text = DynaLinkHS.StatusMotRT.PosDataJ1.ToString();//DiagnosticStatus.MotRTdata.LowPassPosJ1.ToString();
        DispCurrentPosY.text = DynaLinkHS.StatusMotRT.PosDataJ2.ToString();//DiagnosticStatus.MotRTdata.LowPassPosJ2.ToString();
        DispCurrentSpdX.text = DynaLinkHS.StatusMotRT.SpdDataJ1.ToString();
        DispCurrentSpdY.text = DynaLinkHS.StatusMotRT.SpdDataJ2.ToString();
        DispCurrentTorX.text = DynaLinkHS.StatusMotRT.TorDataJ1.ToString();//DiagnosticStatus.MotRTdata.LowPassTorJ1.ToString();
        DispCurrentTorY.text = DynaLinkHS.StatusMotRT.TorDataJ2.ToString();///DiagnosticStatus.MotRTdata.LowPassTorJ2.ToString();
        DispValADC1.text = DynaLinkHS.StatusADC.AdcDataS1.ToString();
        DispValADC2.text = DynaLinkHS.StatusADC.AdcDataS2.ToString();
        DispEthCounts.text = DynaLinkHS.EthCounts.ToString();
        DispFeedBackCounts.text = DynaLinkHS.DynaLinkAckCnt.ToString();
        BuffUse.text = DynaLinkHS.Ringbuff.BuffPoint.ToString();
        
    }

}
