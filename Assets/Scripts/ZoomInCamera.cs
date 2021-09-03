using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInCamera : MonoBehaviour
{
   [SerializeField] float zoomSpeed = 10;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        mainCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    }
}
