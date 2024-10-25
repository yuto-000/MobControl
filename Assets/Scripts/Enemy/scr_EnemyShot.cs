using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EnemyShot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�G")]
    GameObject Enemy;

    [SerializeField]
    [Tooltip("���ˈʒu")]
    GameObject EnemyShotPos;

    [SerializeField]
    [Tooltip("����")]
    int time=120;
    [SerializeField]
    [Tooltip("�G�̐�")]
    int maxNum = 0;

    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time--;
        if (time < 0)
        {

            time = 0;
                float x = Random.Range(EnemyShotPos.transform.position.x-1, EnemyShotPos.transform.position.x + 1);
                Instantiate(Enemy, new Vector3(x,EnemyShotPos.transform.position.y,EnemyShotPos.transform.position.z), Quaternion.Euler(0,180,0));
            num++;
            if (num == maxNum) {
                num = 0;
                time = 500;
            }
        }
    }
}
