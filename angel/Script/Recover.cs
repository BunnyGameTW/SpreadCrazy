using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour {
    //float _time;
    public float recoverTime=10;

    WaitForSeconds waitRecoverTime;

    NPC1_Data npc1_Data;
    NPC2_Data npc2_Data;

    // Use this for initialization
    void Start () {
        //_time = 0;
        //recoverTime = 1;
        waitRecoverTime = new WaitForSeconds(recoverTime);
        //get data state
        if (gameObject.GetComponent<NPC1_Data>() == true)
        {
            npc1_Data = gameObject.GetComponent<NPC1_Data>();
        }
        else if(gameObject.GetComponent<NPC2_Data>()==true)
        {
            npc2_Data = gameObject.GetComponent<NPC2_Data>();
        }         
    }
	
	// Update is called once per frame
	//void Update () {
		
	//}

    void recover() {
        StartCoroutine(timer());
    }

    IEnumerator timer() {
        //_time += Time.deltaTime;
        yield return waitRecoverTime;
        //if (_time > recoverTime) {//回復普通狀態
        //    _time = 0;
        //int _state;
        //_state = 3;
        //set data state
        if (npc1_Data != null)
        {
            npc1_Data.npc_Basic_Data.K_Pointer = npc1_Data.npc_Basic_Data.origin_K_Pointer;
        }
        else if (npc2_Data != null)
        {
            npc2_Data.npc_Basic_Data.K_Pointer = npc2_Data.npc_Basic_Data.origin_K_Pointer;
        }


        }
    }

