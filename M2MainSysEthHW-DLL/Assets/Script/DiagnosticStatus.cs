/********************************************************************************************
* File:Diagnostic function for servo motor status feedback 
* Code Author:Xuzhenhua
* Release data: 2017-June-15
* Release Version: DiagnosticStatus V1.0.0
* Support for API package: DynaLink V1.2.0
* Important notice: Do not change any defination interfacec or data!!!
* This file need to be place in the process all the time. To get the Motor Motion status
********************************************************************************************/

using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class DiagnosticStatus : MonoBehaviour {

    //test purpose signal, do not use
    public int test_RedundantX;
    public int test_RedundantY;
    public bool _tMotionInProcess;
    public bool _tMotionCaution;
    public bool _tMotPowerOn;
    public bool _tMotSysCalPass;
    public bool _tMotFault;
    public bool _tEMstopBit;
    public bool _tParaErrBit;
    public bool _tPauseBit;
    public byte _tLastOpTypeData;
    public string _tMasVersion;
    public int[] _tDTCDisp = new int[32];
    
    public int _tLowPassPosJ1;
    public int _tLowPassPosJ2;
    public int _tLowPassTorJ1;
    public int _tLowPassTorJ2;

    public int[] TmpPosJ1 = new int[3];
    public int[] TmpPosJ2 = new int[3];
    public int[] TmpTorJ1 = new int[3];
    public int[] TmpTorJ2 = new int[3];
   
    int iPos;
    int iSpd;
    int iTor;

    public static int MotionCounts;
    
    public static long EthFeedBackCounts;


    //Signal for motor status, filter type. Can be used
    public struct MotStatus
    {
        public static bool MotionInProcess;
        public static bool Caution;
        public static bool PowerOn;
        public static bool Fault;
        public static bool SysCalPass;
        public static bool EMstopBit;
        public static bool ParaErrBit;
        public static bool PauseBit;
    }

    public struct SysStatus
    {
        public static byte LastOpTypeData;
        public static string MasVersion;
        public static int[] DTCCodeVal = new int[32];
    }
   
    
    // Use this for initialization
    void Start ()
    {
        MotionCounts = 0;
        DynaLinkHS.EthCounts = 0;
        EthFeedBackCounts = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        MotDiagStatus();
        //test_RedundantX = DynaLinkAPI.RedunTorDataJ1;
        //test_RedundantY = DynaLinkAPI.RedunTorDataJ2;
    }

    void MotDiagStatus()
    {
        MotStatus.EMstopBit = DynaLinkHS.EMstop;
        _tEMstopBit = MotStatus.EMstopBit;

        MotStatus.MotionInProcess = DynaLinkHS.MotionInProcess;
        _tMotionInProcess = MotStatus.MotionInProcess;

        MotStatus.Caution = DynaLinkHS.MotionCaution;
        _tMotionCaution = MotStatus.Caution;

        MotStatus.PowerOn = DynaLinkHS.MotPowerOn;
        _tMotPowerOn = MotStatus.PowerOn;

        MotStatus.SysCalPass = DynaLinkHS.MotSysCalPass;
        _tMotSysCalPass = MotStatus.SysCalPass;

        MotStatus.Fault = DynaLinkHS.MotFault;
        _tMotFault = MotStatus.Fault;

        MotStatus.ParaErrBit = DynaLinkHS.ParaErr;
        _tParaErrBit = MotStatus.ParaErrBit;

        MotStatus.PauseBit = DynaLinkHS.PauseOp;
        _tPauseBit = MotStatus.PauseBit;

        _tLowPassPosJ1 = DynaLinkHS.StatusMotRT.PosDataJ1;
        _tLowPassPosJ2 = DynaLinkHS.StatusMotRT.PosDataJ2;
        _tLowPassTorJ1 = DynaLinkHS.StatusMotRT.TorDataJ1;
        _tLowPassTorJ2 = DynaLinkHS.StatusMotRT.TorDataJ2;

        SysStatus.LastOpTypeData = DynaLinkHS.LastOpTypeData;
        _tLastOpTypeData = SysStatus.LastOpTypeData;

        SysStatus.MasVersion = DynaLinkHS.MAS_Version;
        _tMasVersion = SysStatus.MasVersion;

        SysStatus.DTCCodeVal = DynaLinkHS.DTCCode;
        _tDTCDisp = SysStatus.DTCCodeVal;

        test_RedundantX = DynaLinkHS.StatusMotRT.RedunTorDataJ1;
        test_RedundantY = DynaLinkHS.StatusMotRT.RedunTorDataJ2;
    }
    
}
