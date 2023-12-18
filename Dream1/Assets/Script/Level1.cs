using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    //回合数
    int turnNumber;
    //所有棋子
    GameObject[] chesses;
    private void Awake()
    {
        turnNumber = 0;
    }
    void Start()
    {
        chesses = GameObject.FindGameObjectsWithTag("Chess");
        turnNumber=0;
        EventManager.instance.MoveStart += AddTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 订阅回合移动之后进行的行为
    /// </summary>
    public void AddTurn()
    {
        turnNumber++;
        if(turnNumber==2)
        {
            bool result;
            int fondDream = 0;
            int nightmare = 0;
            foreach (GameObject a in chesses)
            {
                result = a.GetComponent<Chess>().ReturnType();
                fondDream += (result) ? 1 : 0;//统计各个棋子的数量
                nightmare += (result) ? 0 : 1;
            }
            if(nightmare!=0)
            {
                foreach (GameObject a in chesses)
                {
                    if(a.GetComponent<Chess>().chesstype == ClassType.FondDream)
                    {
                        a.GetComponent<Chess>().Dead();//被噩梦杀死
                    }
                }
            }
        }
    }
}
