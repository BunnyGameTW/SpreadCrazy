using UnityEngine;

public class Player_Initialize : MonoBehaviour {

    [Header("玩家資料")]
    public Player_Data player_Data;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        player_Data = GetComponent<Player_Data>();
        player_Data.spread_Method_Pointer = 0;
        GetComponent<Animator>().SetInteger("i_State", player_Data.spread_Method_Pointer);
    }
}
