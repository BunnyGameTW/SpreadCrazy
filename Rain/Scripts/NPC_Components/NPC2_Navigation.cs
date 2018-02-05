using UnityEngine;

public class NPC2_Navigation : MonoBehaviour {

    [Header("NPC2資料")]
    public NPC2_Data npc2_Data;

    public Vector3 target_Tr = new Vector3();
    AnimationState ani;
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        Navigation();
    }

    public void Initialize()
    {
        npc2_Data = GetComponent<NPC2_Data>();
        target_Tr = new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(-13.0f, 13.0f), 0);
        //
        ani = GetComponent<AnimationState>();
    }

    public void Navigation()
    {
        if (target_Tr == null || Vector3.Distance(target_Tr, transform.position) <= 1f)
        {
            target_Tr = new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(-13.0f, 13.0f), -0.01f);
        }
        Vector3 direction = (target_Tr - transform.position).normalized;
        transform.Translate((target_Tr - transform.position).normalized * Time.deltaTime * npc2_Data.npc_Basic_Data.move_Speed ,Space.World);

        //
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0) ani.SetAniWalkSpeed(npc2_Data.npc_Basic_Data.move_Speed, 0);
            else ani.SetAniWalkSpeed(-npc2_Data.npc_Basic_Data.move_Speed, 0);
        }
        else
        {
            if (direction.y > 0) ani.SetAniWalkSpeed(0, npc2_Data.npc_Basic_Data.move_Speed);
            else ani.SetAniWalkSpeed(0, -npc2_Data.npc_Basic_Data.move_Speed);
        }
        //
    }
}
