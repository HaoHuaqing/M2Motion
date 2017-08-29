using UnityEngine;
using System.Collections;
using DLMotion;
public class MainTrgCapture : MonoBehaviour {

    public static float Tx;
    public static float Ty;

    // Use this for initialization    
    void Awake()
    {
        
    }
    void Start ()
    {
       
    }

    void FixedUpdate()
    {
        MainTrgMov();
        //KeyBoardMove();
    }
    // Update is called once per frame
    void Update ()
    {
        
    }

    void MainTrgMov()
    {
        //Vector3 move = Vector3.zero;
        Tx = DynaLinkHS.StatusMotRT.PosDataJ1 / ModulePara.TrgXPosScale-900;
        Ty = DynaLinkHS.StatusMotRT.PosDataJ2 / ModulePara.TrgYPosScale-300;
        transform.localPosition = new Vector3(Tx, Ty, 0);

    }

    void KeyBoardMove()
    {
        int speed = 4;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

    }

}
