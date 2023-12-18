using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    /// <summary>
    /// �¼�������
    /// </summary>
    //����
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
    
    //�ƶ���ʼ���¼�
    public delegate void MoveStartHandler();
    public event MoveStartHandler MoveStart;
    public void MoveStartIssue()
    {
        Debug.Log("�ƶ���ʼ");
        eye.GetComponent<Animator>().SetBool("movestart", true);
    }
    public void AnimationBack()
    {
        MoveStart?.Invoke();
        MoveEndIssue();
    }
    //�ƶ����������ʤ���ж�
    public delegate bool MoveEndHandler();
    public event MoveEndHandler MoveEnd;
    public void MoveEndIssue()
    {
        Debug.Log("�ƶ�����");
        bool result;
        int fondDream = 0;
        int nightmare = 0;
        if(MoveEnd!=null)
        {
            foreach(MoveEndHandler hanlder in MoveEnd.GetInvocationList())//�������¼����б���
            {
                result = hanlder();//ͳ�Ƹ��������ӵ�����
                fondDream += (result) ? 1 : 0;
                nightmare += (result) ? 0 : 1;
            }
        }
        if (nightmare == 0)
        {
            Canvas.GetComponent<UIControl>().End(true);//ج������û���˾���Ӯ
        }
        else if (fondDream==0)
        {
            Canvas.GetComponent<UIControl>().End(false);//��������û���˾�����
        }
        

    }
}