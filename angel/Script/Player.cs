using UnityEngine;

//<<<<<<< HEAD
//public class Player : MonoBehaviour
//{
//    public int _weaponType = 0;
//    AnimationState ani;
//    public float speed;
//    Player_Data data;
//    Use this for initialization

//   void Start () {

//       ani = GetComponent<AnimationState>();
//=======
public class Player : MonoBehaviour
{

    public AnimationState ani;

    public Player_Data player_Data;

    public GameObject ui;

    Player_infection _playerInfection;

    void Start()
    {
        ani = GetComponent<AnimationState>();
        //>>>>>>> 4be0d89d016d804b82741faeedc0acf419ade1eb
        player_Data = GetComponent<Player_Data>();
        _playerInfection = GetComponentInChildren<Player_infection>();
    }

    // Update is called once per frame
    void Update()
    {
        control();
        chooseWeapon();
        spread();
    }
    //走路
    void control()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, player_Data.move_Speed * Time.deltaTime, 0);
           ani.animationBehavior(player_Data, 0, player_Data.move_Speed);
            ani.setBool("isWalk", true);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -player_Data.move_Speed * Time.deltaTime, 0);
            ani.animationBehavior(player_Data, 0, -player_Data.move_Speed);
            ani.setBool("isWalk", true);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-player_Data.move_Speed * Time.deltaTime, 0, 0);
            ani.animationBehavior(player_Data, -player_Data.move_Speed, 0);
            ani.setBool("isWalk", true);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(player_Data.move_Speed * Time.deltaTime, 0, 0);
            ani.animationBehavior(player_Data, player_Data.move_Speed, 0);
            ani.setBool("isWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            ani.setBool("isWalk", false);
        }
    }
    //選擇傳染方式
    void chooseWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            player_Data.spread_Method_Pointer = (player_Data.spread_Method_Pointer + 1) % 3;
            GetComponent<Animator>().SetInteger("i_State", player_Data.spread_Method_Pointer);
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            player_Data.spread_Method_Pointer = (player_Data.spread_Method_Pointer + 2) % 3;
            GetComponent<Animator>().SetInteger("i_State", player_Data.spread_Method_Pointer);
        } 
        ui.gameObject.SendMessage("changeSpreadMethod", player_Data.spread_Method_Pointer, SendMessageOptions.DontRequireReceiver);
    }

    void spread()
    {
        _playerInfection.setInfection(Input.GetMouseButton(0));
        //print(Input.GetMouseButton(0));

        //switch (_weaponType)
        //{
        //    case 0:
        //      //  other.infect();//call others infection function
        //        break;
        //    case 1:
        //        break;
        //    case 2:
        //        break;
        //    case 3:
        //        break;
        //}


    }
}
