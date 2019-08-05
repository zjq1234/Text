using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenBag : MonoBehaviour, IPointerClickHandler
{
    public Image ImageOfBag;
    public Image[] images;
   

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //        ImageOfBag.gameObject.SetActive(true);
        
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    ImageOfBag.gameObject.SetActive(false);
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        //ImageOfBag.gameObject.SetActive(true);
        if (ImageOfBag.gameObject.activeSelf == false)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(false);
            }
            ImageOfBag.gameObject.SetActive(true);
          
        }
        else
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].gameObject.SetActive(false);
            }
            ImageOfBag.gameObject.SetActive(false);
        }
    }
}
