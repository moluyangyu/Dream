using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Chess))]
public class ChessEditor : Editor
{
    int index = 0;
    void OnEnable()
    {
        // ��Prefabʵ����ʱע��ص�
       
        PrefabUtility.prefabInstanceUpdated += OnPrefabInstanceUpdated;
    }

    void OnDisable()
    {
        // �Ƴ��ص��Է�ֹй©
        
        PrefabUtility.prefabInstanceUpdated -= OnPrefabInstanceUpdated;
    }

    // �ص���������Prefabʵ���������
    void OnPrefabInstanceUpdated(GameObject instance)
    {
        // ���ʵ���Ƿ���Ŀ��ű���ʵ��
       /* Chess chess = instance.GetComponent<Chess>();
        Debug.Log("��ʼ��ֵ");
        if (chess != null)
        {
            // ���������ñ�����ֵ������Ը�����Ҫ�޸�
            chess.index =index;
            index++;
        }*/
    }
}