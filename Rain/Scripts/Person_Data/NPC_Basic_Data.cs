using UnityEngine;

[System.Serializable]
public class NPC_Basic_Data{

    [Header("ㄎ一ㄤ指針")]
    public int K_Pointer;

    [Header("移動速度")]
    public float move_Speed;

    [Header("分數")]
    public float score;

    [Header("初始ㄎ一ㄤ指針")]
    public int origin_K_Pointer;
}

[System.Serializable]
public class Infected_Vars
{
    [Header("護盾當前值")]
    public float Shield_Current;

    [Header("傳單感染參數群")]
    public Flyer_Vars flyer_Vars = new Flyer_Vars();

    [Header("大聲公感染參數群")]
    public Loudly_Vars loudly_Vars = new Loudly_Vars();

    [Header("天線感染參數群")]
    public Antenna_Vars antenna_Vars = new Antenna_Vars();
}

[System.Serializable]
public class Flyer_Vars
{
    [Header("傳單感染最大值")]
    public float flyer_Infected_Max;

    [Header("傳單感染當前值")]
    public float flyer_Infected_Current;

    [Header("傳單感染倍率")]
    public float flyer_Magnification;

    [Header("傳單護盾值")]
    public float flyer_Shield;
}

[System.Serializable]
public class Loudly_Vars
{
    [Header("大聲公感染最大值")]
    public float loudly_Infected_Max;

    [Header("大聲公感染當前值")]
    public float loudly_Infected_Current;

    [Header("大聲公感染倍率")]
    public float loudly_Magnification;

    [Header("大聲公護盾值")]
    public float loudly_Shield;
}

[System.Serializable]
public class Antenna_Vars
{
    [Header("天線感染最大值")]
    public float antenna_Infected_Max;

    [Header("天線感染當前值")]
    public float antenna_Infected_Current;

    [Header("天線感染倍率")]
    public float antenna_Magnification;

    [Header("天線護盾值")]
    public float antenna_Shield;
}

[System.Serializable]
public class Recover_Vars
{
    [Header("回復時間最大值")]
    public float recover_Time_Max;

    [Header("回復時間當前值")]
    public float recover_Time_Current;
}

[System.Serializable]
public class Spread_Vars
{
    [Header("傳播方式指針")]
    public int spread_Method_Pointer;

    [Header("傳播冷卻最大值")]
    public float spread_CD_Max;

    [Header("傳播冷卻當前值")]
    public float spread_CD_Current;

    [Header("傳播預備")]
    public bool spread_Ready;
}