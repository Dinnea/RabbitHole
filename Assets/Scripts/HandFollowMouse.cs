using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollowMouse : MonoBehaviour
{
    Vector3 mouseLocation;
    float mouseZ = 5f;
    float oldMouseZ;

    [SerializeField] float handZoomSpeed = 1;

    float minZ = 3.5f;
    float maxZ = 9.5f;
    float damping = 7.5f;


    private void Start()
   {
        
        mouseLocation= Input.mousePosition;       
        Cursor.visible = false; 
   }

    void Update()
    {
        oldMouseZ = mouseZ;        
        mouseLocation = Input.mousePosition;
        mouseLocation.z = mouseZ;
        
        mouseZ += Input.GetAxis("Mouse ScrollWheel") * handZoomSpeed;
        mouseZ = Mathf.Clamp(mouseZ, minZ, maxZ);
        
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(mouseLocation), Time.deltaTime*damping); //smooth movement


    }
}
