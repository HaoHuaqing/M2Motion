using UnityEngine;
using System.Collections;

public class LoadBeacon : MonoBehaviour
{

    public Vector3 pos;
    public GameObject TrgBeacon;
    public float[] beaconPosX = new float[2];
    public float[] beaconPosY = new float[2];
    int i;
    int _delay;
    public float _distance;
    Transform newParent;
    // Use this for initialization
    void Start()
    {
        i = 0;
        newParent = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_delay <= 20)
        {
            _delay++;
        }
        if (_delay > 20)
        {
            _delay = 0;
            if (i <= 1)
            {
                beaconPosX[i] = MainTrgCapture.Tx;
                beaconPosY[i] = MainTrgCapture.Ty;
                i++;
            }
        }

        if (i > 1)
        {
            _distance = Mathf.Sqrt(Mathf.Pow((beaconPosX[1] - beaconPosX[0]), 2) + Mathf.Pow((beaconPosY[1] - beaconPosY[0]), 2));
            i = 0;
        }

        if (_distance >= 5)
        {
            pos = this.gameObject.transform.localPosition;
            //Object aaa= Instantiate(TrgBeacon,pos,Quaternion.identity);
            //GameObject bbb = aaa as GameObject;

            GameObject child = Instantiate<GameObject>(TrgBeacon);
            child.transform.SetParent(newParent, true);
            child.transform.localPosition = pos;
            //_distance = 0;
        }
        
    }

}
