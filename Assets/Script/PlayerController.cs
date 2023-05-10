using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController Player;
    //private Rigidbody Player;
    private Animator animator;

    //movimiento
    public float fSpeed = 30f;
    public float bSpeed = 20f;

    private float hor;
    private float ver;
    private Vector3 playerInput;

    //Camara
    public Camera mainCam;

    private Vector3 forward;
    private Vector3 right;
    private Vector3 movePlayer;

    //gravedad
    public float gravity = 9.81f;

    void Start()
    {
        Player = GetComponent<CharacterController>();
        //Player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
       
        if (hor != 0 || ver != 0)
        {
            playerInput = new Vector3(hor,0,ver);
            playerInput = Vector3.ClampMagnitude(playerInput, 1);

            CamDirection();

            movePlayer = playerInput.x * forward + playerInput.z * right;
            if (ver <= 0)
            {
                movePlayer = movePlayer * fSpeed;
            }
            else
            {
                movePlayer = movePlayer * bSpeed;
            }

            SetGravity();

            Player.Move(playerInput * Time.deltaTime);
            //Player.MovePosition(transform.position + playerInput * Time.deltaTime);

            Debug.Log(Player.velocity.magnitude);      

            animator.SetFloat("ySpeed", ver);
            animator.SetFloat("xSpeed", hor);
        }

        
    }

    void CamDirection()
    {
        forward = mainCam.transform.forward;
        right = mainCam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;
    }

    void SetGravity()
    {
        movePlayer.y = -gravity * Time.deltaTime;
    }
}
