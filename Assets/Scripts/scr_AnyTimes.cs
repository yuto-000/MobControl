using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr_AnyTimes : MonoBehaviour
{
    [SerializeField]
    [Tooltip("～倍")]
    int anyTimes;

    [SerializeField]
    [Tooltip("増加オブジェクト")]
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
        // この範囲内に他のオブジェクトがあるか確認
        while(!ch){
            Collider[] colliders = Physics.OverlapSphere(position, 0.5f);
            if (colliders.Length > 3)
            {
                Debug.Log(colliders.Length);
                // 他のオブジェクトと重なっている場合、少しずらす

                position.x += 0.5f; // X方向に1ユニットずらす（適宜調整）
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

                    // 重なりをチェックして位置を調整
                    spawnPosition = GetAdjustedPosition(spawnPosition);
                    Instantiate(Object, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
