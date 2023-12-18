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
        // 在Prefab实例化时注册回调
       
        PrefabUtility.prefabInstanceUpdated += OnPrefabInstanceUpdated;
    }

    void OnDisable()
    {
        // 移除回调以防止泄漏
        
        PrefabUtility.prefabInstanceUpdated -= OnPrefabInstanceUpdated;
    }

    // 回调方法，当Prefab实例化后调用
    void OnPrefabInstanceUpdated(GameObject instance)
    {
        // 检查实例是否是目标脚本的实例
       /* Chess chess = instance.GetComponent<Chess>();
        Debug.Log("开始赋值");
        if (chess != null)
        {
            // 在这里设置变量的值，你可以根据需要修改
            chess.index =index;
            index++;
        }*/
    }
}
