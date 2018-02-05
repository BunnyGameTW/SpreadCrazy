using UnityEngine;

public class NPC1_States : MonoBehaviour {

    [Header("NPC1資料")]
    public NPC1_Data npc1_Data;

    [Header("動畫組件")]
    public Animator ani;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        NPC1_State_Machine();
    }

    public void Initialize()
    {
        npc1_Data = GetComponent<NPC1_Data>();
        ani = GetComponent<Animator>();
    }

    public void NPC1_State_Machine()
    {
        switch (npc1_Data.npc_Basic_Data.K_Pointer)
        {
            case 0:
                ani.SetInteger("i_State", 1);
                break;
            case 1:
                ani.SetInteger("i_State", 2);
                break;
            case 2:
                ani.SetInteger("i_State", 3);
                break;
            case 3:
                ani.SetInteger("i_State", 0);
                break;
        }
    }
}
