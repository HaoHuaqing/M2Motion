using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;
public class NetStatus : MonoBehaviour {

    public Sprite NetStatusOK;
    public Sprite NetStatusFail;

    public Button testok;
    public Button testfail;

    public bool EthernetStatus;
    public int TestWDGcount;

    //CoreSystem coresys = new CoreSystem();

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        ConnectStatus();
       
	}

    void ConnectStatus()
    {
        EthernetStatus = DynaLinkHS.ServerLinkActBit;
        TestWDGcount = DynaLinkHS.LinkActWDG;

        if (EthernetStatus == true)
        {
            LoadNetOKSprite();
        }
        else if (EthernetStatus == false)
        {
            LoadNetFailSprite();
        }
    }

    void LoadNetOKSprite()
    {
        GetComponent<Image>().sprite = NetStatusOK;
    }

    void LoadNetFailSprite()
    {
        GetComponent<Image>().sprite = NetStatusFail;
    }
}
