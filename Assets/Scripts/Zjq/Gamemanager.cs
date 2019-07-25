using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{

    public static Gamemanager StartSenceUsing
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Gamemanager>();
                if (instance == null)
                {
                    instance = new GameObject("StartSence").AddComponent<Gamemanager>();
                }
            }
            return instance;
        }

    }//单例
    private static Gamemanager instance;

    //登录
    public InputField User;
    public InputField Pass;
    public Button Sign;
    //注册
    public InputField RUser;
    public InputField RPass;
    public InputField ConfirmPass;
    public Button register;

    //注册失败  显示的对话框
    public Canvas PassNo;
    public GameObject Passdifference;

    public GameObject Land;
    public GameObject Register;//注册成功  显示  登录界面
    public GameObject Canvas1;
    public GameObject Canvas2;

    private Mono_Master sql;//创建数据库名称
    private static int Sq1Name = 123045;

    [HideInInspector]
    public string SqName = "";

    //数据库
    private SqliteConnection dbConnection;


    private void Awake()
    {
        int temp = PlayerPrefs.GetInt("Frist");//如果相同 说明不是第一次运行
        if (Sq1Name != temp)
        {
            NewSqlite();
        }
    }
    void Start()
    {
        ButtonOnClink();

    }
    /// <summary>
    /// awake  调用  程序每开始一次 创建一个数据库
    /// </summary>
    [HideInInspector]
    public string NameCount;
    public void NewSqlite()
    {
        PlayerPrefs.SetInt("Frist", Sq1Name);//第一次运行  
        NameCount = "data source=" + Sq1Name + ".db";
        sql = new Mono_Master(NameCount);
    }


    /// <summary>
    /// 注册（新建数据表）
    /// </summary>
    public void RegistreSqlite()
    {
        if (RPass.text == ConfirmPass.text && RPass.text != null && RUser.text != null)
        {
            string sheetname = RUser.text + RPass.text;//数据表名称是 用户名加上密码
            sql.CreateTable(sheetname, new string[] { "Name", "Position", "Rotation", "Scale" }, new string[] { "TEXT", "TEXT", "TEXT", "TEXT" });
            Debug.Log("注册成功");//跳转场景 注册界面
            Land.gameObject.SetActive(true);
            Register.gameObject.SetActive(false);

            //  sql.CloseConnection();//关闭数据库
        }
        else
        {
            Instantiate(Passdifference, PassNo.transform);
            Debug.Log("两次密码输入不一样或者输入为空");
        }

    }
    /// <summary>
    /// 登录（获取数据表）
    /// </summary>
    [HideInInspector]
    public string signname = "";
    public void SignSqlite()
    {
        signname = User.text + Pass.text;
        try
        {
            if (CheckDataTableNO(NameCount, signname))
            {
                int temp = PlayerPrefs.GetInt("Frist");//如果相同 说明不是第一次运行 需要打开数据库
                if (Sq1Name == temp)
                {
                    OpenBase(NameCount);
                }

                Debug.Log("登录成功！");
                Canvas1.gameObject.SetActive(false);//换界面显示
                Canvas2.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("登录失败！");
            }
        }
        catch 
        {

            Debug.Log("登录异常！");
        }
       
    }

    /// <summary>
    /// 判断数据库中是否有表处在
    /// </summary>
    /// <param name="str"></param>
    /// <param name="str1"></param>
    /// <returns></returns>
    public bool CheckDataTableNO(string str, string str1)
    {
        using (SqliteConnection conn = new SqliteConnection(str))
        using (SqliteCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM sqlite_master where type='table' and name='" + str1 + "'";
            //cmd.CommandText = "SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = 'serverinfo'";
            object ob = cmd.ExecuteScalar();
            long tableCount = Convert.ToInt64(ob);

            if (tableCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    /// <summary>
    /// 打开数据库
    /// </summary>
    /// <param name="str 数据表名称"></param>
    public void OpenBase(string str)
    {
        using (SqliteConnection conn = new SqliteConnection(str))
            conn.Open();
    }
    /// <summary>
    /// 添加数据
    /// </summary>
    /// <param name="str"></param>数据表的名称
    public void AddStep(string str, string[] strs)
    {

        print(signname);
        for (int i = 0; i < strs.Length; i++)
        {
            print(strs[i]);
        }
        try
        {
            sql.InsertValues(signname, new string[] { strs[0], strs[1], strs[2], strs[3] });
        }
        catch
        {
            Debug.Log("插入数据异常");
        }

        SqliteDataReader reader = sql.ReadFullTable(signname);
        while (reader.Read())
        {
            //读取Name
            Debug.Log(reader.GetString(reader.GetOrdinal("Name")));
            //读取Position
            Debug.Log(reader.GetString(reader.GetOrdinal("Position")));
            //读取Rotation
            Debug.Log(reader.GetString(reader.GetOrdinal("Rotation")));
            //读取Scale
            Debug.Log(reader.GetString(reader.GetOrdinal("Scale")));
        }
    }

    public void ButtonOnClink()
    {
        register.onClick.AddListener(delegate ()
        {
            print(User.text);
            RegistreSqlite();//注册

        });
        Sign.onClick.AddListener(delegate ()
        {
            print(User.text);
            SignSqlite();//登录

        });
    }
}
