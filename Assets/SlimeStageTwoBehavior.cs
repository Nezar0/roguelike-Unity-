using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStageTwoBehavior : StateMachineBehaviour
{
    public GameObject slime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0; i < 3; i++) 
            Instantiate(slime, animator.rootPosition, Quaternion.identity);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("idle");
    }
}
