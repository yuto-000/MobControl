using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.ParticleSystem;

public class scr_Attack : MonoBehaviour
{

    bool change;
    scr_EnemyHP hp;
    GameObject enemyCastle;

    // ダメージ判定フラグ
    GameObject child1;
    GameObject child2;
    GameObject child3;
    GameObject child4;


    private SkinnedMeshRenderer childRend1;
    private SkinnedMeshRenderer childRend2;
    private SkinnedMeshRenderer childRend3;
    private SkinnedMeshRenderer childRend4;


    
    scr_NoiseEnemy noise;

    int num = 0;
    private void Start()
    {
        child1 = transform.Find("body_arms").gameObject;
        child2 = transform.Find("body_head").gameObject;
        child3 = transform.Find("body_legs").gameObject;
        child4 = transform.Find("body_torso").gameObject;

        childRend1 = child1.GetComponent<SkinnedMeshRenderer>();
        childRend2 = child2.GetComponent<SkinnedMeshRenderer>();
        childRend3 = child3.GetComponent<SkinnedMeshRenderer>();
        childRend4 = child4.GetComponent<SkinnedMeshRenderer>();


        change = false;

    }
    private void Update()
    {

        


    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Sphereにぶつかれば、パーティクルを発生させる
        if (hit.gameObject.tag == "EnemyPos"&&!change)
        {
            GameObject childTransforml;
            childTransforml = hit.gameObject;
            hp=childTransforml.GetComponent<scr_EnemyHP>();
            noise=childTransforml.transform.parent.GetComponent<scr_NoiseEnemy>();
            noise.Ex = true;
            hp.hp--;
            StartCoroutine("OnDamege");
            change = true;
        }    
        if (hit.gameObject.tag == "Enemy"&&!change)
        {

            GameObject childTransforml;
            childTransforml = hit.gameObject;
            if (childTransforml.GetComponent<scr_EnemyHP>())
            {
                hp = childTransforml.GetComponent<scr_EnemyHP>();
                hp.hp--;
            }
            StartCoroutine("OnDamege");
            change = true;
        }
    }

    IEnumerator OnDamege()
    {
        childRend1.material.color = new Color(1, 1, 1, 0.5f);
        childRend2.material.color = new Color(1, 1, 1, 0.5f);
        childRend3.material.color = new Color(1, 1, 1, 0.5f);
        childRend4.material.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.1f);

        if (this.gameObject.layer != 6)
        {
            childRend1.material.color = new Color(0, 0.443f, 0.816f, 1);
            childRend2.material.color = new Color(0, 0.443f, 0.816f, 1);
            childRend3.material.color = new Color(0, 0.443f, 0.816f, 1);
            childRend4.material.color = new Color(0, 0.443f, 0.816f, 1);
        }
        else
        {
            childRend1.material.color = new Color(0.99f, 1, 0, 1);
            childRend2.material.color = new Color(0.99f, 1, 0, 1);
            childRend3.material.color = new Color(0.99f, 1, 0, 1);
            childRend4.material.color = new Color(0.99f, 1, 0, 1);
        }

        yield return new WaitForSeconds(0.2f);

        if (this.gameObject.layer != 6)
        {
            Destroy(this.gameObject);
        }
        else {
            num++;
            change = false;
            if(num==2)
                Destroy(this.gameObject);

        }
    }
}
