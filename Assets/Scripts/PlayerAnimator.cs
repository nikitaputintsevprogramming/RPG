using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{    
    const float motionAnimatorSmoothTime = 0.1f;

    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();    
    }
    
    void FixedUpdate()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, motionAnimatorSmoothTime, Time.deltaTime);
    }
}
