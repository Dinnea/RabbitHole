using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    /* V1
     Vector3 lastDragPosition;
     Vector3 change;
     Vector3 target;

     void LateUpdate()
     {
         
         Drag();
     }

     void Drag()
     {
        target.y = Mathf.Clamp(change.y, 0.4f, 2.2f);
        if (Input.GetMouseButtonDown(0)) lastDragPosition = Input.mousePosition;

         if (Input.GetMouseButton(0))
         {
             
            change = lastDragPosition - Input.mousePosition;
            target = transform.position += change;
            transform.position = target;
             //transform.Translate(change * Time.deltaTime * 0.5f);
             lastDragPosition = Input.mousePosition;
         }
     }/**/

    //V2 - bounds included
    public int cameraDragSpeed = 200;
    Vector3 boundsMax = new Vector3( 5.1f, 2.5f, -9.54f);
    Vector3 boundsMin = new Vector3(-6.3f, -0.19f, -9.54f);

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundsMin.x, boundsMax.x), Mathf.Clamp(transform.position.y, boundsMin.y, boundsMax.y), Mathf.Clamp(transform.position.z, boundsMin.z, boundsMax.z));
        if (Input.GetMouseButton(1))
        {
            float speed = cameraDragSpeed * Time.deltaTime;
            transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed, 0);
        }
    }/**/
}