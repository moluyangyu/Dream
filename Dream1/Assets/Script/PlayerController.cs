using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //����״̬���
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
    /// �л�����״̬
    /// </summary>
    public void ChangeFire()
    {
        fire = !fire;
    }
    /// <summary>
    /// ��һ����Ϸ�غ�
    /// </summary>
    public void NextTrun()
    {
        EventManager.instance.MoveStartIssue();
    }
}