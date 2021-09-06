using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    HandFollowMouse hand;
    public GameObject heldObject;
    [SerializeField] private Transform pickUpSlot;
    bool isHolding = false;
    bool hit;
    RaycastHit hitInfo = new RaycastHit();

    private void Start()
    {
        hand = GetComponent<HandFollowMouse>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (!isHolding) PickUp();
            else if (isHolding && hitInfo.transform.gameObject.CompareTag("Rabbit"))
            {
                Debug.Log("Do an action");
                hand.isMoving = false;
                Invoke("Drop", 2);
                //do an action, then drop the item
            }
            else Drop();
        }
    }
    void PickUp()
    {
        
        
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
        hand.isMoving = true;
        isHolding = false;
    }
}
