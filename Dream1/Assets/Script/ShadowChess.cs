using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChess : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chess;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 初始化设置
    /// </summary>
    /// <param name="_chess"></param>
    public void SetChess(GameObject _chess)
    {
        chess = _chess;
    }
    /// <summary>
    /// 移动到目标棋子上一回合的位置
    /// </summary>
    /// <param name="transform"></param>
    public void Follow(Transform transform)
    {
        GetComponent<Transform>().position = transform.position;
    }
}
