using UnityEngine;

public class NPC1_Data : MonoBehaviour {

    [Header("Npc基本參數")]
    public NPC_Basic_Data npc_Basic_Data = new NPC_Basic_Data();

    [Header("受感染參數群")]
    public Infected_Vars infected_Vars = new Infected_Vars();

    [Header("回復參數群")]
    public Recover_Vars recover_Vars = new Recover_Vars();

    [Header("碰撞體參數群")]
    public Npc1_Collider_Vars npc1_Collider_Vars = new Npc1_Collider_Vars();
}

[System.Serializable]
public class Npc1_Collider_Vars { }