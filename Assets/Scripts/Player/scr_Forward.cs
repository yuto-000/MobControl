using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class scr_Forward : MonoBehaviour
{

    //float acsell=0.2f;
    //// Start is called before the first frame update
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Speed -= acsell;
    //    if (Speed < 2.0f) acsell = 0;
    //    this.gameObject.transform.position += new Vector3(0, 0, Speed) * Time.deltaTime;


    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // 衝突時に速度をリセット
    //    Speed = 2.0f; // または別の初期速度
    //    GetComponent<Rigidbody>().velocity = Vector3.zero;
    //}    
    CharacterController controller;
    Vector3 movedir = Vector3.zero;


    GameObject Target;

    [SerializeField]
    [Tooltip("スピード")]
    float SpeedZ = 5.0f;
    [SerializeField]
    [Tooltip("最大スピード")]
    float maxSpeedZ = 5.0f;
    public float acceleratorZ=30;

    bool ch = false;
    float accsel=2.0f;

     bool change = false;
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!change)
        {

            if (SpeedZ > 100)
            {

                ch = true;
                SpeedZ = maxSpeedZ;

            }
            movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, SpeedZ);

            Vector3 globaldir = transform.TransformDirection(movedir);
            controller.Move(globaldir * Time.deltaTime);
            if (!ch)
            {

                SpeedZ += accsel;
            }
        }

        if (Target == null) {

            change = false;
        }

        if (change)
        {
            Vector3 directionToTarget = (Target.transform.position - transform.position).normalized;
            controller.Move(directionToTarget * SpeedZ * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Range")
        {

            change = true;

            GameObject childTransform;
            childTransform = other.transform.Find("GameObject").gameObject;
            if (childTransform != null)
            {
                Target = childTransform.gameObject;

            }
        }
    }

}
