using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GameOver : MonoBehaviour
{

    [SerializeField]
    [Tooltip("�J����")]
    Camera Target;

    scr_Noise noise;
    // Start is called before the first frame update
    void Start()
    {
        noise=Target.GetComponent<scr_Noise>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        //Sphere�ɂԂ���΁A�p�[�e�B�N���𔭐�������
        if (other.gameObject.tag == "Enemy")
        {
            noise.Ex = true;
        }

    }

}
