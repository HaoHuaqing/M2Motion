/********************************************************************************************
* Company:          
* Company code:     
* Divition:         Software Reasearch Dept
* Funtion:          UDP Communication Core Thread Process, This Core need to put in the Unity obj
* Code Author:      Xuzhenhua (Eric)
* Release data:     2017-June-21
* Support Project:  DynaLinkHS API
* Version:          V3.1.0
**********************************************************************************************/
using UnityEngine;
using System.Collections;
using DLMotion;
using UdpBasicClass;

public class DynaLinkCore : MonoBehaviour {
   
    static bool UdpCloseBit;

    // Use this for initialization
    void Start ()
    {
        //Ringbuff.TxPoint = 0;
        //Ringbuff.BuffPoint = 0;
        //timeOut = 1;
        UdpCloseBit = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        DynaLinkHS.EthernetStatusWDG();
        if (UdpCloseBit==true)
        {
            StartCoroutine(WaitTime());
            UdpCloseBit = false;
        }
    }

    /////////////////////////////////////////////////////////////////////////////
    //Socket application 
    //Socket operation code area start
    //Do not Change IP address and Port number! 
    /////////////////////////////////////////////////////////////////////////////
    public static void ConnectClick()
    {      
        UdpSocketClient.InitSocket();
        Local_delay();   
        DynaLinkHS.SocketDataLogic();
        DynaLinkHS.CmdInitOp(0x01);//Init Net work request
        print("UDP port OPEN");
    }

    //Stop Socket connect opereation
    public static void StopSocket()
    {        
        DynaLinkHS.CmdInitOp(0x02);//Send close net work request
        print("Prepare to Close Udp");
        UdpCloseBit = true;      
    }

    static void Local_delay()
    {
        int i = 0;
        for (i = 0; i < 0xffffff; i++)
        { }
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.8f);
        //Must wait 0.8 sec befor close the UDP connection.
        DynaLinkHS.CoreThreadLoopBit = false;
        UdpSocketClient.SocketQuit();
        print("UDP port Closed Sucess");
    }

}


