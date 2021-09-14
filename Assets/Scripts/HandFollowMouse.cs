using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollowMouse : MonoBehaviour
{
    //------------------------------------------------------
    //                      Hand movement
    //------------------------------------------------------
    private Vector3 _mouseLocation;
    private float _mouseZ = 5f; //z default

    [SerializeField] float _handZoomSpeed = 2;

    private float _minZ = 2.5f;
    private float _maxZ = 15f;
    private float _damping = 7.5f;

    public bool isMoving = true;


    private void Start()
   {       
        _mouseLocation= Input.mousePosition;       
        Cursor.visible = false; 
   }

    void Update()
    {
        if (isMoving) HandMove();
    }

    void HandMove()
    {
        _mouseLocation = Input.mousePosition;
        _mouseLocation.z = _mouseZ; //only x + y are dictated by mouse position (up - down, left - right)

        _mouseZ += Input.GetAxis("Mouse ScrollWheel") * _handZoomSpeed; //z (depth) is dictated by mouse scroll
        _mouseZ = Mathf.Clamp(_mouseZ, _minZ, _maxZ); //dont move out of range! (depth)

        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(_mouseLocation), Time.deltaTime * _damping); //smooth movement
                                                               //Hand moves based on camera perspective (if it was angled, z value would change to keep hand at the same depth from camera)
    }
}
