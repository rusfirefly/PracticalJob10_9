using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;

    private float _gravity = -9.81f;
    private Vector3 _velocity;

    [SerializeField] private Transform _grountCheck;
    [SerializeField] private LayerMask _groundMask;
    private float _jumpHeight = 3f;
    private float _groundDistance = 0.4f;
    private bool _isGround;


    private void Update()
    {
        _isGround = Physics.CheckSphere(_grountCheck.position, _groundDistance, _groundMask);

        if(_isGround && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && _isGround)
        {
            Debug.Log("jump");
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        Move(x, z);
        Gravity();
    }

    private void Move(float x, float z)
    {
        Vector3 move = (transform.right * x + transform.forward * z) * _speed;
        _controller.Move(move * Time.deltaTime);
    }

    private void Gravity()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
