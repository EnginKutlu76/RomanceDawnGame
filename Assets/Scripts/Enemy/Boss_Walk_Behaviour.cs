using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk_Behaviour : StateMachineBehaviour
{
    public BossController boss;
    private Rigidbody2D rb;
    public float moveSpeed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<BossController>();
        rb = boss.rb;
        boss.LookPlayer();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y) * animator.transform.right;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
