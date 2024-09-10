using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
      public CharacterController controller;
        public float w_speed = 9f;
        public float s_speed = 13.5f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;
        public float c_speed, nHeight, cHeight;
        public float dashingPower = 20f;
        public float dashingTime = 0.3f;
        public float dashingCooldown = 0.75f;
        public float dashRate = 2;
        private float timeToDash;
        public Vector3 offset;
        public Transform player;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public float threshold;
        public LayerMask groundMask;

        Vector3 velocity;
        bool isMoving;
        bool isGrounded;
        bool crouching;
        bool dashing = true;
        [SerializeField] PlayerAttributes pa;
        [SerializeField] ManaBar mb;

    // if the player goees below the y threshold teleport them back to where they begun at 0, 2, 0
    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }
    }   

    // check to see if the player is grounded, and if the player is grounded set the y velocity to -2.
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

    // making more variables and assets
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //moving
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * w_speed * Time.deltaTime);
         if (Input.GetKeyDown("w"))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp("w"))
        {
            isMoving = false;
        }

        //Crouching
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = !crouching;
        }
        if(crouching == true)
        {
            controller.height= controller.height - c_speed * Time.deltaTime;
            if(controller.height <= cHeight)
            {
                controller.height = cHeight;
            }
        }
        if(crouching == false)
        {
            controller.height= controller.height + c_speed * Time.deltaTime;
            if(controller.height < nHeight)
            {
                player.position = player.position + offset * Time.deltaTime;

            }
            if(controller.height >= nHeight)
            {
                controller.height = nHeight;
            }
        }

        //sprinting
        if(Input.GetKey(KeyCode.LeftShift) & isMoving == true & crouching == false)
        {
            controller.Move(move * s_speed * Time.deltaTime);
;
        }

        //jumping
        // if jump button is clicked (spcace bar) and the player is grounded jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
           
        //dashing
        if(Input.GetKeyDown("c") && dashing && isGrounded == true && crouching == false && Time.time >= timeToDash && mb.mana >= 5f)
    {
        StartCoroutine(Dash());
        timeToDash = Time.time + 1/dashRate;
        mb.loseDashMana(5);
    }
     else if(Input.GetKeyDown("c") && dashing && isGrounded == true && crouching == false && mb.mana < 5f)
        {
            Debug.Log("Out of Mana to Dash");
        }

    }

    
    
    private IEnumerator Dash()
    {
        dashing = true;
        velocity = new Vector3(transform.forward.x * dashingPower, 0f, transform.forward.z * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        velocity = Vector3.zero;
        yield return new WaitForSeconds(dashingCooldown);
        dashing = true;
    }
}