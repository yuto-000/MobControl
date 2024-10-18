using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TimesMoving : MonoBehaviour
{
    private Vector3 target;
    private float MoveSpeed = 3.0f;

    private void Start()
    {
        target = transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * MoveSpeed+ target.x, target.y, target.z);
    }
}
