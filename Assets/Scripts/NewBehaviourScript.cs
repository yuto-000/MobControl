using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    [Tooltip("�`�{")]
    int anyTimes;

    [SerializeField]
    [Tooltip("�����I�u�W�F�N�g")]
    GameObject Object;
    [SerializeField]
    [Tooltip("�����I�u�W�F�N�g(Big)")]
    GameObject BigObject;

    public int time = 0;
    float posX = 0.5f;

    List<GameObject> colList = new List<GameObject>();
    int num;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time--;
        iru();
    }

    private Vector3 GetAdjustedPosition(Vector3 position)
    {
        bool isOverlapping = true;

        while (isOverlapping)
        {
            Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
            // ����̃^�O�����R���C�_�[�������`�F�b�N
            isOverlapping = false; // �����l���d�Ȃ��Ă��Ȃ��Ƃ���

            foreach (var collider in colliders)
            {
                // �^�O���`�F�b�N
                if (collider.CompareTag("Player")) 
                {
                    isOverlapping = true; 
                    position.x += 0.1f; // X�����ɂ��炷�i�K�X�����j
                    break; // ���[�v�𔲂��čĔ���
                }
            }
        }

        return position; // �������ꂽ�ʒu��Ԃ�
    }
    private Vector3 GetAdjustedPosition2(Vector3 position)
    {
        bool isOverlapping = true;

        while (isOverlapping)
        {
            Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
            // ����̃^�O�����R���C�_�[�������`�F�b�N
            isOverlapping = false; // �����l���d�Ȃ��Ă��Ȃ��Ƃ���

            foreach (var collider in colliders)
            {
                // �^�O���`�F�b�N
                if (collider.CompareTag("Player")) 
                {
                    isOverlapping = true; 
                    position.x += 0.1f; // X�����ɂ��炷�i�K�X�����j
                    position.z += 0.5f; // X�����ɂ��炷�i�K�X�����j
                    break; // ���[�v�𔲂��čĔ���
                }
            }
        }

        return position; // �������ꂽ�ʒu��Ԃ�
    }
       private Vector3 GetAdjustedPosition3(Vector3 position)
    {
        bool isOverlapping = true;

        while (isOverlapping)
        {
            Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
            // ����̃^�O�����R���C�_�[�������`�F�b�N
            isOverlapping = false; // �����l���d�Ȃ��Ă��Ȃ��Ƃ���

            foreach (var collider in colliders)
            {
                // �^�O���`�F�b�N
                if (collider.CompareTag("Player")) 
                {
                    isOverlapping = true; 
                    position.x -= 0.1f; // X�����ɂ��炷�i�K�X�����j
                    position.z += 0.5f; // X�����ɂ��炷�i�K�X�����j
                    break; // ���[�v�𔲂��čĔ���
                }
            }
        }

        return position; // �������ꂽ�ʒu��Ԃ�
    }   private Vector3 GetAdjustedPosition4(Vector3 position)
    {
        bool isOverlapping = true;

        while (isOverlapping)
        {
            Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
            // ����̃^�O�����R���C�_�[�������`�F�b�N
            isOverlapping = false; // �����l���d�Ȃ��Ă��Ȃ��Ƃ���

            foreach (var collider in colliders)
            {
                // �^�O���`�F�b�N
                if (collider.CompareTag("Player")) 
                {
                    isOverlapping = true; 
                    position.z += 0.1f; // X�����ɂ��炷�i�K�X�����j
                    break; // ���[�v�𔲂��čĔ���
                }
            }
        }

        return position; // �������ꂽ�ʒu��Ԃ�
    }

    private void iru()
    {
        if (colList.Count > 0)
        {
            for (int num = 0; num < colList.Count; num++)
            {
                if (anyTimes == 2)
                {

                    for (int i = 0; i < anyTimes - 1; i++)
                    {
                        Vector3 spawnPosition = new Vector3(colList[num].transform.position.x + posX, colList[num].gameObject.transform.position.y, colList[num].gameObject.transform.position.z);
                        spawnPosition = GetAdjustedPosition(spawnPosition);
                        if (colList[num].layer == 6)
                        {

                            Instantiate(BigObject, spawnPosition, Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(Object, spawnPosition, Quaternion.identity);
                        }
                        colList[colList.Count - 1].gameObject.transform.position = new Vector3(colList[num].gameObject.transform.position.x - posX, colList[num].gameObject.transform.position.y, colList[num].gameObject.transform.position.z);
                    }
                }
                else
                {
                    for (int i = 1; i <= anyTimes - 2; i++)
                    {
                        Vector3 spawnPosition;
                        Vector3 spawnPosition1;
                        if (i % 2 == 0)
                        {
                            spawnPosition = new Vector3(colList[num].gameObject.transform.position.x, colList[num].gameObject.transform.position.y, colList[num].gameObject.transform.position.z + i);

                            spawnPosition = GetAdjustedPosition4(spawnPosition);
                            Instantiate(Object, spawnPosition, Quaternion.identity);

                        }
                        else
                        {
                            spawnPosition = new Vector3(colList[num].gameObject.transform.position.x - 0.5f, colList[num].gameObject.transform.position.y, colList[num].gameObject.transform.position.z + i);
                            spawnPosition1 = new Vector3(colList[num].gameObject.transform.position.x + 0.5f, colList[num].gameObject.transform.position.y, colList[num].gameObject.transform.position.z + i);

                            spawnPosition = GetAdjustedPosition2(spawnPosition);
                            spawnPosition1 = GetAdjustedPosition3(spawnPosition1);
                            Instantiate(Object, spawnPosition, Quaternion.identity);
                            Instantiate(Object, spawnPosition1, Quaternion.identity);
                        }

                        // �d�Ȃ���`�F�b�N���Ĉʒu�𒲐�
                    }
                }

                colList.RemoveAt(num);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Generated"))
        {
            // �������ꂽ�I�u�W�F�N�g�̏ꍇ�A���肵�Ȃ�
            return;
        }
       
            colList.Add(other.gameObject);


        //if (colList.Count > 0) {
        //    for (int i = 0; i < colList.Count; i++) {
        //        Debug.Log(colList[i].name); }
        
        //}
        //    if (other.gameObject.tag == "Player" && time < 0)
        //    {
        //        ch = false;
        //        if (anyTimes == 2)
        //        {
        //            time = 10;
        //            for (int i = 0; i < anyTimes - 1; i++)
        //            {
        //                Vector3 spawnPosition = new Vector3(other.gameObject.transform.position.x + posX, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        //                spawnPosition = GetAdjustedPosition(spawnPosition);
        //                Instantiate(Object, spawnPosition, Quaternion.identity);
        //                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x - posX, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        //            }
        //        }
        //        else
        //        {
        //            for (int i = 1; i <= anyTimes - 2; i++)
        //            {
        //                Vector3 spawnPosition;
        //                Vector3 spawnPosition1;
        //                if (i % 2 == 0)
        //                {
        //                    spawnPosition = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + i);

        //                    spawnPosition = GetAdjustedPosition(spawnPosition);
        //                    Instantiate(Object, spawnPosition, Quaternion.identity);
        //                }
        //                else
        //                {
        //                    spawnPosition = new Vector3(other.gameObject.transform.position.x - 1, other.gameObject.transform.position.y, other.gameObject.transform.position.z + i);
        //                    spawnPosition1 = new Vector3(other.gameObject.transform.position.x + 1, other.gameObject.transform.position.y, other.gameObject.transform.position.z + i);

        //                    spawnPosition = GetAdjustedPosition(spawnPosition);
        //                    spawnPosition1 = GetAdjustedPosition(spawnPosition1);
        //                    Instantiate(Object, spawnPosition, Quaternion.identity);
        //                    Instantiate(Object, spawnPosition1, Quaternion.identity);
        //                }

        //                // �d�Ȃ���`�F�b�N���Ĉʒu�𒲐�
        //            }
        //        }
        //    }
        //}
    }
}
