using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class IOStatusManager : MonoBehaviour {

    public Text StatusIDL0;
    public Text StatusIDL1;
    public Text StatusIDL2;
    public Text StatusIDL3;

    public Toggle ODL0Tog;
    public Toggle ODL1Tog;
    public Toggle ODL2Tog;
    public Toggle ODL3Tog;

    public Text ValueADC1;
    public Text ValueADC2;
    public Text ValueADC3;
    public Text ValueADC4;
    public Text ValueDiagBatt;
    public Text CurrentMechType;

    public Button UpdateDOBtn;

    byte[] StatusODL = new byte[4];
  
    // Use this for initialization
    void Start ()
    {
        UpdateDOBtn.onClick.AddListener(UpdateDOBtnClick);
        ODL0Tog.onValueChanged.AddListener(ODL0TogOnChange);
        ODL1Tog.onValueChanged.AddListener(ODL1TogOnChange);
        ODL2Tog.onValueChanged.AddListener(ODL2TogOnChange);
        ODL3Tog.onValueChanged.AddListener(ODL3TogOnChange);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        StatusIDL0.text = DynaLinkHS.StatusDigiInput.IDL[0].ToString();
        StatusIDL1.text = DynaLinkHS.StatusDigiInput.IDL[1].ToString();
        StatusIDL2.text = DynaLinkHS.StatusDigiInput.IDL[2].ToString();
        StatusIDL3.text = DynaLinkHS.StatusDigiInput.IDL[3].ToString();
        
        ValueADC1.text = DynaLinkHS.StatusADC.AdcDataS1.ToString();
        ValueADC2.text = DynaLinkHS.StatusADC.AdcDataS2.ToString();
        ValueADC3.text = DynaLinkHS.StatusADC.AdcDataS3.ToString();
        ValueADC4.text = DynaLinkHS.StatusADC.AdcDataS4.ToString();
        ValueDiagBatt.text = DynaLinkHS.StatusADC.RealVolt.ToString();
        CurrentMechType.text = DynaLinkHS.MechType.ToString();
        
    }

    void ODL0TogOnChange(bool check)
    {
        if (check == true)
        {
            StatusODL[0] = 0x01;
        }
        else
        {
            StatusODL[0] = 0x00;
        }        
    }
    void ODL1TogOnChange(bool check)
    {
        if (check == true)
        {
            StatusODL[1] = 0x01;
        }
        else
        {
            StatusODL[1] = 0x00;
        }
    }
    void ODL2TogOnChange(bool check)
    {
        if (check == true)
        {
            StatusODL[2] = 0x01;
        }
        else
        {
            StatusODL[2] = 0x00;
        }
    }
    void ODL3TogOnChange(bool check)
    {
        if (check == true)
        {
            StatusODL[3] = 0x01;
        }
        else
        {
            StatusODL[3] = 0x00;
        }
    }
  
    void UpdateDOBtnClick()
    {
        DynaLinkHS.CmdOperateDOFun(StatusODL[0], StatusODL[1], StatusODL[2], StatusODL[3]);
    }
}
