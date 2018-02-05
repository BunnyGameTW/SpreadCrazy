using UnityEngine;

public class GM_Data : MonoBehaviour {

    [Header("ㄎ一ㄤ指數")]
    public float K_Score;

    [Header("ㄎ一ㄤ目標")]
    public float K_Target;

    [Header("人群變數群")]
    public Crowd_Vars crowdVars = new Crowd_Vars();
}

[System.Serializable]
public class Crowd_Vars
{
    [Header("NPC1數量")]
    public int npc1_Num;

    [Header("Npc2數量")]
    public int npc2_Num;
}