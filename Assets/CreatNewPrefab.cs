using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreatNewPrefab : MonoBehaviour,IPointerClickHandler
{
    public GameObject Prefab;
    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(Prefab); 
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
