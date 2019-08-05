using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnTopp : MonoBehaviour
{

    public GameObject obj; public GameObject obj1;
    public void OnButton()
    {
        obj.gameObject.SetActive(true);
        obj1.gameObject.SetActive(false);
    }
}
