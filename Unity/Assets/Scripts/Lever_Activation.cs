using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Activation : MonoBehaviour
{
    public Animator animator;
    public GameObject linkedObject;


    public int leverPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("Position", leverPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivateLever()
    {
        if (leverPosition < 0)
        {
            leverPosition = 1;
            animator.SetInteger("Position", 1);
        } else
        {
            leverPosition = -1;
            animator.SetInteger("Position", -1);
        }
    }

}
