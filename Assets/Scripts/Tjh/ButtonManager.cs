using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public Canvas Canvas;  // 最开始的画布
    public Image[] StepImage;  //具体介绍数组
    public Scrollbar[] Scrollbars;  //滑动条
    public GameObject[] objs;
    /// <summary>
    /// 点击每一个主场景按钮的时间
    /// </summary>
    /// <param name="index">具体介绍数组下标</param>
    public void OnButtonClick(int index)
    {
        Canvas.gameObject.SetActive(false);
        StepImage[index].gameObject.SetActive(true);
        for (int i = 0; i < Scrollbars.Length; i++)
        {
            Scrollbars[i].value = 1;
        }
    }
    /// <summary>
    /// 返回按钮
    /// </summary>
    public void OnReturnButtonClick()
    {
        for (int i = 0; i < StepImage.Length; i++)
        {
            StepImage[i].gameObject.SetActive(false);
        }
        
        Canvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// 学习按钮
    /// </summary>
    public void OnStudyButtonClick()
    {
        SceneManager.LoadScene("LearningTop");
    }

    public void OnCanvasButtonClick()
    {
        //SceneManager.LoadScene("Load");
        objs[0].gameObject.SetActive(true);
        objs[1].gameObject.SetActive(false);

    }
}
