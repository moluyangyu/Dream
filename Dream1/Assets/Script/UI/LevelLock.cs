using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLock : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelLock instance;
    [Header("当前解锁的关卡数")]
    public int levelNumber;
    //临时用变量
    public int linshi;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        linshi = levelNumber - 1;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 增加解锁的关卡数量
    /// </summary>
    /// <param name="i"></param>当前通关的关卡号
    public void AddNumber(int i)
    {
        levelNumber = i + linshi+1;
    }
}
