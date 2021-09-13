using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrabObject : MonoBehaviour
{
    //-----------------------------------------------------
    //                   Variables
    //-----------------------------------------------------
    private HandFollowMouse _hand;
    private ZoomInCamera _mainCamera;
    public Bunny bunny;


    public GameObject heldObject; //what is being held
    [SerializeField] private Transform _pickUpSlot; //where its being held
    private bool _isHolding = false;
    private bool _isActing = false;
    private bool _hit;
    private RaycastHit _hitInfo = new RaycastHit();

    [SerializeField] Canvas _popup;
    private PopUpTextLevel _popUpText;


    private void Start()
    {
        _hand = GetComponent<HandFollowMouse>();
        _mainCamera = Camera.main.GetComponent<ZoomInCamera>();
        bunny = FindObjectOfType<Bunny>();
        _popUpText = _popup.GetComponent<PopUpTextLevel>();
        
    }
    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            _hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo);
            bool isRabbit = false;
            if (_hitInfo.transform != null) isRabbit = _hitInfo.transform.CompareTag("Rabbit"); //is this a rabbit?
            if (!_isHolding && !isRabbit) PickUp(); //If I am not holding anything and this is not a rabbit... Pick up
            else if (_isHolding && isRabbit && !_isActing) Act(); //if I am holding somehting and there is a rabbit, but I am not yet acting... Act.
            else if (!_isHolding && isRabbit && !_isActing) //if I am not holding anything and, there is a rabbit and am not yet acting... Pet the rabbit!
            {
                //Pet
                bunny.TakeCare("pet");
                _hand.isMoving = false;
                _mainCamera.isMoving = false;
                StartCoroutine(DropAfterTime(2, true));
            }
            else Drop(false);
        }
    }
    //-------------------------------------------------------------
    //                    Hand Actions
    //---------------------------------------------------------------
    void PickUp()
    {
        
        
        if (_hit)
        {
            bunny = FindObjectOfType<Bunny>();
            Debug.Log("Hit " + _hitInfo.transform.gameObject.name);
            if (_hitInfo.transform.CompareTag("Grabbable")) //Can you pick up the object?
            {
                heldObject = _hitInfo.collider.gameObject; //object being picked up
                heldObject.transform.SetParent(_pickUpSlot); //placed in pick up slot
                heldObject.transform.localPosition = Vector3.zero; //located at pick up slot
                _isHolding = true;
                _popUpText.TurnOn("Grabbed " + heldObject.name);
            }
            else if (_hitInfo.transform.CompareTag("Carrier") && bunny.actionsDone == 2) //transition next day 
            {
                bunny.NextDay();
            }
            else _popUpText.TurnOn("Nothing to grab.");
        }
        else _popUpText.TurnOn("Nothing to grab.");
    }

    void Drop(bool doneAction) 
    {
        if (heldObject != null) //prevent null exceptions
        {
            Grabbable grabbable = GetComponentInChildren<Grabbable>(); //what am i holding?
            heldObject.transform.SetParent(null); //no longer held!
            grabbable.ResetPosition(); //placed at its original place 
            if (!doneAction) _popUpText.TurnOn("Dropped " + heldObject.name); //if dropped when NOT acting, show popup (else Bunny.cs shows popups)
            heldObject = null; //nothing is held        
        }

        _hand.isMoving = true; //unfreeze the hand movement
        _mainCamera.isMoving = true; //unfreeze the camera
        _isActing = false; //isnt acting anymore
        _isHolding = false; // isnt holding anymore
    }

    void Act() //Do something with the object
    {
        bunny.TakeCare(heldObject.name); //take care of the rabbit with the object held
        _isActing = true;        
        _hand.isMoving = false; //freeze hand
        _mainCamera.isMoving = false; //freeze camera
        StartCoroutine(DropAfterTime(2, true)); //do an action, then drop the item
    }

    IEnumerator DropAfterTime(float time, bool doneAction)
    {
        yield return new WaitForSeconds(time);
        Drop(doneAction);
    }
}
