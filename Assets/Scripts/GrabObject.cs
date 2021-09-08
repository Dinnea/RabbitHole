using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    HandFollowMouse hand;
    ZoomInCamera mainCamera;
    public Bunny bunny;


    public GameObject heldObject;
    [SerializeField] private Transform pickUpSlot;
    bool isHolding = false;
    bool isActing = false;
    bool hit;
    RaycastHit hitInfo = new RaycastHit();

    private void Start()
    {
        hand = GetComponent<HandFollowMouse>();
        mainCamera = Camera.main.GetComponent<ZoomInCamera>();
        bunny = FindObjectOfType<Bunny>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            bool isRabbit = hitInfo.transform.CompareTag("Rabbit");
            if (!isHolding && !isRabbit) PickUp();
            else if (isHolding && isRabbit && !isActing) Action();
            else if (!isHolding && isRabbit && !isActing)
            {
                bunny.TakeCare("Pet");
                hand.isMoving = false;
                mainCamera.isMoving = false;
                Invoke("Drop", 2);
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
            else Debug.Log("Nothing to grab.");
        }
        else Debug.Log("Nothing to grab.");
    }

    void Action()
    {
        isActing = true;
        bunny.TakeCare(heldObject.name);
        hand.isMoving = false;
        mainCamera.isMoving = false;
        Invoke("Drop", 2);
        //do an action, then drop the item
    }

    void Drop()
    {        
        if (heldObject != null)
        {
            Grabbable grabbable = GetComponentInChildren<Grabbable>();
            heldObject.transform.SetParent(null);
            grabbable.ResetPosition();
            heldObject = null;
        }
       
        hand.isMoving = true;
        mainCamera.isMoving = true;
        isActing = false;
        isHolding = false;
    }
}
