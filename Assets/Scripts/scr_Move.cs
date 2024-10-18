using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class scr_Move : MonoBehaviour
{
    GameObject Target;

    CharacterController controller;
    Vector3 movedir = Vector3.zero;
    float SpeedZ = 5.0f;
    public float acceleratorZ = 30;

    int time = 0;

     bool change = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject childTransform = GameObject.Find("EnemyPos");
        if (childTransform != null)
        {
            Target = childTransform.gameObject;

        }

        time = 60;
        controller = GetComponent<CharacterController>();
        this.gameObject.layer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time--;
        if (time <0) this.gameObject.layer = 0;

        if (!change)
        {
            movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, SpeedZ);

            Vector3 globaldir = transform.TransformDirection(movedir);
            controller.Move(globaldir * Time.deltaTime);
        }

        Debug.Log(Target);

        if (Target == null)
        {

            change = false;
        }

        if (change)
        {
            Vector3 directionToTarget = (Target.transform.position - transform.position).normalized;
            controller.Move(directionToTarget * SpeedZ * Time.deltaTime);
        }
        this.gameObject.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Range") {
           change = true;
        }
    }
}
