using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class scr_StageMove : MonoBehaviour
{
    [SerializeField]
    Canvas Can;

    [SerializeField]
    Camera Cam;

    [SerializeField]
    GameObject EnemyCastle;

    scr_EnemyShot EnemyAttack;

    private Vector3 offset;

    scr_ClearUI Stage;

    scr_Shot Shot;

    Vector3 nowPos;

    bool OK = false;

    [SerializeField]
    GameObject Target;

    

    // Start is called before the first frame update
    void Start()
    {
        EnemyAttack = EnemyCastle.GetComponent<scr_EnemyShot>();
        EnemyAttack.enabled = false;
        EnemyCastle.tag = "Untagged";
        offset = Cam.transform.position - transform.position ;
        Stage =Can.GetComponent<scr_ClearUI>();
        Shot=this.gameObject.GetComponent<scr_Shot>();
        nowPos=this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage.MoveChack) {
            Shot.enabled = false;
            if (transform.position != nowPos && !OK)
            {
                transform.position = Vector3.MoveTowards(transform.position, nowPos, 5 * Time.deltaTime);
            }
            else { 
            OK = true;
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 5 * Time.deltaTime); 
                Cam.transform.position = transform.position + offset;
                if (Target.transform.position == transform.position)
                {
                    Stage.slider.SetActive(true);
                    EnemyCastle.tag = "Range";
                    Shot.enabled = true;
                    Shot.slider = GameObject.Find("Canvas").transform.Find("Slider").GetComponent<Slider>();
                    EnemyAttack.enabled = true;
                    Stage.MoveChack = false;
                    
                }
            }
        }
    }
}
