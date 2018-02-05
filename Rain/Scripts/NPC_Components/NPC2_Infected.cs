using UnityEngine;
using System;

public class NPC2_Infected : MonoBehaviour {

    [Header("NPC1資料")]
    public NPC2_Data npc2_Data;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        npc2_Data = GetComponent<NPC2_Data>();
        npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Current = 0;
        npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Current = 0;
        npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Current = 0;
    }

    //玩家型
    public void Flyer_Infected(float K_Type)
    {
        //用盾擋
        if (npc2_Data.infected_Vars.Shield_Current > 0)
        {
            npc2_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc2_Data.infected_Vars.Shield_Current < 0)
            {
                npc2_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                += Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            if (npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                >= npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Max)
            {
                //套盾
                npc2_Data.infected_Vars.Shield_Current
                    += npc2_Data.infected_Vars.flyer_Vars.flyer_Shield;

                //轉換ㄎ一ㄤ狀態
                npc2_Data.npc_Basic_Data.K_Pointer = Convert.ToInt32(K_Type);

                //玩家加分
                GameObject.Find("GameManager").SendMessage("Add_Score", npc2_Data.npc_Basic_Data.score);

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Current = 0;
            }
        }
    }

    //NPC型
    public void Flyer_Infected_NPC(int K_Type)
    {
        //用盾擋
        if (npc2_Data.infected_Vars.Shield_Current > 0)
        {
            npc2_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc2_Data.infected_Vars.Shield_Current < 0)
            {
                npc2_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                += Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            if (npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Current
                >= npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Max)
            {
                //套盾
                npc2_Data.infected_Vars.Shield_Current
                    += npc2_Data.infected_Vars.flyer_Vars.flyer_Shield;

                //轉換ㄎ一ㄤ狀態
                npc2_Data.npc_Basic_Data.K_Pointer = K_Type;

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc2_Data.infected_Vars.flyer_Vars.flyer_Infected_Current = 0;
            }
        }
    }

    //玩家型
    public void Loudly_Infected(float K_Type)
    {
        //用盾擋
        if (npc2_Data.infected_Vars.Shield_Current > 0)
        {
            npc2_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc2_Data.infected_Vars.Shield_Current < 0)
            {
                npc2_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                += Time.deltaTime * npc2_Data.infected_Vars.loudly_Vars.loudly_Magnification;

            if (npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                >= npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Max)
            {
                //套盾
                npc2_Data.infected_Vars.Shield_Current
                    += npc2_Data.infected_Vars.loudly_Vars.loudly_Shield;

                //轉換ㄎ一ㄤ狀態
                npc2_Data.npc_Basic_Data.K_Pointer = Convert.ToInt32(K_Type);

                //玩家加分
                GameObject.Find("GameManager").SendMessage("Add_Score", npc2_Data.npc_Basic_Data.score);

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Current = 0;
            }
        }
    }

    //NPC型
    public void Loudly_Infected_NPC(int K_Type)
    {
        //用盾擋
        if (npc2_Data.infected_Vars.Shield_Current > 0)
        {
            npc2_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc2_Data.infected_Vars.Shield_Current < 0)
            {
                npc2_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                += Time.deltaTime * npc2_Data.infected_Vars.loudly_Vars.loudly_Magnification;

            if (npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Current
                >= npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Max)
            {
                //套盾
                npc2_Data.infected_Vars.Shield_Current
                    += npc2_Data.infected_Vars.loudly_Vars.loudly_Shield;

                //轉換ㄎ一ㄤ狀態
                npc2_Data.npc_Basic_Data.K_Pointer = K_Type;

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc2_Data.infected_Vars.loudly_Vars.loudly_Infected_Current = 0;
            }
        }
    }


    //玩家型
    public void Antenna_Infected(float K_Type)
    {
        //用盾擋
        if (npc2_Data.infected_Vars.Shield_Current > 0)
        {
            npc2_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc2_Data.infected_Vars.Shield_Current < 0)
            {
                npc2_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                += Time.deltaTime * npc2_Data.infected_Vars.antenna_Vars.antenna_Magnification;

            if (npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                >= npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Max)
            {
                //套盾
                npc2_Data.infected_Vars.Shield_Current
                    += npc2_Data.infected_Vars.antenna_Vars.antenna_Shield;

                //轉換ㄎ一ㄤ狀態
                npc2_Data.npc_Basic_Data.K_Pointer = Convert.ToInt32(K_Type);

                //玩家加分
                GameObject.Find("GameManager").SendMessage("Add_Score", npc2_Data.npc_Basic_Data.score);

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Current = 0;
            }
        }
    }

    //NPC型
    public void Antenna_InfectedNPC(int K_Type)
    {
        //用盾擋
        if (npc2_Data.infected_Vars.Shield_Current > 0)
        {
            npc2_Data.infected_Vars.Shield_Current
                -= Time.deltaTime * npc2_Data.infected_Vars.flyer_Vars.flyer_Magnification;

            //破盾
            if (npc2_Data.infected_Vars.Shield_Current < 0)
            {
                npc2_Data.infected_Vars.Shield_Current = 0;
            }
        }

        //沒盾
        else
        {
            npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                += Time.deltaTime * npc2_Data.infected_Vars.antenna_Vars.antenna_Magnification;

            if (npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Current
                >= npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Max)
            {
                //套盾
                npc2_Data.infected_Vars.Shield_Current
                    += npc2_Data.infected_Vars.antenna_Vars.antenna_Shield;

                //轉換ㄎ一ㄤ狀態
                npc2_Data.npc_Basic_Data.K_Pointer = K_Type;

                //回復計時
                gameObject.SendMessage("recover");

                //重製
                npc2_Data.infected_Vars.antenna_Vars.antenna_Infected_Current = 0;
            }
        }
    }
}
