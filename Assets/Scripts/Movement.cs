using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    /*private float _horizontal;
    private float _vertical;
    private float _speed = 2.5f;
    private float _rotationSpeed = 0.5f;

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) transform.position += transform.forward * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) transform.position -= transform.forward * _speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, _horizontal * _rotationSpeed, 0));
    }*/
    [SerializeField] CharacterController _controller;
    [SerializeField] private float _speed = 12f;

    [SerializeField] GameObject _audioSource;
    AudioSource _whatTheFuck;
    AudioSource _footsteps;
    bool _isPlaying = false;

    [SerializeField] GameObject _blackoutCanvas;
    [SerializeField] GameObject _button1;
    [SerializeField] GameObject _light;
    private Blackout _blackout;

    private void Start()
    {
        _footsteps = GetComponent<AudioSource>();
        _whatTheFuck = _audioSource.GetComponent<AudioSource>();
        _blackout = _blackoutCanvas.GetComponent<Blackout>();
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move*_speed*Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ))
        {
            if( !_isPlaying)
            {
                _footsteps.Play(0);
                _isPlaying = true;
            }
        }

        else if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) ||
           Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) ||
           Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) ||
           Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            if (_isPlaying)
            {
                _footsteps.Stop();
                _isPlaying = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _whatTheFuck.Play();
            StartCoroutine(TheEnd());
        }
        if (other.CompareTag("Light Change"))
        {
            _light.SetActive(false);
        }
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(5);
        Cursor.visible = true;
        _button1.SetActive(true);
    }
    public void Ending()
    {
        StartCoroutine(_blackout.FadeToBlack(true));
    }
}
