using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelLock;
    public int number;
    void Start()
    {
        levelLock = GameObject.Find("LevelLock");
        if(number<=(levelLock.GetComponent<LevelLock>().levelNumber-levelLock.GetComponent<LevelLock>().linshi))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
