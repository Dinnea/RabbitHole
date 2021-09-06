using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public GameObject heldObject;
    [SerializeField] private Transform pickUpSlot;
    bool isHolding = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");
            if (!isHolding) PickUp();
            else if (isHolding) Drop();
        }
    }
    void PickUp()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            if (hitInfo.transform.CompareTag("Grabbable"))
            {
                heldObject = hitInfo.collider.gameObject;
                heldObject.transform.SetParent(pickUpSlot);
                heldObject.transform.localPosition = Vector3.zero;
                isHolding = true;
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

    void Drop()
    {
        Grabbable grabbable = GetComponentInChildren<Grabbable>();
        heldObject.transform.SetParent(null);
        grabbable.ResetPosition();
        heldObject = null;
        isHolding = false;
    }
}
