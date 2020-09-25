using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
    }

    private void Update()
    {
        //walk animation
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0) { 
            scale.x = Mathf.Abs(scale.x); 
        }
        
        transform.localScale = scale;

        //crouch animation
        BoxCollider2D crouchCollider, jumpCollider;
        crouchCollider = GetComponent<BoxCollider2D>();

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            //Debug.Log("Ctrl key is pressed");
            crouchCollider.offset = new Vector3(-0.1084875f,0.5984814f);
            crouchCollider.size = new Vector3(0.9654864f,1.302302f);
        }
        else
        {
            animator.SetBool("Crouch", false);
            crouchCollider.offset = new Vector3(-0.01487844f, 0.9900814f);
            crouchCollider.size = new Vector3(0.4513782f, 2.020973f);
        }

        //jump animation
        float jump = Input.GetAxisRaw("Vertical");

        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else {
            animator.SetBool("Jump", false);
        }

    }
}
