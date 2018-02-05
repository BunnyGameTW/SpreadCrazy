using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_infection : MonoBehaviour
{

    //Transform imageTransform;

    //[SerializeField]
    //bool playerInput = true;

    public bool infection = false;

    [SerializeField]
    List<GameObject> EnterList = new List<GameObject>();

    Player_Data player_data;

    private void Start()
    {
        //imageTransform = transform.parent;
        player_data = transform.parent.GetComponent<Player_Data>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerInput == true)
        //{

        //    imageTransform.position += new Vector3(Input.GetAxis("Horizontal") * player_data.move_Speed, 0, 0);
        //    imageTransform.position += new Vector3(0, Input.GetAxis("Vertical") * player_data.move_Speed, 0);

        //}

        if (EnterList.Count != 0 && infection==true)
        {
            foreach (GameObject g in EnterList)
            {
                check_Spread_Method_Pointer_Sendmessage(g);
                
            }
        }

    }

    public void setInfection(bool _bool)
    {
        infection = _bool;
    }

    void check_Spread_Method_Pointer_Sendmessage(GameObject target)
    {
        //int sendInt = 0;
        switch (player_data.spread_Method_Pointer)
        {
            case 0:
                switch (player_data.K_Pointer)
                {
                    case 0:
                        target.SendMessage("Flyer_Infected", 0.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 1:
                        target.SendMessage("Flyer_Infected", 1.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 2:
                        target.SendMessage("Flyer_Infected", 2.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                }
                break;
            case 1:
                switch (player_data.K_Pointer)
                {
                    case 0:
                        target.SendMessage("Loudly_Infected", 0.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 1:
                        target.SendMessage("Loudly_Infected", 1.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 2:
                        target.SendMessage("Loudly_Infected", 2.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                }
                break;
            case 2:
                switch (player_data.K_Pointer)
                {
                    case 0:
                        target.SendMessage("Antenna_Infected", 0.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 1:
                        target.SendMessage("Antenna_Infected", 1.0f, SendMessageOptions.DontRequireReceiver);
                        break;
                    case 2:
                        target.SendMessage("Antenna_Infected", 2.0f, SendMessageOptions.DontRequireReceiver);
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
