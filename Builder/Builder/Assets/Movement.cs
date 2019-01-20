using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator animator;
    CharacterController controller;
    public float speed = 2.2f;
    Rigidbody rb;
    Vector3 moveDirection;
    [SerializeField] bool control;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, 0);
        if(moveDirection != Vector3.zero && !control)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 999f);
            rb.MovePosition(transform.position + (transform.forward * speed) * Time.deltaTime);
            controller.Move(moveDirection * speed * Time.deltaTime);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    public void Enable_Control()
    {
        if (control)
        {
            Debug.Log("Control enebled");
            return;
        }
        control = true;
    }

    public void Disable_Control()
    {
        if (!control)
        {
            Debug.Log("Control disabled");
            return;
        }
        control = false;
    }

    // Update is called once per frame
    void Update () {

        //    float h = Input.GetAxis("Horizontal");

        //    if (h != 0)
        //    {
        //        Vector3 dir = transform.TransformDirection(new Vector3(0f, 0f, -h * speed * Time.deltaTime));
        //        controller.Move(dir);
        //        animator.SetBool("Run", true);
        //    }
        //    else
        //    {
        //        animator.SetBool("Run", false);
        //    }

        //    if (Input.GetKeyDown(KeyCode.A))
        //        transform.forward = new Vector3(1f, 0f, 0f);
        //    else if (Input.GetKeyDown(KeyCode.D))
        //        transform.forward = new Vector3(-1f, 0f, 0f);


    }

}
