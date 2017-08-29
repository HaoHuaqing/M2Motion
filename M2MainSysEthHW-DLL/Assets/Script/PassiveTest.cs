using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class PassiveTest : MonoBehaviour {

    static bool P0Bit;
    static bool P1Bit;
    static bool TestBit;
    bool SendUpBit;
    bool SendDwnBit;
    public Button StartBtn;
    public Button StopBtn;
    // Use this for initialization
    void Start ()
    {
        StartBtn.onClick.AddListener(StartBtnClick);
        StopBtn.onClick.AddListener(StopBtnClick);
        P0Bit = false;
        P1Bit = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (TestBit == true)
        {
            TestPassiveLinear();
        }
	}

    void StartBtnClick()
    {
        TestBit = true;
        print("Continue Test Start");
    }

    void StopBtnClick()
    {
        TestBit = false;
        StopCoroutine("WaitDown");
        StopCoroutine("WaitUp");
        DynaLinkHS.CmdServoOff();
        DynaLinkHS.CmdClearAlm();
        print("Continue Test Stop");
        P0Bit = false;
        P1Bit = true;
    }

    void TestPassiveLinear()
    {
        if (DynaLinkHS.StatusMotRT.PosDataJ1 <= 20010 && P0Bit==false )
        {
            StartCoroutine(WaitDown(0.6F));
            

        }

        if (DynaLinkHS.StatusMotRT.PosDataJ1 >= 79990 && P1Bit == false )
        {
            StartCoroutine(WaitUp(0.6F));
            
        }
        
 
        
    }
        
    IEnumerator WaitDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (P0Bit == false)
        {
            //DynaLinkHS.CmdServoOff();
            DynaLinkHS.CmdLinePassive(80000, 80000, 900000);
            print("down position Reach");
            P0Bit = true;
            P1Bit = false;
        }
    }

    IEnumerator WaitUp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (P1Bit == false)
        {
            //DynaLinkHS.CmdServoOff();
            DynaLinkHS.CmdLinePassive(20000, 20000, 900000);
            print("Up position Reach");
            P0Bit = false;
            P1Bit = true;
        }
    }   
}
