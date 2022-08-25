using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carousel{
   

public class Handanimation : MonoBehaviour
{
    public float speed;
    Animator animator;
    private float gripTarget;
    private float gripcurrent;
    private float gripRTarget;
    private float gripRcurrent;
    private string animatorTriggerParam = "Trigger";
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
 void Update()
    {
        AnimateLeftHand();
        AnimateRightHand();
    }
  
   public void SetLeftGrip(float v)
    { 
        gripTarget = v;
    }

    void AnimateLeftHand()
    {
        if(gripcurrent != gripTarget){
            
            gripcurrent = Mathf.MoveTowards(gripcurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, gripcurrent);
            animator.SetBool("ButtonPressed", true);
         }
        else
        {
          animator.SetBool("ButtonPressed", false);
        }
    }
    public void SetRightGrip(float v)
    {
        gripRTarget = v;
    }

    void AnimateRightHand()
    {
        if(gripcurrent != gripRTarget){
            gripRcurrent = Mathf.MoveTowards(gripRcurrent, gripRTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, gripRcurrent);
            animator.SetBool("Switch", true);
        }
        else
        {
          animator.SetBool("Switch", false);
        }
    }
}
}