using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOfNewBuilder : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public Image ImageOfNewBuilder;
    public Image ImageOfOldBuilder;
    public Image ImageOfBuilder;
    public Image ImageOfSmallNew;
    public Canvas CanvasOfSmall;
    public Button SmallButton;
    public Button ButtonOfBuilder;


    public void OnPointerClick(PointerEventData eventData)
    {
        ImageOfNewBuilder.gameObject.SetActive(false);
        ImageOfOldBuilder.gameObject.SetActive(false);
        ImageOfBuilder.gameObject.SetActive(false);
        ImageOfSmallNew.gameObject.SetActive(true);
        CanvasOfSmall.gameObject.SetActive(true);
        SmallButton.gameObject.SetActive(true);
        ButtonOfBuilder.gameObject.SetActive(false);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ImageOfNewBuilder.gameObject.SetActive(true);
        ImageOfBuilder.gameObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImageOfNewBuilder.gameObject.SetActive(false);
        ImageOfBuilder.gameObject.SetActive(true);
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
