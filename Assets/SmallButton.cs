using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SmallButton : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public Image ImageOfSmall;
    public Image ImageOfBuilder;
    public Button ButtonOfBuilder;
    public Canvas CanvasOfSmall;



    public void OnPointerClick(PointerEventData eventData)
    {
        ImageOfBuilder.gameObject.SetActive(true);
        ButtonOfBuilder.gameObject.SetActive(true);
        CanvasOfSmall.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImageOfSmall.gameObject.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImageOfSmall.gameObject.SetActive(false);
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
