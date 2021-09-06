using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public GameObject heldObject;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.CompareTag("Grabbable"))
                {
                    heldObject = hitInfo.collider.gameObject;
                    heldObject.active = false;

                    Debug.Log("Grabbed " + heldObject.name);
                }
                else
                {
                    Debug.Log("Nothing to grab.");
                }
            }
            else
            {
                Debug.Log("Nothing to grab.");
            }
        }
    }
}
