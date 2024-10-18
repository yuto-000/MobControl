using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class scr_Shot : MonoBehaviour
{

    [SerializeField]
    [Tooltip("発射するオブジェクト")]
    public GameObject Object;
    [SerializeField]
    [Tooltip("発射するスペシャルオブジェクト")]
    public GameObject s_Object;

    [SerializeField]
    [Tooltip("発射位置")]
    public Transform Shotter;

    int time;

    Vector3 MousePos;

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Canvas").transform.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
            MousePos = Input.mousePosition;
            MousePos = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, 10f));
            transform.position = new Vector3(MousePos.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        
        time--;

        if (time<0)
        {  
        if (Input.GetMouseButton(0) )  {
                slider.value += 0.05f;
            Instantiate(Object, Shotter.position, Quaternion.identity);
            time = 60;
            }
        }

        if (slider.value == 1) {
            if (Input.GetMouseButtonUp(0)){
                slider.value = 0;
                Instantiate(s_Object, Shotter.position, Quaternion.identity);
            }
        }
    }


  
}
