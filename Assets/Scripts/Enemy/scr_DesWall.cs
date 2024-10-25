using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DesWall : MonoBehaviour
{
    scr_EnemyHP HP;
    // Start is called before the first frame update
    void Start()
    {
        HP=this.gameObject.GetComponent<scr_EnemyHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.hp < 1) Destroy(this.gameObject);
    }
}
