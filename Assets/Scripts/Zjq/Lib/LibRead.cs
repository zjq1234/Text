using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>
public class LibRead : MonoBehaviour
{
    public Button Storage;//储存
    public Button ReadLib;//读取数据
    //点击存储出现的canvas
    public Canvas StorageNameCanvas;//储存的名称canvas
    public InputField StorageName;//储存的名称
    public Button OKStorageButton;//确定
    //点击读取出现的canvas
    public Canvas ReadCans;//读取canvas
    public Button OKRead;//button事件
    public Text TexeName;//button上的text
    [HideInInspector]
    public string[] name2 = new string[4] { "", "", "", "" };//储存的数组

    private Mono_Master sql;//创建数据库名称
    private void Awake()
    {
        StorageNameCanvas.gameObject.SetActive(false);//开始隐藏
        ReadCans.gameObject.SetActive(false);//开始隐藏起来
    }
    void Start()
    {
        ButtonONClickEvent();//点击事件


    }
  
   
    /// <summary>
    /// 储存数据方法
    /// </summary>
    void StoLib()
    {

        Transform[] objsa = GetComponentsInChildren<Transform>();//获取子物体
       

        name2[0] = "'" + objsa[1].name + "'";
        name2[1] = "'" + objsa[1].transform.localPosition.ToString() + "'";
        name2[2] = "'" + objsa[1].transform.localScale.ToString() + "'";
        name2[3] = "'" + objsa[1].transform.rotation.eulerAngles.ToString() + "'";

        Gamemanager.StartSenceUsing.AddStep(StorageName.text, name2);//将数据储存
    }


    public void ButtonONClickEvent()
    {
        //储存按钮点击事件
        Storage.onClick.AddListener(delegate ()
        {
            StorageName.text = "";
            StorageNameCanvas.gameObject.SetActive(true);//显示存储的按钮
            try
            {
                Gamemanager.StartSenceUsing.SignSqlite();//打开数据库
            }
            catch
            {
                print("异常登录数据！");
            }
        }
      );
        //读取按钮点击事件
        ReadLib.onClick.AddListener(delegate ()
        {
            //读取数据   button 名字为储存名字

            SqliteDataReader reader = Gamemanager.StartSenceUsing.sql.ReadFullTable(Gamemanager.StartSenceUsing.signname);
            try
            {
                while (reader.Read())
                {

                    Debug.Log(reader.GetString(reader.GetOrdinal("UserName")));
                    //读取Name
                    Debug.Log(reader.GetString(reader.GetOrdinal("PreName")));
                    //读取Position
                    Debug.Log(reader.GetString(reader.GetOrdinal("Position")));
                   // 读取Rotation
                     Debug.Log(reader.GetString(reader.GetOrdinal("Rotation")));
                    //读取Scale
                     Debug.Log(reader.GetString(reader.GetOrdinal("Scale")));
                    TexeName.text = reader.GetString(reader.GetOrdinal("UserName")).ToString();

                    ReadCans.gameObject.SetActive(true);
                }
            }
            catch
            {

                print("越界？");
            }

          
        }
     );
        //读取确定点击事件
        ReadLib.onClick.AddListener(delegate ()
        {

            
        }
       );
        //储存确定点击事件
        OKStorageButton.onClick.AddListener(delegate ()
        {
            StoLib();
            StorageNameCanvas.gameObject.SetActive(false);

        }
       );
    }

}
