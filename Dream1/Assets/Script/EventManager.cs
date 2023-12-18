using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    /// <summary>
    /// 事件管理器
    /// </summary>
    //单例
    public static EventManager instance;
    public GameObject Canvas;
    public GameObject eye;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        eye = GameObject.Find("eye");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //移动开始的事件
    public delegate void MoveStartHandler();
    public event MoveStartHandler MoveStart;
    public void MoveStartIssue()
    {
        Debug.Log("移动开始");
        eye.GetComponent<Animator>().SetBool("movestart", true);
    }
    public void AnimationBack()
    {
        MoveStart?.Invoke();
        MoveEndIssue();
    }
    //移动结束后进行胜负判定
    public delegate bool MoveEndHandler();
    public event MoveEndHandler MoveEnd;
    public void MoveEndIssue()
    {
        Debug.Log("移动结束");
        bool result;
        int fondDream = 0;
        int nightmare = 0;
        if(MoveEnd!=null)
        {
            foreach(MoveEndHandler hanlder in MoveEnd.GetInvocationList())//对所有事件进行遍历
            {
                result = hanlder();//统计各种类棋子的数量
                fondDream += (result) ? 1 : 0;
                nightmare += (result) ? 0 : 1;
            }
        }
        if (nightmare == 0)
        {
            Canvas.GetComponent<UIControl>().End(true);//噩梦棋子没有了就判赢
        }
        else if (fondDream==0)
        {
            Canvas.GetComponent<UIControl>().End(false);//美梦棋子没有了就判输
        }
        

    }
}
