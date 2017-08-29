/********************************************************************************************
* File:Const Calibration control parameters for MMU application
* Code Author:Xuzhenhua
* Release data: 2016-Dec-28
* Release Version: CalPara V1.0.0
* Support for API package: DynaLink V2.2.0
********************************************************************************************/
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;

public class CalParaManager : MonoBehaviour {

    public Button UpdateProtectTorBtn;
    public Button UpdateVectorTorCalBtn;

    public InputField ProtectTorXInput;
    public InputField ProtectTorYInput;
    public InputField VectorTorqueTrapezoidalStepInput;
    public InputField VectorTorqueTrapezoidalMaxTimeInput;
    public InputField VectorTorque_XScaleInput;
    public InputField VectorTorque_YScaleInput;

    int UI_ProtectTorXValue;
    int UI_ProtectTorYValue;
    int UI_VectorTorqueTrapezoidalStep;
    int UI_VectorTorqueTrapezoidalMaxTime;
    float UI_VectorTorque_XScaleInput;
    float UI_VectorTorque_YScaleInput;
    // Use this for initialization
    void Start ()
    {
        UpdateProtectTorBtn.onClick.AddListener(UpdateProtectTorBtnClick);
        UpdateVectorTorCalBtn.onClick.AddListener(UpdateVectorTorCalBtnClick);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateProtectTorBtnClick()
    {
        UI_ProtectTorXValue =int.Parse(ProtectTorXInput.text);
        UI_ProtectTorYValue = int.Parse(ProtectTorYInput.text);
        DynaLinkHS.ChgCalProtectTor(UI_ProtectTorXValue, UI_ProtectTorYValue);
    }

    void UpdateVectorTorCalBtnClick()
    {
        UI_VectorTorqueTrapezoidalStep = int.Parse(VectorTorqueTrapezoidalStepInput.text);
        UI_VectorTorqueTrapezoidalMaxTime = int.Parse(VectorTorqueTrapezoidalMaxTimeInput.text);
        UI_VectorTorque_XScaleInput = float.Parse(VectorTorque_XScaleInput.text);
        UI_VectorTorque_YScaleInput = float.Parse(VectorTorque_YScaleInput.text);
        DynaLinkHS.ChgVectorTorqueTrapezoidalCal(UI_VectorTorqueTrapezoidalStep, UI_VectorTorqueTrapezoidalMaxTime, UI_VectorTorque_XScaleInput, UI_VectorTorque_YScaleInput);

    }
}
