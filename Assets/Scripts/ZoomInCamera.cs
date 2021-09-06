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

    //V2 - smootth (LERP) camera movement
    private Camera mainCamera;
    float distance = 50;
    float sensitivityDistance = 10;
    float damping = 5;

    float minFOV = 25;
    float maxFOV = 60;

    private void Start()
    {
        mainCamera = Camera.main;
        distance = mainCamera.fieldOfView;
    }

    private void Update()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
        distance = Mathf.Clamp(distance, minFOV, maxFOV);                     //limit the movement to desired borders
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, distance, Time.deltaTime * damping);
    }

}
