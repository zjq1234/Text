using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCubes : MonoBehaviour
{
    public Button DEself;
    public Button OK;
    public Canvas canva;
    Rigidbody by;

    void Start()
    {
        DEself.onClick.AddListener(delegate ()
        {

            Destroy(this.gameObject);

        });

        OK.onClick.AddListener(delegate ()
        {

            //for (int i = 0; i <  transform.childCount; i++)
            //{
            //    Destroy( transform.GetChild(i).gameObject);
            //}



            Destroy(canva.gameObject);
            Destroy(GetComponent<TextCubes>());
           // by.constraints = (RigidbodyConstraints)126;

        });
      //  by = GetComponent<Rigidbody>();


    }

    void Update()
    {
        //StartCoroutine(OnMouseDown());
    }

    IEnumerator OnMouseDown()
    {
        //将物体由世界坐标系转换为屏幕坐标系
        Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标
        //完成两个步骤 1.由于鼠标的坐标系是2维，需要转换成3维的世界坐标系 
        //    //             2.只有3维坐标情况下才能来计算鼠标位置与物理的距离，offset即是距离
        //将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        while (Input.GetMouseButton(0))
        {
            //得到现在鼠标的2维坐标系位置
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            //将当前鼠标的2维位置转换成3维位置，再加上鼠标的移动量
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            //curPosition就是物体应该的移动向量赋给transform的position属性
            transform.position = curPosition;
            yield return new WaitForFixedUpdate(); //这个很重要，循环执行
        }
    }




    private Vector2 st = Vector2.zero; //手指开始按下的位置  
    private Vector2 end = Vector2.zero; //手指拖动的位置  
    enum slideVector { nullVector, up, down, left, right }; //上下左右四个方向
    private slideVector currentVector = slideVector.nullVector; //默认是null
    private float timer;//时间计数器  
    public float offsetTime = 0.1f;//判断的时间间隔  

    void OnGUI()
    {
        if (Event.current.type == EventType.MouseDown)//判断当前手指是按下事件  
        {
            st = Event.current.mousePosition;//记录开始按下的位置  
        }
        if (Event.current.type == EventType.MouseDrag)//判断当前手指是拖动事件  

        {
            timer += Time.deltaTime;  //计时器

            if (timer > offsetTime)
            {
                end = Event.current.mousePosition; //记录结束下的位置
                Vector2 slideDirection = st - end;
                float x = slideDirection.x;
                float y = slideDirection.y;

                if (y < x && y > -x)
                {
                    if (currentVector == slideVector.right) //判断当前方向
                    {
                        return;
                    }
                    Debug.Log("right");
                    currentVector = slideVector.right; //设置方向
                }
                else if (y > x && y < -x)
                {
                    if (currentVector == slideVector.left)
                    {
                        return;
                    }
                    Debug.Log("left");
                    currentVector = slideVector.right;
                }
                else if (y > x && y > -x)
                {
                    if (currentVector == slideVector.up)
                    {
                        return;
                    }
                    Debug.Log("up");
                    currentVector = slideVector.up;
                }
                else if (y < x && y < -x)
                {
                    if (currentVector == slideVector.down)
                    {
                        return;
                    }
                    Debug.Log("down");
                    currentVector = slideVector.down;
                }
                timer = 0;
                st = end;//初始化位置

            }
        }
        if (Event.current.type == EventType.MouseUp)
        {
            currentVector = slideVector.nullVector;       //初始化方向  
        }
    }
}



