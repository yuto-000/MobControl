using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI : MonoBehaviour
{
    [SerializeField]
    private Transform targetTfm;

    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(0, 0, 0);

    [SerializeField]
    [Tooltip("‰½”{‚©")]
    string text;
    void Start()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = text;
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        myRectTfm.position
            = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);

    }
}
