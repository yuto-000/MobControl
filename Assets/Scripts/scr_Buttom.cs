using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Buttom : MonoBehaviour
{
    [SerializeField]
    int maxNum=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {

        SceneManager.LoadScene(Random.Range(1, maxNum+1));
    }
}
