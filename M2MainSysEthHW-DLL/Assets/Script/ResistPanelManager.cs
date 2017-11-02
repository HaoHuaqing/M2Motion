﻿using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Threading;

public class ResistPanelManager : MonoBehaviour
{

    public MainSysPanel BckMainPanel;
    public ResistPanelManager ResistSelfPanel;

    public GameObject Player;
    public GameObject Beacon;

    public Button ReturnMotionBtn;
    public Button ReleaseMotionBtn;
    public Button StopMotionBtn;
    public Button ConnectEMG;
    public Button ReturnMain;
    public Button Next;
    public Button Previous;

    public static int OriX;
    public static int OriY;
    public static int DstX;
    public static int DstY;

    private bool running = false;
    public InputField outPath;
    static List<string> mWriteTxt = new List<string>();
    public GameObject redpoint;
    private string SavePathResist;

    private int sum;
    private int[,] trial = new int[100, 10];
    private int count = 0;
    private string partition = "-----------------------";
    public Text Trial;
    public AudioSource music;
    List<string> listToHoldData =  new List<string>();

    void Awake()
    {
        //Record data every 10ms
        InvokeRepeating("RecordData", 0, 0.01F);
    }

    void RecordData()
    {
        if (running)
        {
            string[] temp = {DynaLinkHS.StatusMotRT.PosDataJ1.ToString(), ",", DynaLinkHS.StatusMotRT.PosDataJ2.ToString(), ",", DynaLinkHS.StatusMotRT.SpdDataJ1.ToString(), ",",
                DynaLinkHS.StatusMotRT.SpdDataJ2.ToString(), ",", DynaLinkHS.StatusMotRT.TorDataJ1.ToString(),",",DynaLinkHS.StatusMotRT.TorDataJ2.ToString(),",",
                DynaLinkHS.StatusADC.AdcDataS1.ToString(), ",", DynaLinkHS.StatusADC.AdcDataS2.ToString(), "\r\n" };
            foreach (string t in temp)
            {
                using (StreamWriter writer = new StreamWriter(SavePathResist, true, Encoding.UTF8))
                {
                    writer.Write(t);
                }
                mWriteTxt.Remove(t);
            }
        }
    }

    void Start()
    {
        ReturnMain.onClick.AddListener(ReturnMainBtnClick);
        ReturnMotionBtn.onClick.AddListener(ReturnMotionBtnClick);
        ReleaseMotionBtn.onClick.AddListener(ReleaseMotionBtnClick);
        ConnectEMG.onClick.AddListener(ConnectEMGBtnClick);
        StopMotionBtn.onClick.AddListener(StopMotionBtnClick);
        Next.onClick.AddListener(NextBtnClick);
        Previous.onClick.AddListener(PreviousBtnClick);


        CSVHelper.Instance().ReadCSVFile("config", (table) => {

            // 可以遍历整张表
            //foreach (CSVLine line in table)
            //{
            //    foreach (KeyValuePair<string, string> item in line)
            //    {
            //        Debug.Log(string.Format("item key = {0} item value = {1}", item.Key, item.Value));
            //    }
            //}
            //可以拿到表中任意一项数据
            sum = int.Parse(table["0"]["Factor"]) - 1000;
            for (int i = 0; i <= sum; i++)
            {
                trial[i, 0] = int.Parse((table[i.ToString()])["id"]);
                trial[i, 1] = int.Parse((table[i.ToString()])["Task"]);
                trial[i, 2] = int.Parse((table[i.ToString()])["OriX"]);
                trial[i, 3] = int.Parse((table[i.ToString()])["OriY"]);
                trial[i, 4] = int.Parse((table[i.ToString()])["DstX"]);
                trial[i, 5] = int.Parse((table[i.ToString()])["DstY"]);
                trial[i, 6] = int.Parse((table[i.ToString()])["Mass"]);
                trial[i, 7] = int.Parse((table[i.ToString()])["Factor"]);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextBtnClick()
    {
        count = Math.Min(sum, count + 1);
        Trial.text = count.ToString();
    }

    void PreviousBtnClick()
    {
        count = Math.Max(0, count - 1);
        Trial.text = count.ToString();
        for(int i = 0; i<=5; i++)
        {
            using (StreamWriter writer = new StreamWriter(SavePathResist, true, Encoding.UTF8))
            {
                writer.Write("\r\n");
                writer.Write(partition);
                writer.Write("\r\n");
            }
        }
    }

    void ReturnMainBtnClick()
    {
        BckMainPanel.gameObject.SetActive(true);
        ResistSelfPanel.gameObject.SetActive(false);
        Player.SetActive(false);
        Beacon.SetActive(false);
        redpoint.SetActive(false);
        DynaLinkCore.StopSocket();
    }

    void EMStopBtnClick()
    {
        DynaLinkHS.CmdServoOff();
    }

    void ReturnMotionBtnClick()
    {
        float xPos;
        float yPos;
        Beacon.SetActive(true);
        OriX = trial[count, 2];
        OriY = trial[count, 3];
        xPos = OriX / ModulePara.TrgXPosScale - 900;
        yPos = OriY / ModulePara.TrgYPosScale - 270;
        Beacon.transform.localPosition = new Vector3(xPos, yPos, 0);

        float RedX;
        float RedY;
        redpoint.SetActive(true);
        DstX = trial[count, 4];
        DstY = trial[count, 5];
        RedX = DstX / ModulePara.TrgXPosScale - 900;
        RedY = DstY / ModulePara.TrgYPosScale - 270;
        redpoint.transform.localPosition = new Vector3(RedX, RedY, 0);

        DynaLinkHS.CmdLinePassive(OriX, OriY, 200000);
        print(OriX + "-" + OriY);
        running = false;
        music.Play();

    }
    void StopMotionBtnClick()
    {
        DynaLinkHS.CmdServoOff();
        running = false;

    }

    void ReleaseMotionBtnClick()
    {
        if (count < 10)
        {
            SavePathResist = outPath.text + "0" + count + ".csv";
        }
        else
        {
            SavePathResist = outPath.text + count + ".csv";
        }

        Trial.text = count.ToString();
        if(trial[count,1] == 0)
        {
            DynaLinkHS.CmdServoOff();
            print("off");
        }
        else
        {
            DynaLinkHS.CmdInertiaSim(trial[count, 6], trial[count, 7]);  //执行质量模式
            print(trial[count, 6] + "-" + trial[count, 7]);
        }
        print(trial[count, 0]);
        count++;
        running = true;
        music.Play();  
    }

    void ConnectEMGBtnClick()
    {
        DynaLinkCore.ConnectClick();
    }
}