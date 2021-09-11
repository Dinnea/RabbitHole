using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    [SerializeField] Canvas popup;
    private PopUpTextLevel popUpText;


    private void Start()
    {
        hand = GetComponent<HandFollowMouse>();
        mainCamera = Camera.main.GetComponent<ZoomInCamera>();
        bunny = FindObjectOfType<Bunny>();
        popUpText = popup.GetComponent<PopUpTextLevel>();
        
    }
    private void Update()
    {
        //if(heldObject != null) Debug.Log(heldObject.name);
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            bool isRabbit = false;
            if (hitInfo.transform != null) isRabbit = hitInfo.transform.CompareTag("Rabbit");
            if (!isHolding && !isRabbit) PickUp();
            else if (isHolding && isRabbit && !isActing) Action();
            else if (!isHolding && isRabbit && !isActing)
            {
                bunny.TakeCare("pet");
                hand.isMoving = false;
                mainCamera.isMoving = false;
                StartCoroutine(ExecuteAfterTime(2, true));
            }
            else Drop(false);
        }
    }
    void PickUp()
    {
        
        
        if (hit)
        {
            bunny = FindObjectOfType<Bunny>();
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            if (hitInfo.transform.CompareTag("Grabbable"))
            {
                heldObject = hitInfo.collider.gameObject;
                heldObject.transform.SetParent(pickUpSlot);
                heldObject.transform.localPosition = Vector3.zero;
                isHolding = true;
                popUpText.TurnOn("Grabbed " + heldObject.name);
            }
            else if (hitInfo.transform.CompareTag("Carrier") && bunny.actionsDone == 2)
            {
                bunny.NextDay();
            }
            else popUpText.TurnOn("Nothing to grab.");
        }
        else popUpText.TurnOn("Nothing to grab.");
    }

    void Drop(bool doneAction)
    {
        if (heldObject != null)
        {
            Grabbable grabbable = GetComponentInChildren<Grabbable>();
            heldObject.transform.SetParent(null);
            grabbable.ResetPosition();
            if (!doneAction) popUpText.TurnOn("Dropped " + heldObject.name);
            heldObject = null;
            
        }

        hand.isMoving = true;
        mainCamera.isMoving = true;
        isActing = false;
        isHolding = false;
    }

    void Action()
    {
        bunny.TakeCare(heldObject.name);
        isActing = true;        
        hand.isMoving = false;
        mainCamera.isMoving = false;
        StartCoroutine(ExecuteAfterTime(2, true));
        //do an action, then drop the item
    }

    IEnumerator ExecuteAfterTime(float time, bool doneAction)
    {
        yield return new WaitForSeconds(time);
        Drop(doneAction);
    }
}
