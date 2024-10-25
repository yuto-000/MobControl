using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ClearUI : MonoBehaviour
{
    [SerializeField]
    Canvas nonCan;

    [SerializeField]
    Canvas can;


    [SerializeField]
    GameObject[] enemy;

    scr_EnemyHP HP;

    [SerializeField]
    Text[] tex;

    [SerializeField]
    Image[] ima;

    [SerializeField]
    Button but;

    [SerializeField]
    [Tooltip("ステージ数")]
    int StageNum=1;

    [SerializeField]
     public GameObject slider=null;
    public bool MoveChack = false;
    // Start is called before the first frame update
    void Start()
    {
        HP = enemy[0].GetComponent<scr_EnemyHP>();
        can.scaleFactor = 0;
        but.enabled = false;
        
        if (slider) {
            slider.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.hp < 1 && StageNum == 1)
        {

            nonCan.enabled = false;
            can.scaleFactor += 0.01f;

            if (can.scaleFactor > 1)
            {
                AllDEstroy();
                can.scaleFactor = 1;
                if (ima[0].rectTransform.position.y < 1650)
                {
                    for (int i = 0; i < tex.Length; i++)
                    {
                        tex[i].rectTransform.position = new Vector3(tex[i].rectTransform.position.x, tex[i].rectTransform.position.y + 5f, tex[i].rectTransform.position.z);
                    }
                    for (int j = 0; j < ima.Length; j++)
                    {
                        ima[j].rectTransform.position = new Vector3(ima[j].rectTransform.position.x, ima[j].rectTransform.position.y + 5f, ima[j].rectTransform.position.z);
                    }
                }
                else
                {
                    but.enabled = true;
                }

            }
        }
        else if(HP.hp < 1 && StageNum == 2) {
            HP = enemy[1].GetComponent<scr_EnemyHP>();
            StageNum--;
            MoveChack = true;
            DEstroy();
        }
        
    }


    void AllDEstroy()
    {
        GameObject[] des = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in des)
        {
            Destroy(obj);
        }
    }
    void DEstroy()
    {
        GameObject[] des = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] des1 = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] des2 = GameObject.FindGameObjectsWithTag("Range");
        GameObject[] des3 = GameObject.FindGameObjectsWithTag("Delete");

        foreach (GameObject obj in des)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in des1)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in des2)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in des3)
        {
            Destroy(obj);
        }
    }
}
