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
    [Header("选择棋子的类型")]
    public ClassType chesstype;
    [Header("噩梦和美梦棋子的移动距离")]
    public float fondDreamDis;
    public float nightmareDis;
    [Header("搭建关卡时标注的棋子编号")]
    public int index;
    [Header("棋子预设移动的方向集")]
    public List<Direction> directionsSeted;
    //获得影子棋子
    private GameObject shadowChess;
    //游戏预制体
    public GameObject prefabToCreate;
    //获取游戏控制脚本
    private GameObject playerController;
    //获取地图检查脚本
    private GameObject map;
    //图片素材
    public Sprite coincide;
    public Sprite noCoincide;
    //动画机
    private Animator animator;
    void Start()
    {
        shadowChess=Instantiate(prefabToCreate, new Vector3(1000f, 0f, 0f), Quaternion.identity);
        shadowChess.name = "ShadowChess" + index;
        shadowChess.GetComponent<ShadowChess>().SetChess(this.gameObject);//创建的对应的影子并且互相绑定
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
    /// 订阅事件返回自己的类型用于统计各个类型的数量
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
    /// 棋子被击杀时执行的函数
    /// </summary>
    public void Dead()
    {
        EventManager.instance.MoveEnd -= ReturnType;
        shadowChess.SetActive(false);
        animator.SetTrigger("hited");
    }
    public void AnimationBack()
    {
        Debug.Log("动画执行完毕，触发了代码！");
        this.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        //被枪击中以后执行的部分
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
    /// 这个函数是棋子进行随机移动
    /// </summary>
    /// <param name="direction"></param>移动的方向
    /// <param name="distand"></param>移动的距离
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
            direction++;//更改方向，如果检查不通过就会换一个方向位移继续尝试
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
            direction = directionsSeted[0];//获取预设列表里的方向
            directionsSeted.RemoveAt(0);//使用之后移除
        }else
        {
            Random random = new Random();
            // 获取枚举类型中的所有值
            Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction));
            // 随机选择一个方向
            direction = directions[random.Next(directions.Length)];
        }
        Move(direction);
    }
}
