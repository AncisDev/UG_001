using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody rigibody;

    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveY != 0.0f || moveX != 0.0f)
        {
            Vector3 dir = (transform.forward * moveY + transform.right * moveX);

            rigibody.MovePosition(transform.position + dir);

        }

    }
}

