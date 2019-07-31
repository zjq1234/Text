using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Material : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    public void OnPointerClick(PointerEventData eventData)
    {
        image.gameObject.SetActive(true);
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
