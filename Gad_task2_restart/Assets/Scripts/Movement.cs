using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float maxVelocity;
    private float sqrMaxVelocity;

    private SphereCollider spCollider;
    public GameObject groundcheck;
    private groundcheck Groundcheck;

    public float Vertical;
    public float Horizontal;
    public float Speed;
    public float Jump;

    public float Fall_multiplier;

    private bool grounded = false;

    public bool DisableControls = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setMaxVelocity(maxVelocity);
        spCollider = GetComponent<SphereCollider>();
        Groundcheck = groundcheck.GetComponent<groundcheck>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude > sqrMaxVelocity)
        {
            rb.velocity = rb.velocity.normalized * (maxVelocity - 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(DisableControls == false)
        {
            grounded = Groundcheck.isGrounded;
            float Horizontal = Input.GetAxisRaw("Horizontal");
            float Verticle = Input.GetAxisRaw("Vertical");

            Vector3 controllmove = new Vector3(Horizontal, 0, Verticle);
            rb.velocity += controllmove * Speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                jump();

            }
            fall_Multiplier();
        }
        else { }
       

    }
    public void jump()
    {
        //Debug.Log("jump");
       
        Groundcheck.isGrounded = false;
        rb.velocity += Vector3.up * Jump;

    }
    private void fall_Multiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (Fall_multiplier - 1) * Time.deltaTime;
        }
    }
    private void setMaxVelocity(float maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }
}
