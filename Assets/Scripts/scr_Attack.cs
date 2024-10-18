using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.ParticleSystem;

public class scr_Attack : MonoBehaviour
{
    int time = 0;
    bool change;
    scr_EnemyHP hp;
    GameObject enemyCastle;
    private void Start()
    {


        GameObject childTransform = GameObject.Find("EnemyPos");
        if (childTransform != null)
        {
            enemyCastle = childTransform.gameObject;
            hp=enemyCastle.GetComponent<scr_EnemyHP>();

        }
        change = false;
    }
    private void Update()
    {
        if (change)
        {
          time--;
            if (time < 0) {

                hp.hp--;
                Destroy(this.gameObject);
            }
        }


    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Sphere�ɂԂ���΁A�p�[�e�B�N���𔭐�������
        if (hit.gameObject.tag == "EnemyPos"&&!change)
        {

            change = true;
            time = 80;
        }
    }
 
}
