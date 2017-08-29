using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DLMotion;
using System.IO;
using System.Text;

public class TxtWrite : MonoBehaviour {

    // Use this for initialization
    public static ArrayList TCPData_list;
    public Button SaveDataBtn;

    // Use this for initialization
    void Start()
    {
        TCPData_list = new ArrayList();
        SaveDataBtn.onClick.AddListener(SaveDataBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SaveDataBtnClick()
    {
        //ADC1数据写入
        FileStream fs1 = File.Open(@"d:\SciRecData\TCPTestData.txt", FileMode.Create);
        StreamWriter wr1 = new StreamWriter(fs1);
        for (int i = 0; i < TCPData_list.Count; i++)
        {

            wr1.WriteLine(TCPData_list[i]);
        }
        wr1.Flush();
        wr1.Close();
    }
}
