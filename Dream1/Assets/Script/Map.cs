using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    //棋盘坐标组
    public Transform[] prefabPoints;
    [Header("关卡编号")]
    public int level;
    void Start()
    {
        AddPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 检查棋子位移是否符合地图大小
    /// </summary>
    /// <param name="i"></param>关卡编号
    /// <param name="x"></param>坐标
    /// <param name="y"></param>坐标
    public bool Check(float x, float y)
    {
        
        switch (level)
        {
            case 1:
                if (x > 3.3 || x < -3)
                {
                    return true;
                }
                if (y > 3.3||y<-3.3)
                {
                    return true;
                }
                break;
        }
        return false;
    }
    /// <summary>
    /// 【已经弃用】增添坐标组进骰子位置的坐标集
    /// </summary>
    protected void AddPoint()
    {
        prefabPoints = new Transform[64];
       
        int index = 0; // 用于索引数组中的位置
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                // 创建一个新的Transform并分配到数组中
                prefabPoints[index] = new GameObject("Point " + index).transform;
                prefabPoints[index].position = new Vector3((-3.0f + 0.9f * j), (3.3f - i *0.9f), 0.0f);
                index++; // 增加索引
            }
        }
        

    }

}
