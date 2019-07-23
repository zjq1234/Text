using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiatePrefabs : MonoBehaviour
{
    public Button button;
    public GameObject obj;
    public Button buttoni;
    [HideInInspector]
    public Transform[] objs;
    [HideInInspector]
    public int ID = 1;


    void Start()
    {
        //print(JsonUtility.ToJson(new Vector3(1, 1, 1)));
        //print(JsonUtility.FromJson<Vector3>(JsonUtility.ToJson(new Vector3(1, 1, 1))));
        ButtonAddListener();
    }
    [HideInInspector]
    public string[] name2 = new string[4] { "", "", "", "" };
    public void ButtonAddListener()
    {
        button.onClick.AddListener(delegate ()
        {
            GameObject obj1 = Instantiate(obj, this.transform);
            obj1.transform.position = new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
            objs = GetComponentsInChildren<Transform>();

            for (int i = 1; i < objs.Length; i++)
            {
                print(objs[i].name);
            }
            name2[0] = "'" + objs[ID].name + "'";
            name2[1] = "'" + obj1.transform.position.ToString() + "'";
            name2[2] = "'" + obj1.transform.localScale.ToString() + "'";
            name2[3] = "'" + obj1.transform.rotation.eulerAngles.ToString() + "'";
            for (int i = 0; i < name2.Length; i++)
            {
                print(name2[i].ToString());
            }
            ID++;
        }
      );
        buttoni.onClick.AddListener(delegate ()
        {
            Gamemanager.StartSenceUsing.AddStep("", name2);
        });
    }

}
