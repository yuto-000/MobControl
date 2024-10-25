using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DesParticle : MonoBehaviour
{

    int time;
    // Start is called before the first frame update
    void Start()
    {
        time = 60;
    }

    // Update is called once per frame
    void Update()
    {
        time--;
        if (time < 0) {
            Destroy(this.gameObject);
        }
    }
}
