using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseEnterChangeImage : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image EnterImage;
    public void OnPointerEnter(PointerEventData eventData)
    {
        EnterImage.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EnterImage.gameObject.SetActive(false);
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
