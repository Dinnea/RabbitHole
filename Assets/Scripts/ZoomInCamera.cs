using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInCamera : MonoBehaviour
{
    /* 
     // V1 - basic fov manipulation
     * [SerializeField] float zoomSpeed = 1;
      private Camera mainCamera;

      private void Start()
      {
          mainCamera = Camera.main;
      }

      private void Update()
      {
          if (mainCamera.fieldOfView <= 60 && mainCamera.fieldOfView >= 22.75)
          {
              mainCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
          }
          else if (mainCamera.fieldOfView > 60)
          {
              mainCamera.fieldOfView = 60;
          }
          else if (mainCamera.fieldOfView < 22.75)
          {
              mainCamera.fieldOfView = 22.75f;
          }
      }*/

    //---------------------------------------------------------------------
    //              V2 - Smooth Camera Zoom (using LERP)
    //---------------------------------------------------------------------
    private Camera _mainCamera;
    private float _distance = 50;
    private float _sensitivityDistance = 10;
    private float _damping = 5;

    private float _minFOV = 10;
    private float _maxFOV = 60;

    public bool isMoving; 

    private void Start()
    {
        isMoving = true;
        _mainCamera = Camera.main;
        _distance = _mainCamera.fieldOfView;
    }

    private void Update()
    {
        if (isMoving) ZoomCamera(); //only execute if isnt frozen
    }

    private void ZoomCamera()
    {
        _distance -= Input.GetAxis("Mouse ScrollWheel") * _sensitivityDistance;
        _distance = Mathf.Clamp(_distance, _minFOV, _maxFOV);                     //limit the movement to desired borders
        _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _distance, Time.deltaTime * _damping); //smooth zoom
    }
}
