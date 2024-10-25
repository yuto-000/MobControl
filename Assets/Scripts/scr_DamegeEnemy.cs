using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DamegeEnemy : MonoBehaviour
{

    // ダメージ判定フラグ
    GameObject child1;
    GameObject child2;
    GameObject child3;
    GameObject child4;


    private SkinnedMeshRenderer childRend1;
    private SkinnedMeshRenderer childRend2;
    private SkinnedMeshRenderer childRend3;
    private SkinnedMeshRenderer childRend4;

    bool ch = false;

    [SerializeField]
    [Tooltip("パーティクル")]
    GameObject Par;
    // Start is called before the first frame update
    void Start()
    {
        child1 = transform.Find("body_arms").gameObject;
        child2 = transform.Find("body_head").gameObject;
        child3 = transform.Find("body_legs").gameObject;
        child4 = transform.Find("body_torso").gameObject;

        childRend1= child1.GetComponent<SkinnedMeshRenderer>();
        childRend2= child2.GetComponent<SkinnedMeshRenderer>();
        childRend3= child3.GetComponent<SkinnedMeshRenderer>();
        childRend4= child4.GetComponent<SkinnedMeshRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Sphereにぶつかれば、パーティクルを発生させる
        if (hit.gameObject.tag == "Player" && !ch)
        {

            StartCoroutine("OnDamege");
            ch = true;
         

        }
    }

    IEnumerator OnDamege()
    {
        childRend1.material.color = new Color(1, 1, 1, 0.5f);
        childRend2.material.color = new Color(1, 1, 1, 0.5f);
        childRend3.material.color = new Color(1, 1, 1, 0.5f);
        childRend4.material.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.1f);


        childRend1.material.color = new Color(1,0,0,1);
        childRend2.material.color = new Color(1,0,0,1);
        childRend3.material.color = new Color(1,0,0,1);
        childRend4.material.color = new Color(1,0,0,1);


        yield return new WaitForSeconds(0.2f);
        Instantiate(Par, this.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(this.gameObject);
    }
}
