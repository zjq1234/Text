using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabGanager : MonoBehaviour
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public static PrefabGanager _PrefabGam//单例
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PrefabGanager>();
            }
            return _instance;
        }
    }
    private static PrefabGanager _instance;

    public GameObject[] Prefabs;//预制体数组

    public Button[] buttons;//button  数组  UI 界面
    /// <summary>
    /// 预制体名称
    /// </summary>
    public enum prefabs
    {
        cube,
        sphere,
        capsule,
        cylinder


    }
    [HideInInspector]
    public GameObject obj;
    prefabs pre = prefabs.cube;//默认生成cube  
    private void Start()
    {
        ButtonEven();

    }
    /// <summary>
    /// 生成预制体
    /// </summary>
    public void InstanPre()
    {
        try
        {
            switch (pre)
            {
                case prefabs.cube:
                    obj = Prefabs[0];
                    break;
                case prefabs.sphere:
                    obj = Prefabs[1];
                    break;
                case prefabs.capsule:
                    obj = Prefabs[2];
                    break;
                case prefabs.cylinder:
                    obj = Prefabs[3];
                    break;



            }
        }
        catch
        {

            Debug.Log("预制体数组越界");
        }
        Instantiate(obj);
    }
    /// <summary>
    /// button执行事件
    /// </summary>
    public void ButtonEven()
    {
        try
        {
            buttons[0].onClick.AddListener(delegate ()
            {
                pre = prefabs.capsule;
                InstanPre();
            }






          );
        }
        catch
        {

            Debug.Log("button数组越界");
        }

    }


}
