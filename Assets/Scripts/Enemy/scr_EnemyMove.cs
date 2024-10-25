using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EnemyMove : MonoBehaviour
{
    CharacterController controller;
    Vector3 movedir = Vector3.zero;


    [SerializeField]
    [Tooltip("スピード")]
    float SpeedZ = 5.0f;

    [SerializeField]
    [Tooltip("MAXスピード")]
    float MaxSpeedZ = 5.0f;
    public float acceleratorZ = 30;

    bool ch = false;
    float accsel = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedZ > 50)
        {

            ch = true;
            SpeedZ = MaxSpeedZ;

        }
        movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, SpeedZ);

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);
        if (!ch)
        {

            SpeedZ += accsel;
        }


    }
}
