using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissapearAct : MonoBehaviour
{
    public GameObject tutor1;
    public GameObject tutor2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            tutor1.SetActive(false);
            tutor2.SetActive(true);
        }
    }
}
