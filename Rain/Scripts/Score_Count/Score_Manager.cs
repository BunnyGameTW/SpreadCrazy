using UnityEngine;

public class Score_Manager : MonoBehaviour {

    [Header("GM資料")]
    public GM_Data gm_Data;

    [Header("UI")]
    public GameObject ui;




    private void Start()
    {
        Initialize();
        ui.gameObject.SendMessage("changeKsource", gm_Data.K_Score, SendMessageOptions.DontRequireReceiver);
    }

    private void Update()
    {
        Target_Acheive_Detect();
    }

    public void Initialize()
    {
        gm_Data = GetComponent<GM_Data>();
    }

    public void Add_Score(float score)
    {
        gm_Data.K_Score += score;
        ui.gameObject.SendMessage("changeKsource",SendMessageOptions.DontRequireReceiver);
    }

    public void Target_Acheive_Detect()
    {
        if(gm_Data.K_Score >= gm_Data.K_Target)
        {
            ui.gameObject.SendMessage("playEnd");
        }
    }
}
