using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Bunny : MonoBehaviour
{
    GameObject info;
    RabbitChoiceInfo rabbitInfo;

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dayNumber;
    private TextMeshProUGUI loveNumber;
    private TextMeshProUGUI actionsNumber;
    private GameObject ui;
    private PopUpTextLevel popUp;

    //hardcoded
    public float love = 80;
    float trueLove = 80;
    public int day = 1;

    int actionsDone = 0;

    bool givenSnack = false;
    bool beenBrushed = false;
    bool beenBathed = false;
    bool givenMeds = false;
    bool beenPet = false;

    private void Awake()
    {
        info = GameObject.Find("PlayerRabbitInfo");
        rabbitInfo = info.GetComponent<RabbitChoiceInfo>();
        bunnyName = rabbitInfo.bunnyName;

        nameText = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
        nameText.text = rabbitInfo.bunnyName;

        dayNumber = GameObject.Find("Day").GetComponent<TextMeshProUGUI>();
        dayNumber.text += day;

        loveNumber = GameObject.Find("Love").GetComponent<TextMeshProUGUI>();
        loveNumber.text += love + "%";

        actionsNumber = GameObject.Find("actions").GetComponent<TextMeshProUGUI>();
        actionsNumber.text += 2 - actionsDone;
    }
    private void Start()
    {
        name = rabbitInfo.bunnyName;
        ui = GameObject.Find("UI");
        popUp = ui.GetComponentInChildren<PopUpTextLevel>();
        popUp.TurnOff();

    }
    private void Update()
    {
        

        // Bunny care

        
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            nameText = null;
            popUp = null;
        }
    }

    //Bunny care

    public void TakeCare(string item)//, int day)
    {
        if (actionsDone < 2)
        {
            switch (item)
            {
                case "snack":
                    if (!givenSnack)                    
                    {

                        if (day < 3)
                        {
                            popUp.TurnOn(name + " enjoyed a piece of cabbage!");
                            love += 10;
                            givenSnack = true;
                            actionsDone++;
                        }
                        else if (day < 5)
                        {
                            popUp.TurnOn(name + " ate some cabbage.");
                            love += 5;
                            givenSnack = true;
                            actionsDone++;
                        }
                        else
                        {
                            love += 0;
                            popUp.TurnOn(name + " doesn't even touch the cabbage.");
                        }                        
                    }
                    else popUp.TurnOn("You can't do the same action twice!");
                    break;

                case "brush":
                    if (!beenBrushed)
                    {
                        if(day < 3)
                        {
                            popUp.TurnOn(name + " has been brushed. Such smooth fur!");
                            love += 5;
                        }
                        else if (day < 5)
                        {
                            popUp.TurnOn("Because of the rash, brushing the fur hurt  " + name + "! :( ");
                            love -= 5;
                        }
                        else popUp.TurnOn(name + " doesn't react.");

                        actionsDone++;
                        beenBrushed = true;                        
                    }
                    else popUp.TurnOn("You can't do the same action twice!");
                    break;

                case "soap":
                    if (!beenBathed)
                    {
                        if (day < 3)
                        {
                            love += 5;
                            popUp.TurnOn(name + " is clean now!");
                        }
                        else if (day < 5)
                        {
                            love -= 5;
                            popUp.TurnOn("The soap seems to have irritated the rash more...");
                        }
                        else popUp.TurnOn(name + " doesn't react.");

                        beenBathed = true;
                        actionsDone++;
                    }
                    else popUp.TurnOn("You can't do the same action twice!");              
                    break;

                case "medicine":
                    if (!givenMeds)
                    {
                        if (day == 1)
                        {
                            popUp.TurnOn(name + " is healthy, no need for medicine!");
                            love -= 5;
                        }
                        else if (day < 5)
                        {
                            popUp.TurnOn("You think " + name + " is feeling better now.");
                            love += 10;
                        }
                        else popUp.TurnOn(name + " doesn't react.");

                        givenMeds = true;
                        actionsDone++;
                    }
                    else popUp.TurnOn("You can't do the same action twice!");
                    break;

                case "pet":
                    if (!beenPet)
                    {
                        if (day == 1)
                        {
                            popUp.TurnOn("You pet " + name + "! How cute!");
                            love += 10;
                        }
                        else if (day == 2)
                        {
                            popUp.TurnOn("You comfort " + name + ". Such a cuddly bunny.");
                            love += 5;
                        }
                        else if (day < 5)
                        {
                            popUp.TurnOn("The bunny is hurt... ");
                            love -= 5;
                        }
                        
                        beenPet = true;
                    }                   
                    else popUp.TurnOn("You can't do the same action twice!");
                    break;
            }

            Debug.Log("Action done: " + action);
            love += 10;
            actionsDone++;
            loveNumber.text = "Love: " + love + "%";
            actionsNumber.text = "Actions left: " + (2 - actionsDone);

        }

    }



    public void NextDay()
    {
        if (day < 6)
        {
            actionsDone = 0;
            givenSnack = false;
            beenBrushed = false;
            beenBathed = false;
            givenMeds = false;
            beenPet = false;

        switch (day)
        {
            case 2:
                trueLove = 70;
                break;
            case 3:
                trueLove = 60;
                break;
            case 4:
                trueLove = 50;
                break;
            case 5:
                trueLove = 20;
                break;
        }
        dayNumber.text = "Day "+ day;
        love = trueLove;
        loveNumber.text = "Love: " + love + "%";
    }
    
    void TakeAction(string item, int day, bool actionDone, int love)
    {
        if (!actionDone && actionsDone < 2)
        {
          
        }
        else if (actionDone)
        {

        }
        else if (actionsDone >= 2)
        {

        }
        
    }
}
