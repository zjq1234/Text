using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatPrefabsFromSLY : MonoBehaviour
{
    public GameObject[] Prefabs;//预制体数组

    public Button[] buttons;//button  数组  UI 界面
    // Start is called before the first frame update
    void Start()
        
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // 保存下标
            int index = i;
            //默认监听的方法只能是无参，若是监听带参数的方法则用委托
            buttons[i].onClick.AddListener(delegate ()
            {
                // 这里不能直接传入i，因为在循环里i的内存地址不变，所以传入的是同一个i
                // 就导致每个按钮绑定的是同样的方法，传入同样的参数
                // 而每次循环我们都重新创建了一个index，这些index的内存地址都不一样，值也不一样
                Instantiate(Prefabs[index]);
                print(index);
            });
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void ButtonEven()
    //{
    //    try
    //    {
    //        for (int i = 0; i < buttons.Length; i++)
    //        {
    //          buttons[i].onClick.AddListener(delegate ()
    //        {
    //            Instantiate(Prefabs[i]);
    //        }
    //      );
    //        }
            
    //    }
    //    catch
    //    {

    //        Debug.Log("button数组越界");
    //    }

    //}

}
