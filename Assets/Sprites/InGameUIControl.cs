using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIControl : MonoBehaviour
{
    private ControlLoading CL;
    void Start() 
    {
        CL = GetComponent<ControlLoading>();
    }

    void Update()
    {
        if (Input.GetKeyDown(CL.GetKeyCodeForValue(8)))
        {
            SceneManager.LoadScene("001");
        }
        if (Input.GetKeyDown(CL.GetKeyCodeForValue(9)))
        {
            
        }
    }
}
