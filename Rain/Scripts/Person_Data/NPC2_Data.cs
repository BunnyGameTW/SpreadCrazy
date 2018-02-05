using UnityEngine;

public class NPC2_Data : MonoBehaviour {

    [Header("Npc基本參數")]
    public NPC_Basic_Data npc_Basic_Data = new NPC_Basic_Data();

    [Header("受感染參數群")]
    public Infected_Vars infected_Vars = new Infected_Vars();

    [Header("回復參數群")]
    public Recover_Vars recover_Vars = new Recover_Vars();

    [Header("傳播參數群")]
    public Spread_Vars spread_Vars = new Spread_Vars();

    [Header("碰撞體參數群")]
    public Npc2_Collider_Vars npc2_Collider_Vars = new Npc2_Collider_Vars();
}

[System.Serializable]
public class Npc2_Collider_Vars { }