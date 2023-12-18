using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLock : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelLock instance;
    [Header("��ǰ�����Ĺؿ���")]
    public int levelNumber;
    //��ʱ�ñ���
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
    /// ���ӽ����Ĺؿ�����
    /// </summary>
    /// <param name="i"></param>��ǰͨ�صĹؿ���
    public void AddNumber(int i)
    {
        levelNumber = i + linshi+1;
    }
}