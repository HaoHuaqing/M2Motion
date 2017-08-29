using UnityEngine;
using System.Collections;
using DLMotion;

public class CreatPassiveTrg : MonoBehaviour
{
    //DiagnosticStatus diagStatus = new DiagnosticStatus();
    //DiagnosticStatus.MotRTdata diagMotRt = new DiagnosticStatus.MotRTdata();
    public static bool PassiveTestRunBit;
    
    int currentPoint;

    bool TrgDepolyBit;
    // Use this for initialization
    void Start()
    {
        TrgDepolyBit = false;
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PassiveTestRunBit == true)
        {
            switch (currentPoint)
            {
                case 1:
                    tCreatXYspdTrg(200,300,2000);
                    break;
                case 2:
                    tCreatXYspdTrg(700, 800, 2000);
                    break;
            }

            if (currentPoint>2)
            {
                currentPoint = 1;
            }
        }
        if (PassiveTestRunBit == false)
        {
            currentPoint = 1;
            TrgDepolyBit = false;
        }
    }

    //void Point()
    //{
    //    if (TrgDepolyBit == false)
    //    {
    //        DynaLinkAPI.Motion.ChgPasiXYZSpd(200, 300, 900);
    //        DynaLinkAPI.Motion.CmdPassiveMotion();
    //        TrgDepolyBit = true;
    //        return;
    //    }
    //    if (TrgDepolyBit == true && DiagnosticStatus.MotStatus.MotionInProcess == false && DiagnosticStatus.MotRTdata.LowPassPosJ1 >= 249 && DiagnosticStatus.MotRTdata.LowPassPosJ1 <= 251)
    //    {
    //        DynaLinkAPI.Motion.ChgPasiXYZSpd(200, 300, 900);
    //        DynaLinkAPI.Motion.CmdPassiveMotion();
    //        return;
    //    }
    //    if (TrgDepolyBit == true && DiagnosticStatus.MotStatus.MotionInProcess == false && DiagnosticStatus.MotRTdata.LowPassPosJ1 >= 199 && DiagnosticStatus.MotRTdata.LowPassPosJ1 <= 201)
    //    {
    //        DynaLinkAPI.Motion.ChgPasiXYZSpd(250, 350, 900);
    //        DynaLinkAPI.Motion.CmdPassiveMotion();
    //        return;
    //    }

    //}


    //void CreatXYspdTrg(int xtPos, int ytPos, int tSpd, int pointID,int nextPointID)
    //{
    //    if (currentPoint == pointID && TrgDepolyBit==false)
    //    {
    //        DynaLinkAPI.Motion.ChgPasiXYZSpd(xtPos, ytPos, tSpd);
    //        DynaLinkAPI.Motion.CmdPassiveMotion();
    //        TrgDepolyBit = true;

    //    }
    //    if (currentPoint == pointID && (DynaLinkAPI.PosDataJ1 == xtPos && DynaLinkAPI.PosDataJ2 == ytPos))
    //    {
    //        currentPoint = nextPointID;
    //        TrgDepolyBit = false;
    //    }
    //}


    void tCreatXYspdTrg(int xtPos, int ytPos, int tSpd)
    {
        if (TrgDepolyBit == false && DiagnosticStatus.MotStatus.MotionInProcess == false)
        {

            //DynaLinkAPI.Motion.ChgPasiXYZSpd(xtPos, ytPos, tSpd);
         
            TrgDepolyBit = true;
            //DynaLinkAPI.Motion.CmdPassiveMotion();
            DiagnosticStatus.MotionCounts++;
        }
        //if (DiagnosticStatus.MotStatus.MotionInProcess == false && DiagnosticStatus.MotRTdata.LowPassPosJ1 ==xtPos && DiagnosticStatus.MotRTdata.LowPassPosJ2 == ytPos)
        if (DiagnosticStatus.MotStatus.MotionInProcess == false && (DynaLinkHS.StatusMotRT.PosDataJ1 >= (xtPos - 2) && DynaLinkHS.StatusMotRT.PosDataJ1 <= (xtPos + 2)) && (DynaLinkHS.StatusMotRT.PosDataJ2 >= (ytPos - 2) && DynaLinkHS.StatusMotRT.PosDataJ2 <= (ytPos + 2)))
        {
            currentPoint++;
            TrgDepolyBit = false;
            //Debug.Log("next point");
        }
    }

    private void Dly(int countDown)
    {
        do
        {
            countDown--;
        } while (countDown > 1);
    }
}
