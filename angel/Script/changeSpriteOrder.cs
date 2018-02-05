using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSpriteOrder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        changeOrder();

    }
    public void changeOrder() {
        int num = 0;
        int chNum = 0;
        List<float[]> charPosY = new List<float[]>();
        GameObject[] gos =FindObjectsOfType<GameObject>(); //will return an array of all GameObjects in the scene
        foreach (GameObject go in gos)
        {
            //Debug.Log(go.layer.ToString());
            if (go.layer == 8)
            {            
                float[] tmp = new float[2];
                tmp[0] = go.transform.position.y; tmp[1] = num;       
                charPosY.Add(tmp);
                chNum++;
            }
            num++;
        }
      
      
        for (int i = 0; i < chNum; i++) {
            int min = i;           
            for (int j = i + 1; j < chNum; j++)
            {
                if (charPosY[j][0] < charPosY[min][0])// 5,0 1,1 2 4 3
                    min = j;
            }
            if (i != min) {//最小值
                float[] t = charPosY[i];
                charPosY[i] = charPosY[min];
                charPosY[min] = t;
            }
        }

        for (int i = 0; i < num-1; i++)
        {
            for (int j = 0; j < chNum; j++) {
                if (charPosY[j][1] == i ) {
                    gos[i].GetComponent<SpriteRenderer>().sortingOrder = chNum - j;
                   // Debug.Log("123");
            }
            }
        }
    }
}
