using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_UpUi : MonoBehaviour
{
    [SerializeField]
    Canvas[] nonCan;

    [SerializeField]
    Canvas can;

    [SerializeField]
    Camera cam;
    scr_Noise noise;

    [SerializeField]
    Text[] tex;

    [SerializeField]
    Image[] ima;

    [SerializeField]
    Button but;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 180;
        noise=cam.GetComponent<scr_Noise>();
        can.scaleFactor = 0;
        but.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (noise.thisEx)
        {
            time--;
            if (time < 0)
            {
                AllDEstroy();
                if (nonCan[0])
                {
                    nonCan[0].enabled = false;
                }
                else if (!nonCan[0]){
                    nonCan[1].enabled = false;
                }
                can.scaleFactor += 0.01f;
                if (can.scaleFactor > 1)
                {
                    can.scaleFactor = 1;
                    if (ima[0].rectTransform.position.y < 1650)
                    {
                        for (int i = 0; i < tex.Length; i++)
                        {
                            tex[i].rectTransform.position = new Vector3(tex[i].rectTransform.position.x, tex[i].rectTransform.position.y + 5f, tex[i].rectTransform.position.z);
                        }
                        for (int j = 0; j < ima.Length - 1; j++)
                        {
                            ima[j].rectTransform.position = new Vector3(ima[j].rectTransform.position.x, ima[j].rectTransform.position.y + 5f, ima[j].rectTransform.position.z);
                        }
                    }
                    else
                    {
                        ima[2].color = new Color(1, 1, 1, ima[2].color.a + 0.01f);
                        but.enabled = true;
                    
                    }

                }
            }
        }
    }


    void AllDEstroy()
    {
        GameObject[] des = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] des1 = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in des)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in des1)
        {
            Destroy(obj);
        }
    }
}
