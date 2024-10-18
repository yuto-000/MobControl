using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_AnyTimes : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�`�{")]
    int anyTimes;

    [SerializeField]
    [Tooltip("�����I�u�W�F�N�g")]
    GameObject Object;

    public int time = 0;
    float posX = 0.5f;
    bool ch = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time--;
    }

    private Vector3 GetAdjustedPosition(Vector3 position)
    {
        // ���͈͓̔��ɑ��̃I�u�W�F�N�g�����邩�m�F
        while(!ch){
            Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
            if (colliders.Length > 3)
            {
                Debug.Log(colliders.Length);
                // ���̃I�u�W�F�N�g�Əd�Ȃ��Ă���ꍇ�A�������炷

                position.x += 0.5f; // X������1���j�b�g���炷�i�K�X�����j
            }
            else
            {

                ch = true;
            }
        }
        return position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Times" && time < 0)
        {
            ch = false;
            if (anyTimes == 2)
            {
                time = 10;
                for (int i = 0; i < anyTimes - 1; i++)
                {
                    Vector3 spawnPosition = new Vector3(this.gameObject.transform.position.x + posX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    spawnPosition = GetAdjustedPosition(spawnPosition);
                    Instantiate(Object, spawnPosition, Quaternion.identity);
                    this.gameObject.transform.position=new Vector3(this.gameObject.transform.position.x - posX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                }
            }
            else
            {
                for (int i = 1; i <= anyTimes - 2; i++)
                {
                    Vector3 spawnPosition;
                    if (i % 2 == 0)
                    {
                        spawnPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + i);
                    }
                    else
                    {
                        spawnPosition = new Vector3(this.gameObject.transform.position.x - 1, this.gameObject.transform.position.y, this.gameObject.transform.position.z + i);
                        Instantiate(Object, new Vector3(this.gameObject.transform.position.x + 1, this.gameObject.transform.position.y, this.gameObject.transform.position.z + i), Quaternion.identity);
                    }

                    // �d�Ȃ���`�F�b�N���Ĉʒu�𒲐�
                    spawnPosition = GetAdjustedPosition(spawnPosition);
                    Instantiate(Object, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
