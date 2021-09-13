using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitChoiceEvents : MonoBehaviour
{
    [SerializeField]  int _rabbitChoiceIndex;
    private List<Vector3> _rabbitPositions;
    [SerializeField] float _rotationSpeed = 10;
    public string furColour;
    private RabbitChoiceInfo _rabbitStats;
    private RabbitMovement _rabbitMovement;

    private void Start()
    {
        _rabbitStats = FindObjectOfType<RabbitChoiceInfo>();
        _rabbitMovement = GetComponent<RabbitMovement>();
        _rabbitMovement.enabled = false;

        //assigns possible rabbit locations
        _rabbitPositions = new List<Vector3>(); 
        _rabbitPositions.Add(new Vector3(0, 1, -0.75f));
        _rabbitPositions.Add(new Vector3(-3, 0.75f, 1));
        _rabbitPositions.Add(new Vector3(0, 1, 3));
        _rabbitPositions.Add(new Vector3(3, 0.75f, 1));

        MoveRabbits(); //moves them to right spots if they happen to not be there
    }

    private void Update()
    {
        if (_rabbitChoiceIndex == 1 ) //rotates the rabbit in front, the selected rabbit
        {
            RotateTheRabbit();
        }
       
    }

    private void OnLevelWasLoaded(int level) 
    {
        if (level != 1)
        {
            _rabbitMovement.enabled = true;
            this.enabled = false;
        }
    }

    private void RotateTheRabbit()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    void MoveRabbits()
    {
        switch (_rabbitChoiceIndex) //where rabbits are supposed to be is based on their index nr    
        {
            case 1:
                transform.position = _rabbitPositions[0];
                break;
            case 2:
                transform.position = _rabbitPositions[1];
                break;
            case 3:
                transform.position = _rabbitPositions[2];
                break;
            case 4:
                transform.position = _rabbitPositions[3];
                break;
        }
        if (_rabbitChoiceIndex == 1)
        {
            _rabbitStats.furColour = furColour;
        }

        if (_rabbitChoiceIndex != 0) transform.rotation = Quaternion.identity;
    }

    public void RightPressed() //moves rabbits to the right
    {
        if (_rabbitChoiceIndex == 1) _rabbitChoiceIndex = 4;
        else _rabbitChoiceIndex--;
        MoveRabbits();
    }

    public void LeftPressed() //moves rabbits to the left
    {
        if (_rabbitChoiceIndex == 4) _rabbitChoiceIndex = 1;
        else _rabbitChoiceIndex++;
        MoveRabbits();
    }

    public void RabbitChosen() //rabbit selected, can name it
    {
        if (_rabbitChoiceIndex != 1) gameObject.SetActive(false);
        else transform.position += new Vector3(0, 0.35f, 0);
    }
    public void EnableChoice() //triggered if the "go back" button is used
    {
        if (_rabbitChoiceIndex != 1) gameObject.SetActive(true);
        else transform.position -= new Vector3(0, 0.35f, 0);
    }

    public void FinalChoice()
    {
        if (_rabbitStats.IsRabbitNamed())
        {
            //this is to keep the parent, but destroy the rabbit children
            //(new one is spawned next level)
                gameObject.SetActive(true);
                Destroy(gameObject);
        }       
    }
}
