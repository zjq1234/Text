using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderProgress : MonoBehaviour
{
    public Slider Slider;      //进度条
    public Text ProgressText;  //进度条显示文本
    public Canvas Canvas2;     //画布
    public Camera MainCamera;  //主相机
    public Camera ARCamera;   //AR相机
    public int Speed;          //速度
    // Update is called once per frame
    void Update()
    {
        
        Slider.value += 0.01f*Time.deltaTime*Speed; //进度条移动

        //进度条文本的显示
        ProgressText.text = "正在加载 ,请稍等........(" + ((Slider.value / 1) * 100).ToString("0.0") + " %)";
        if (Slider.value >= 1)  //进度条为100%
        {
            Canvas2.gameObject.SetActive(false);
            MainCamera.gameObject.SetActive(false);
            ARCamera.gameObject.SetActive(true);
        }
    }
}
