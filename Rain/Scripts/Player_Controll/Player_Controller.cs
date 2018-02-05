using UnityEngine;

public class Player_Controller : MonoBehaviour {

    [Header("玩家資料")]
    public Player_Data player_Data;

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Initialize()
    {
        player_Data = GetComponent<Player_Data>();
    }

    public void Movement()
    {
        if (Input.GetAxis("Horizontal") != 0) transform.Translate(Vector3.forward 
                                                                * Input.GetAxis("Horizontal") 
                                                                * player_Data.move_Speed, Space.World);
        if (Input.GetAxis("Vertical") != 0) transform.Translate(Vector3.right 
                                                              * Input.GetAxis("Vertical")
                                                              * player_Data.move_Speed, Space.World);
    }

    //選擇傳染方式
    void chooseWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            player_Data.spread_Method_Pointer = (player_Data.spread_Method_Pointer + 1) % 3;
            Debug.Log("CHANGE");
            GetComponent<Animator>().SetInteger("i_State", player_Data.spread_Method_Pointer);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            player_Data.spread_Method_Pointer = (player_Data.spread_Method_Pointer + 2) % 3;
            GetComponent<Animator>().SetInteger("i_State", player_Data.spread_Method_Pointer);
        } 
    }


}
