using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIShow : MonoBehaviour
{
    public GameObject Land;
    public GameObject Register;
    public void OnRegisterButtonClick()
    {
        Land.gameObject.SetActive(false);
        Register.gameObject.SetActive(true);
    }
    public void OnReturnButtonClick()
    {
        Land.gameObject.SetActive(true);
        Register.gameObject.SetActive(false);
    }
}
