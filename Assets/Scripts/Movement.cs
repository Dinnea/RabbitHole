using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /*private float _horizontal;
    private float _vertical;
    private float _speed = 2.5f;
    private float _rotationSpeed = 0.5f;

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) transform.position += transform.forward * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) transform.position -= transform.forward * _speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, _horizontal * _rotationSpeed, 0));
    }*/
    [SerializeField] CharacterController _controller;
    [SerializeField] private float _speed = 12f;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move*_speed*Time.deltaTime);
    }
}
