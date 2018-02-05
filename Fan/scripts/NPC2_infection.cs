using System.Collections.Generic;
using UnityEngine;

public class NPC2_infection : MonoBehaviour
{

    [SerializeField]
    List<GameObject> EnterList = new List<GameObject>();

    [Header("NPC2資料")]
    public NPC2_Data npc2_Data;

    private void Start()
    {
        Initialize();        
    }

    public void Initialize()
    {
        npc2_Data = transform.parent.GetComponent<NPC2_Data>();
        npc2_Data.spread_Vars.spread_CD_Current = npc2_Data.spread_Vars.spread_CD_Max;
        npc2_Data.spread_Vars.spread_Ready = false;
    }

    // Update is called once per frame
    void Update()
    {
        npc2_Data.spread_Vars.spread_CD_Current -= Time.deltaTime;
        if (npc2_Data.spread_Vars.spread_CD_Current < 0)
        {
            npc2_Data.spread_Vars.spread_CD_Current = npc2_Data.spread_Vars.spread_CD_Max;
            npc2_Data.spread_Vars.spread_Ready = true;
        }

        if (EnterList.Count != 0 && npc2_Data.spread_Vars.spread_Ready)
        {
            foreach (GameObject g in EnterList)
            {
                //check_Spread_Method_Pointer_Sendmessage(g);

                if (g.GetComponent<NPC1_Data>() != null)
                {
                    switch (npc2_Data.spread_Vars.spread_Method_Pointer)
                    {
                        case 0:
                            g.GetComponent<NPC1_Data>().infected_Vars.flyer_Vars.flyer_Infected_Current += g.GetComponent<NPC1_Data>().infected_Vars.flyer_Vars.flyer_Infected_Max;
                            break;
                        case 1:
                            g.GetComponent<NPC1_Data>().infected_Vars.loudly_Vars.loudly_Infected_Current += g.GetComponent<NPC1_Data>().infected_Vars.loudly_Vars.loudly_Infected_Max;
                            break;
                        case 2:
                            g.GetComponent<NPC1_Data>().infected_Vars.antenna_Vars.antenna_Infected_Current += g.GetComponent<NPC1_Data>().infected_Vars.antenna_Vars.antenna_Infected_Max;
                            break;
                    }
                    check_Spread_Method_Pointer_Sendmessage(g);
                }
                else if(g.GetComponent<NPC2_Data>() != null)
                {
                    switch (npc2_Data.spread_Vars.spread_Method_Pointer)
                    {
                        case 0:
                            g.GetComponent<NPC2_Data>().infected_Vars.flyer_Vars.flyer_Infected_Current += g.GetComponent<NPC2_Data>().infected_Vars.flyer_Vars.flyer_Infected_Max;
                            break;
                        case 1:
                            g.GetComponent<NPC2_Data>().infected_Vars.loudly_Vars.loudly_Infected_Current += g.GetComponent<NPC2_Data>().infected_Vars.loudly_Vars.loudly_Infected_Max;
                            break;
                        case 2:
                            g.GetComponent<NPC2_Data>().infected_Vars.antenna_Vars.antenna_Infected_Current += g.GetComponent<NPC2_Data>().infected_Vars.antenna_Vars.antenna_Infected_Max;
                            break;
                    }
                    check_Spread_Method_Pointer_Sendmessage(g);
                }
                g.SendMessage("Flyer_Infected_NPC", 0, SendMessageOptions.DontRequireReceiver);
                npc2_Data.spread_Vars.spread_Ready = false;
            }
        }
    }
    //NPC型
    void check_Spread_Method_Pointer_Sendmessage(GameObject target)
    {
        //int sendInt = 0;
        switch (npc2_Data.spread_Vars.spread_Method_Pointer)
        {
            case 0:
                switch (npc2_Data.npc_Basic_Data.K_Pointer)
                {
                    case 0:
                        target.SendMessage("Flyer_Infected_NPC", 0, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 1:
                        target.SendMessage("Flyer_Infected_NPC", 1, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 2:
                        target.SendMessage("Flyer_Infected_NPC", 2, SendMessageOptions.DontRequireReceiver);
                        break;
                }
                break;
            case 1:
                switch (npc2_Data.npc_Basic_Data.K_Pointer)
                {
                    case 0:
                        target.SendMessage("Loudly_Infected_NPC", 0, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 1:
                        target.SendMessage("Loudly_Infected_NPC", 1, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 2:
                        target.SendMessage("Loudly_Infected_NPC", 2, SendMessageOptions.DontRequireReceiver);
                        break;
                }
                break;
            case 2:
                switch (npc2_Data.npc_Basic_Data.K_Pointer)
                {
                    case 0:
                        target.SendMessage("Antenna_Infected_NPC", 0, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 1:
                        target.SendMessage("Antenna_Infected_NPC", 1, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 2:
                        target.SendMessage("Antenna_Infected_NPC", 2, SendMessageOptions.DontRequireReceiver);
                        break;
                }
                break;
        }
    }

    //void check_KTypeAndSeedmessage(int sendInt, GameObject target)
    //{
    //    switch (player_data.spread_Method_Pointer)
    //    {
    //        case 0:
    //            sendInt +=0;
    //            target.SendMessage("Flyer_Infected", sendInt, SendMessageOptions.DontRequireReceiver);
    //            break;
    //        case 1:
    //            sendInt += 1;
    //            target.SendMessage("Loudly_Infected", sendInt, SendMessageOptions.DontRequireReceiver);
    //            break;
    //        case 2:
    //            sendInt += 2;
    //            target.SendMessage("Antenna_Infected", sendInt, SendMessageOptions.DontRequireReceiver);
    //            break;
    //    }
    //}

        private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Coll enter /" + collision.gameObject.name);
        if (collision.transform.CompareTag("NPC"))
        {
            EnterList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("Coll exit /" + collision.gameObject.name);
        if (collision.transform.CompareTag("NPC"))
        {
            EnterList.Remove(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      //
    }
}
