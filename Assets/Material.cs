using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Material : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    private Shader shader;

    public Material(Shader shader)
    {
        this.shader = shader;
    }

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

    internal void SetInt(string v, int always)
    {
        throw new NotImplementedException();
    }

    internal void SetPass(int v)
    {
        throw new NotImplementedException();
    }
}
