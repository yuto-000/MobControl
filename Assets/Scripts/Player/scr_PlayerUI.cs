using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Transform targetTfm;

    private RectTransform myRectTfm;
    public Vector3 offset = new Vector3(0, 0, 0);

    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        myRectTfm.position
            = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);

    }
}
