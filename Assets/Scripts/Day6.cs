using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Day6 : MonoBehaviour
{
    [SerializeField] private GameObject _popUp;
    private TextMeshProUGUI _popUpText;
    [SerializeField] private GameObject _hand;
    
    [SerializeField] private Camera _camera1;
    [SerializeField] private Camera _camera2;
    MouseLook _mouseLook;

    bool _hasTurned = false;


    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_hasTurned)
        {
            _hand.SetActive(false);
            _camera1.GetComponent<AudioListener>().enabled = false;
            _camera1.enabled = false;

            _camera2.enabled = true;
            _camera2.GetComponent<AudioListener>().enabled = true;

            StartCoroutine(gameObject.GetComponent<RotatePlayer>().Rotate(new Vector3 (0, 90, 0), 5));
            _popUpText.text = "Press W or UP to move forwards. Move your mouse to look around.";
            _hasTurned = true;
            _mouseLook = GetComponentInChildren<MouseLook>();
            _mouseLook.isMovingFreely = true;
        }
    }

    public void Starting(GameObject obj, GameObject ui)
    {
        _popUpText = _popUp.GetComponentInChildren<TextMeshProUGUI>();
        obj.SetActive(false);
        ui.SetActive(false);
        _hand.SetActive(false);

        _camera1.GetComponent<AudioListener>().enabled = false;
        _camera1.enabled = false;
        
        _camera2.enabled = true;
        _camera2.GetComponent<AudioListener>().enabled = true;
        _popUp.SetActive(true);


    }
}
