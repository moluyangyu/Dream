using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //开火状态标记
    public bool fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 切换开火状态
    /// </summary>
    public void ChangeFire()
    {
        fire = !fire;
    }
    /// <summary>
    /// 下一个游戏回合
    /// </summary>
    public void NextTrun()
    {
        EventManager.instance.MoveStartIssue();
    }
}
