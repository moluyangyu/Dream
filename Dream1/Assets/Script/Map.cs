using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    //����������
    public Transform[] prefabPoints;
    [Header("�ؿ����")]
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
    /// �������λ���Ƿ���ϵ�ͼ��С
    /// </summary>
    /// <param name="i"></param>�ؿ����
    /// <param name="x"></param>����
    /// <param name="y"></param>����
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
    /// ���Ѿ����á����������������λ�õ����꼯
    /// </summary>
    protected void AddPoint()
    {
        prefabPoints = new Transform[64];
       
        int index = 0; // �������������е�λ��
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                // ����һ���µ�Transform�����䵽������
                prefabPoints[index] = new GameObject("Point " + index).transform;
                prefabPoints[index].position = new Vector3((-3.0f + 0.9f * j), (3.3f - i *0.9f), 0.0f);
                index++; // ��������
            }
        }
        

    }

}