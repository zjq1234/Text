using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BeginBuilding : MonoBehaviour,IPointerClickHandler
{
    public Canvas CanvasOfPlay;
    public Canvas CanvasAfterLoading;
    public Camera ARCamera;
    public void OnPointerClick(PointerEventData eventData)
    {
        CanvasOfPlay.gameObject.SetActive(true);
        CanvasAfterLoading.gameObject.SetActive(false);
        ARCamera.gameObject.SetActive(true);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
