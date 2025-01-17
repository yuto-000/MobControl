using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class scr_EnemyUI : MonoBehaviour
{
    [SerializeField]
    private Transform targetTfm;

    private RectTransform myRectTfm;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, 0);



    scr_EnemyHP hp;
    GameObject enemyCastle;
    [SerializeField]
    Text t;
    [SerializeField]
    GameObject childTransform;
    void Start()
    {


        if (childTransform != null)
        {
            enemyCastle = childTransform.gameObject;
            hp = enemyCastle.GetComponent<scr_EnemyHP>();
            t.text = " " + hp.hp.ToString();
        }

        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (childTransform != null)
        {
            hp = enemyCastle.GetComponent<scr_EnemyHP>();
            t.text = " " + hp.hp.ToString(); 
            myRectTfm.position
            = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);

        }
        else
        {
            t.text = " ";
        }

    }
}
