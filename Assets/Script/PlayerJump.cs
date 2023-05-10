using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody Player;
    private Animator animator;

    //salto
    public float jSpeed = 1f;
    private bool inGround = true;
    public int maxJump = 2;
    public int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetButton("Jump");

        if (jump && (inGround || maxJump > jumpCount))
        {
            Player.velocity = new Vector3(0, jSpeed, 0 * Time.deltaTime);
            inGround = false;
            jumpCount++;
            animator.SetTrigger("jump");

        }
    }

    void onCollisionEnter(Collision coll)
    {
        inGround = true;
        jumpCount = 0;
    }
}
