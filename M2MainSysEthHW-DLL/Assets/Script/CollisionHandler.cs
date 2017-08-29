using System;
using UnityEngine;
using System.Collections;
using DLMotion;

public class CollisionHandler : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        //CollYN = GameObject.Find("/Sphere-Player/Cube-Collision-Y");
        //Debug.Log(CollYN);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //not use this funtion in this project
    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Collision object name：" + collider.gameObject.name);

    }
    
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Triggle Active Collider：" + collider.gameObject.name);
        if (collider.gameObject.name == "CollisionYP-CCW")
        {
            //Debug.Log("Trig：CollisionYP_CCW");
            DynaLinkHS.CmdYColliderSetCcw(0x01);
        
        }
        else if (collider.gameObject.name == "CollisionYN-CW")
        {
            //Debug.Log("Trig：CollisionYN_CW");
            DynaLinkHS.CmdYColliderSetCw(0x01);
       
        }
        else if (collider.gameObject.name == "CollisionXP-CCW")
        {
            //Debug.Log("Trig：CollisionXP_CCW");
            DynaLinkHS.CmdXColliderSetCcw(0x01);
     
        }
        else if (collider.gameObject.name == "CollisionXN-CW")
        {
            //Debug.Log("Trig：CollisionXN_CW");
            DynaLinkHS.CmdXColliderSetCw(0x01);

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log("Triggle Exit Collider：" + collider.gameObject.name);
        
        if (collider.gameObject.name == "CollisionYP-CCW")
        {
            //Debug.Log("Exit：CollisionYP_CCW");
            DynaLinkHS.CmdYColliderSetCcw(0x00);
            DynaLinkHS.CmdYColliderSetCcw(0x00);
        }
        else if (collider.gameObject.name == "CollisionYN-CW")
        {
            //Debug.Log("Exit：CollisionYN_CW");
            DynaLinkHS.CmdYColliderSetCw(0x00);
            DynaLinkHS.CmdYColliderSetCw(0x00);
        }
        else if (collider.gameObject.name == "CollisionXP-CCW")
        {
            //Debug.Log("Exit：CollisionXP_CCW");
            DynaLinkHS.CmdXColliderSetCcw(0x00);
            DynaLinkHS.CmdXColliderSetCcw(0x00);
        }
        else if (collider.gameObject.name == "CollisionXN-CW")
        {
            //Debug.Log("Exit：CollisionXN_CW");
            DynaLinkHS.CmdXColliderSetCw(0x00);
            DynaLinkHS.CmdXColliderSetCw(0x00);
        }        
    }
 }
