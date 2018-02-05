using System;
using UnityEngine;

public class NPC1_Infected : MonoBehaviour {

    [Header("NPC1資料")]
    public NPC1_Data npc1_Data;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        npc1_Data = GetComponent<NPC1_Data>();
    }

    //玩家型
    public void Flyer_Infected(float K_Type)
    {
        Debug.Log("test2");

        //用盾擋
        if (npc1_Data.infected_Vars.Shield_Current > 0)
        {
            npc1_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc1_Data.infected_Vars.Shield_Current < 0)
            {
                npc1_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                += Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            if (npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                >= npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Max)
            {
                //套盾
                npc1_Data.infected_Vars.Shield_Current
                    += npc1_Data.infected_Vars.flyer_Vars.flyer_Shield;

                //轉換ㄎ一ㄤ狀態
                npc1_Data.npc_Basic_Data.K_Pointer = Convert.ToInt32(K_Type);

                //玩家加分
                GameObject.Find("GameManager").SendMessage("Add_Score", npc1_Data.npc_Basic_Data.score);

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Current = 0;
            }
        }
    }

    //NPC型
    public void Flyer_Infected_NPC(int K_Type)
    {
        //用盾擋
        if (npc1_Data.infected_Vars.Shield_Current > 0)
        {
            npc1_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc1_Data.infected_Vars.Shield_Current < 0)
            {
                npc1_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                += Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            if (npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                >= npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Max)
            {
                Debug.Log("Test");

                //套盾
                npc1_Data.infected_Vars.Shield_Current
                    += npc1_Data.infected_Vars.flyer_Vars.flyer_Shield;

                //轉換ㄎ一ㄤ狀態
                npc1_Data.npc_Basic_Data.K_Pointer = Convert.ToInt32(K_Type);

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc1_Data.infected_Vars.flyer_Vars.flyer_Infected_Current = 0;
            }
        }
    }

    //玩家型
    public void Loudly_Infected(float K_Type)
    {
        //用盾擋
        if (npc1_Data.infected_Vars.Shield_Current > 0)
        {
            npc1_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc1_Data.infected_Vars.Shield_Current < 0)
            {
                npc1_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                += Time.deltaTime * npc1_Data.infected_Vars.loudly_Vars.loudly_Magnification;

            if (npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                >= npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Max)
            {
                Debug.Log("Test0");

                //套盾
                npc1_Data.infected_Vars.Shield_Current
                    += npc1_Data.infected_Vars.loudly_Vars.loudly_Shield;

                //轉換ㄎ一ㄤ狀態
                npc1_Data.npc_Basic_Data.K_Pointer = Convert.ToInt32(K_Type);

                //玩家加分
                GameObject.Find("GameManager").SendMessage("Add_Score", npc1_Data.npc_Basic_Data.score);

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Current = 0;
            }
        }
    }

    //NPC型
    public void Loudly_Infected_NPC(int K_Type)
    {
        //用盾擋
        if (npc1_Data.infected_Vars.Shield_Current > 0)
        {
            npc1_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc1_Data.infected_Vars.Shield_Current < 0)
            {
                npc1_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                += Time.deltaTime * npc1_Data.infected_Vars.loudly_Vars.loudly_Magnification;

            if (npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                >= npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Max)
            {
                //套盾
                npc1_Data.infected_Vars.Shield_Current
                    += npc1_Data.infected_Vars.loudly_Vars.loudly_Shield;

                //轉換ㄎ一ㄤ狀態
                npc1_Data.npc_Basic_Data.K_Pointer = K_Type;

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc1_Data.infected_Vars.loudly_Vars.loudly_Infected_Current = 0;
            }
        }
    }

    //玩家型
    public void Antenna_Infected(float K_Type)
    {
        //用盾擋
        if (npc1_Data.infected_Vars.Shield_Current > 0)
        {
            npc1_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc1_Data.infected_Vars.Shield_Current < 0)
            {
                npc1_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                += Time.deltaTime * npc1_Data.infected_Vars.antenna_Vars.antenna_Magnification;

            if (npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                >= npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Max)
            {
                //套盾
                npc1_Data.infected_Vars.Shield_Current
                    += npc1_Data.infected_Vars.antenna_Vars.antenna_Shield;

                //轉換ㄎ一ㄤ狀態
                npc1_Data.npc_Basic_Data.K_Pointer = Convert.ToInt32(K_Type);

                //玩家加分
                GameObject.Find("GameManager").SendMessage("Add_Score", npc1_Data.npc_Basic_Data.score);

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Current = 0;
            }
        }
    }

    //NPC型
    public void Antenna_Infected_NPC(int K_Type)
    {
        //用盾擋
        if (npc1_Data.infected_Vars.Shield_Current > 0)
        {
            npc1_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc1_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc1_Data.infected_Vars.Shield_Current < 0)
            {
                npc1_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                += Time.deltaTime * npc1_Data.infected_Vars.antenna_Vars.antenna_Magnification;

            if (npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                >= npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Max)
            {
                //套盾
                npc1_Data.infected_Vars.Shield_Current
                    += npc1_Data.infected_Vars.antenna_Vars.antenna_Shield;

                //轉換ㄎ一ㄤ狀態
                npc1_Data.npc_Basic_Data.K_Pointer = K_Type;

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc1_Data.infected_Vars.antenna_Vars.antenna_Infected_Current = 0;
            }
        }
    }
}
