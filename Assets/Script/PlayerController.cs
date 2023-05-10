using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Player;
    private Animator animator;

    public float speed = 30;
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;
        float movSpeed = 0;

        if (hor != 0 || ver != 0)
        {
            Vector3 forward = transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = transform.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            movSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            if (ver <= 0)
            {
                movement = direction * 20 * movSpeed * Time.deltaTime;
            }
            else
            {
                movement = direction * speed * movSpeed * Time.deltaTime;
            }
            //movement = direction * speed * movSpeed * Time.deltaTime;

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }

    //movement.y += gravity * Time.deltaTime;

    Player.MovePosition(transform.position + movement);
    animator.SetFloat("ySpeed", ver);
    animator.SetFloat("xSpeed", hor);
    }
}
