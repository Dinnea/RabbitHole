using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollowMouse : MonoBehaviour
{
    /*
   public Rigidbody rigidbody;

   void Update()
   {
       rigidbody.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
   }*/

    
   private void Start()
   {
        Cursor.visible = false; 
   }

    void Update()
    {

        Plane plane = new Plane(Vector3.up, new Vector3(0, 0.5f, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            transform.position = ray.GetPoint(distance);
        }
        /*Vector3 mouseLocation = Input.mousePosition;
        mouseLocation = Input.mousePosition;
        /*
        if (Input.GetAxis("Vertical") > 0)
        {
            mouseLocation.z += 1;
        }
        mouseLocation.z = 5f;

        this.transform.position = new Vector3 (mouseLocation.x, mouseLocation.z, mouseLocation.y);

        this.transform.position = Camera.main.ScreenToWorldPoint(mouseLocation);*/


    }
}
