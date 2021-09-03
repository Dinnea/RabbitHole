using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitChoiceEvents : MonoBehaviour
{
    [SerializeField]  int rabbitChoiceIndex;
    List<Vector3> rabbitPositions;
    [SerializeField] float rotationSpeed = 10;
    public string furColour;
    RabbitStats rabbitStats;
    RabbitMovement rabbitMovement;

    private void Start()
    {
        rabbitMovement = GetComponent<RabbitMovement>();
        rabbitMovement.enabled = false;

        rabbitPositions = new List<Vector3>(); //assigns possible rabbit locations
        rabbitPositions.Add(new Vector3(0, 1, -0.75f));
        rabbitPositions.Add(new Vector3(-3, 0.75f, 1));
        rabbitPositions.Add(new Vector3(0, 1, 3));
        rabbitPositions.Add(new Vector3(3, 0.75f, 1));

        MoveRabbits();

        switch (rabbitChoiceIndex)
        {
            case 1:
                furColour = "white";
                break;
            case 2:
                furColour = "brown";
                break;
            case 3:
                furColour = "grey";
                break;
            case 4:
                furColour = "black";
                break;
        }
    }

    private void Update()
    {
        if (rabbitChoiceIndex == 1 ) //rotates the rabbit in front, the selected rabbit
        {
            rotate();
        }
       
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            rabbitMovement.enabled = true;
            this.enabled = false;
        }
    }

    private void rotate()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void MoveRabbits()
    {
        switch (rabbitChoiceIndex) //where rabbits are supposed to be is based on their index nr    
        {
            case 1:
                transform.position = rabbitPositions[0];
                break;
            case 2:
                transform.position = rabbitPositions[1];
                break;
            case 3:
                transform.position = rabbitPositions[2];
                break;
            case 4:
                transform.position = rabbitPositions[3];
                break;
        }

        if (rabbitChoiceIndex != 0) transform.rotation = Quaternion.identity;
    }

    public void RightPressed() //moves rabbits to the right
    {
        if (rabbitChoiceIndex == 1) rabbitChoiceIndex = 4;
        else rabbitChoiceIndex--;
        MoveRabbits();
    }

    public void LeftPressed() //moves rabbits to the left
    {
        if (rabbitChoiceIndex == 4) rabbitChoiceIndex = 1;
        else rabbitChoiceIndex++;
        MoveRabbits();
    }

    public void RabbitChosen() //rabbit selected, can name it
    {
        if (rabbitChoiceIndex != 1) gameObject.SetActive(false);
        else transform.position += new Vector3(0, 0.35f, 0);
    }
    public void EnableChoice() //triggered if the "go back" button is used
    {
        if (rabbitChoiceIndex != 1) gameObject.SetActive(true);
        else transform.position -= new Vector3(0, 0.35f, 0);
    }

    public void FinalChoice()
    {
        rabbitStats = GetComponentInParent<RabbitStats>();

        if (rabbitStats.IsRabbitNamed())
        {
            if (rabbitChoiceIndex != 1)
            {
                gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }       
    }
}
