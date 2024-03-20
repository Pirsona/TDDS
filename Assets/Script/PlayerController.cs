using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    private Animator animator;

    private CharacterController _characterController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        _characterController= GetComponent<CharacterController>();  
    }

    void Update()
    {
        _moveVector = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            animator.SetBool("isForward", true);
        }
        else
        {
            animator.SetBool("isForward", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            animator.SetBool("isBack", true);
        }
        else
        {
            animator.SetBool("isBack", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            animator.SetBool("isRight", true);
        }
        else
        {
            animator.SetBool("isRight", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            animator.SetBool("isLeft", true);
        }
        else
        {
            animator.SetBool("isLeft", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
        if (_moveVector != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    void FixedUpdate()
    {

        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
