using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimationBack()
    {
        Debug.Log("动画执行完毕，触发了代码！");
        animator.SetBool("movestart", false);
        EventManager.instance.AnimationBack();
        animator.SetBool("moveend", true);
    }
    public void AnimationBack1()
    {
        Debug.Log("动画执行完毕，触发了代码！");
        animator.SetBool("moveend", false);
    }
}
