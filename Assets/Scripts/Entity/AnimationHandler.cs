using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("isMove");
    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        //움직임이 0.5보다 크면 true
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);
    }

    public void Damage()
    {
        
    }

    public void InvincibilityEnd()
    {
       
    }
}
