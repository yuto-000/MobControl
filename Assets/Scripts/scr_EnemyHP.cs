using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EnemyHP : MonoBehaviour
{
    [SerializeField]
    [Tooltip("HP")]
    public int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 1)
        {

            Destroy(gameObject);
        }
    }
}
