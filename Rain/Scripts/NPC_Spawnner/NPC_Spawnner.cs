using UnityEngine;
using System.Collections.Generic;

public class NPC_Spawnner : MonoBehaviour {

    [Header("GM資料")]
    public GM_Data gm_Data;

    [Header("生成點軸心")]
    public List<Transform> npc_Spawn_Trs;

    [Header("NPC1")]
    public GameObject NPC1;

    [Header("NPC2")]
    public GameObject NPC2;

    [Header("動畫控制器們")]
    public Animator ani;

    private void Start()
    {
        Initialize();
        Spawn_NPC();
    }

    public void Initialize()
    {
        gm_Data = GetComponent<GM_Data>();
        Get_Spawn_Tr();
    }

    public void Get_Spawn_Tr()
    {
        for(int i=0;i< gm_Data.crowdVars.npc1_Num + gm_Data.crowdVars.npc2_Num;i++)
        {
            npc_Spawn_Trs.Add(transform.Find("Spawn_Trs").transform.GetChild(i));
        }
    }

    public void Spawn_NPC()
    {
        if (gm_Data.crowdVars.npc1_Num + gm_Data.crowdVars.npc2_Num <= 0) return;

        //隨機選擇NPC生成
        int Select_NPC_ID = Random.Range(0, 2);
        if (gm_Data.crowdVars.npc1_Num <= 0) Select_NPC_ID = 1;
        if (gm_Data.crowdVars.npc2_Num <= 0) Select_NPC_ID = 0;

        //判斷並生成NPC
        if (Select_NPC_ID == 0)
        {
            GameObject new_NPC1 = Instantiate(NPC1, npc_Spawn_Trs[0].position, npc_Spawn_Trs[0].rotation);
            npc_Spawn_Trs.Remove(npc_Spawn_Trs[0]);
            gm_Data.crowdVars.npc1_Num -= 1;

            ani = new_NPC1.GetComponent<Animator>();
            int NPC_Type = Random.Range(0, 5);
            switch (NPC_Type)
            {
                case 0:
                    ani.runtimeAnimatorController = Resources.Load("Woman") as RuntimeAnimatorController;
                    break;
                case 1:
                    ani.runtimeAnimatorController = Resources.Load("woman3") as RuntimeAnimatorController;
                    break;
                case 2:
                    ani.runtimeAnimatorController = Resources.Load("woman_green") as RuntimeAnimatorController;
                    break;
                case 3:
                    ani.runtimeAnimatorController = Resources.Load("man") as RuntimeAnimatorController;
                    break;
                case 4:
                    ani.runtimeAnimatorController = Resources.Load("girl") as RuntimeAnimatorController;
                    break;
            }
            Spawn_NPC();
            return;
        }
        else
        {
            int new_NPC2_K_Type = Random.Range(0, 3);
            GameObject new_NPC2 = Instantiate(NPC2, npc_Spawn_Trs[0].position, npc_Spawn_Trs[0].rotation);
            new_NPC2.GetComponent<Animator>().SetBool("isWalk", false);
            new_NPC2.GetComponent<Animator>().SetInteger("i_State", new_NPC2_K_Type);
            new_NPC2.GetComponent<Animator>().SetBool("isWalk", true);
            Debug.Log(new_NPC2.GetComponent<Animator>().GetInteger("i_State"));
            new_NPC2.GetComponent<NPC2_Data>().npc_Basic_Data.K_Pointer = new_NPC2_K_Type;
            npc_Spawn_Trs.Remove(npc_Spawn_Trs[0]);
            gm_Data.crowdVars.npc2_Num -= 1;

            ani = new_NPC2.GetComponent<Animator>();
            int NPC_Type = Random.Range(0, 2);
            switch (NPC_Type)
            {
                case 0:
                    ani.runtimeAnimatorController = Resources.Load("old") as RuntimeAnimatorController;
                    break;
                case 1:
                    ani.runtimeAnimatorController = Resources.Load("black") as RuntimeAnimatorController;
                //    new_NPC2.transform.localScale -= new Vector3(1f, 1f, 0);
                    
                    break;
            }

            Spawn_NPC();
            return;
        }
    }
}