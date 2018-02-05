using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public Image bg;
    public Image flyer;
    public Image loudly;
    public Image antenna;
    public Image frame;

    public Image Kframe;
    public Image Ksource;

    public GM_Data gm_Data;

    PlayableDirector end;

    public Text timeText;
    public Text endTimeText;
    float time;
    bool timeup=false;
    public float Waittime=120;
    WaitForSeconds wait;
    //public int type = 0;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        gm_Data = GameObject.Find("GameManager").GetComponent<GM_Data>();
        end=GetComponent<PlayableDirector>();
        wait = new WaitForSeconds(Waittime);
    }

    private void Update()
    {       
        if (timeup==true)
        {
            //playEnd();
        }
        else
        {
            time += Time.deltaTime;
            timeText.text = time.ToString("0.0");
        }
        //changeKsource();
        //changeSpreadMethod(type);
    }

    public void changeSpreadMethod(int type)
    {
        switch (type)
        {
            case 0:
                frame.transform.position = flyer.transform.position;
                break;
            case 1:
                frame.transform.position = loudly.transform.position;
                break;
            case 2:
                frame.transform.position = antenna.transform.position;
                break;
        }
    }

    public void changeKsource()
    {
        Ksource.fillAmount = GameObject.Find("GameManager").GetComponent<GM_Data>().K_Score / GameObject.Find("GameManager").GetComponent<GM_Data>().K_Target;
    }

   void playEnd()
    {
        timeup = true;
        endTimeText.text = time.ToString("0.0");
        end.Play();

        StartCoroutine(loadfirtscrene());
    }

    IEnumerator loadfirtscrene()
    {
        yield return wait;
        SceneManager.LoadScene(0);
    }
}
