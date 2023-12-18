using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[System.Serializable]
public enum ClassType
{
    FondDream,
    Nightmare
}
[System.Serializable]
public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    UpLeft,
    UpRight,
    DownLeft,
    DownRight
}


public class Chess : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("ѡ�����ӵ�����")]
    public ClassType chesstype;
    [Header("ج�κ��������ӵ��ƶ�����")]
    public float fondDreamDis;
    public float nightmareDis;
    [Header("��ؿ�ʱ��ע�����ӱ��")]
    public int index;
    [Header("����Ԥ���ƶ��ķ���")]
    public List<Direction> directionsSeted;
    //���Ӱ������
    private GameObject shadowChess;
    //��ϷԤ����
    public GameObject prefabToCreate;
    //��ȡ��Ϸ���ƽű�
    private GameObject playerController;
    //��ȡ��ͼ���ű�
    private GameObject map;
    //ͼƬ�ز�
    public Sprite coincide;
    public Sprite noCoincide;
    //������
    private Animator animator;
    void Start()
    {
        shadowChess=Instantiate(prefabToCreate, new Vector3(1000f, 0f, 0f), Quaternion.identity);
        shadowChess.name = "ShadowChess" + index;
        shadowChess.GetComponent<ShadowChess>().SetChess(this.gameObject);//�����Ķ�Ӧ��Ӱ�Ӳ��һ����
        EventManager.instance.MoveStart += Move;
        EventManager.instance.MoveEnd += ReturnType;
        playerController = GameObject.Find("EventSystem");
        map= GameObject.Find("map");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// �����¼������Լ�����������ͳ�Ƹ������͵�����
    /// </summary>
    /// <returns></returns>
    public bool ReturnType()
    {
        if(chesstype==ClassType.Nightmare)
        {
            return false;
        }else
        {
            return true;
        }
    }
    /// <summary>
    /// ���ӱ���ɱʱִ�еĺ���
    /// </summary>
    public void Dead()
    {
        EventManager.instance.MoveEnd -= ReturnType;
        shadowChess.SetActive(false);
        animator.SetTrigger("hited");
    }
    public void AnimationBack()
    {
        Debug.Log("����ִ����ϣ������˴��룡");
        this.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        //��ǹ�����Ժ�ִ�еĲ���
        if (playerController.GetComponent<PlayerController>().fire)
        {
            playerController.GetComponent<PlayerController>().fire = false;
            EventManager.instance.MoveStartIssue();
            Dead();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("123556");
        animator.SetBool("hunhe", true);
        Color a = collision.gameObject.GetComponent<SpriteRenderer>().color;
        a.a = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("3556");
        animator.SetBool("hunhe", false);
        gameObject.GetComponent<SpriteRenderer>().sprite = coincide;
        Color a = collision.gameObject.GetComponent<SpriteRenderer>().color;
        a.a = 0.41f;
    }
    /// <summary>
    /// ������������ӽ�������ƶ�
    /// </summary>
    /// <param name="direction"></param>�ƶ��ķ���
    /// <param name="distand"></param>�ƶ��ľ���
    public void Move(Direction direction, float distand)
    {
        shadowChess.GetComponent<ShadowChess>().Follow(transform);
        Transform a = new GameObject("NewObject").transform;
        do
        {
            a.position = GetComponent<Transform>().position;
            switch (direction)
            {
                case Direction.Up: a.position += new Vector3(0f * distand, 1.0f * distand, 0f * distand); break;
                case Direction.Down: a.position += new Vector3(0f * distand, -1.0f * distand, 0f * distand); break;
                case Direction.Left: a.position += new Vector3(-1.0f * distand, 0f * distand, 0f * distand); break;
                case Direction.Right: a.position += new Vector3(1.0f * distand, 0f * distand, 0f * distand); break;
                case Direction.DownLeft: a.position += new Vector3(-1.0f * distand, -1.0f * distand, 0f * distand); break;
                case Direction.DownRight: a.position += new Vector3(1.0f * distand, -1.0f * distand, 0f * distand); break;
                case Direction.UpLeft: a.position += new Vector3(-1.0f * distand, 1.0f * distand, 0f * distand); break;
                case Direction.UpRight: a.position += new Vector3(1.0f * distand, 1.0f * distand, 0f * distand); break;
            }
            direction++;//���ķ��������鲻ͨ���ͻỻһ������λ�Ƽ�������
        } while(map.GetComponent<Map>().Check(a.position.x, a.position.y));
        {
            GetComponent<Transform>().position = a.position;
        }
        Destroy(a.gameObject);
    }
    public void Move(Direction direction)
    {
        float distand;
        if(chesstype==ClassType.Nightmare)
        {
            distand = nightmareDis;
        }else
        {
            distand = fondDreamDis;
        }
        Move(direction, distand);
    }
    public void Move()
    {
        Direction direction;
        if (directionsSeted.Count>0)
        {
            direction = directionsSeted[0];//��ȡԤ���б���ķ���
            directionsSeted.RemoveAt(0);//ʹ��֮���Ƴ�
        }else
        {
            Random random = new Random();
            // ��ȡö�������е�����ֵ
            Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction));
            // ���ѡ��һ������
            direction = directions[random.Next(directions.Length)];
        }
        Move(direction);
    }
}