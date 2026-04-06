using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    public float speed, rotateSpeed;
    private Rigidbody rigidBody;
    private Vector3 direction;
    private float vertical, horizontal;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        direction = (transform.forward * vertical).normalized;
        rigidBody.MovePosition(rigidBody.position + direction * speed * Time.fixedDeltaTime);

        Quaternion turn = Quaternion.Euler(0f, horizontal * rotateSpeed * speed * Time.fixedDeltaTime, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * turn);

        animator.SetFloat("MoveSpeed", vertical);
    }
}
