using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class scr_Move : MonoBehaviour
{
    GameObject Target;

    CharacterController controller;
    Vector3 movedir = Vector3.zero;
    [SerializeField]
    [Tooltip("最大スピード")]
    float SpeedZ = 5.0f;
    public float acceleratorZ = 30;

    int time = 0;

     bool change = false;

    int nowLay;
    // Start is called before the first frame update
    void Start()
    {
      

        time = 60;
        controller = GetComponent<CharacterController>();
        nowLay=this.gameObject.layer;
        this.gameObject.layer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time--;
        if (time < 0 && nowLay != 6) { this.gameObject.layer = 0; }
        else if(time < 0 && nowLay == 6){ 
        this.gameObject.layer = 6;
        }

        if (!change)
        {
            movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, SpeedZ);

            Vector3 globaldir = transform.TransformDirection(movedir);
            controller.Move(globaldir * Time.deltaTime);
        }


        if (Target == null)
        {

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
        if (other.gameObject.tag == "Range") {
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
