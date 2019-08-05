using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenNewCanvas : MonoBehaviour,IPointerClickHandler
{
    public Canvas NewCanvas;
    public Canvas OldCanvas;
    public void OnPointerClick(PointerEventData eventData)
    {
       NewCanvas.gameObject.SetActive(true);
        OldCanvas.gameObject.SetActive(false);
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
