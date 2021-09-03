using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollowMouse : MonoBehaviour
{
    Vector3 mouseLocation;
    float mouseZ = 5f;


    private void Start()
   {
        mouseLocation= Input.mousePosition;
       
        Cursor.visible = false; 
   }

    void Update()
    {

        
        mouseLocation = Input.mousePosition;
        mouseLocation.z = mouseZ;





        this.transform.position = new Vector3 (mouseLocation.x, mouseLocation.z, mouseLocation.y);

        this.transform.position = Camera.main.ScreenToWorldPoint(mouseLocation);


    }
}
