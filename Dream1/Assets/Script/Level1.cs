using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    //�غ���
    int turnNumber;
    //��������
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
    /// ���Ļغ��ƶ�֮����е���Ϊ
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
                fondDream += (result) ? 1 : 0;//ͳ�Ƹ������ӵ�����
                nightmare += (result) ? 0 : 1;
            }
            if(nightmare!=0)
            {
                foreach (GameObject a in chesses)
                {
                    if(a.GetComponent<Chess>().chesstype == ClassType.FondDream)
                    {
                        a.GetComponent<Chess>().Dead();//��ج��ɱ��
                    }
                }
            }
        }
    }
}