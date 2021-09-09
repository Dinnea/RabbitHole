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

    public string bunnyName;

    private void Start()
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
    private void Update()
    {
        

        // Bunny care

        
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            
        }
    }

    //Bunny care

    public void TakeCare(string action)//, int day)
    {
        if (actionsDone < 2)
        {
            switch (action)
            {
                case "Food":
                    givenSnack = true;
                    break;
                case "Brush":
                    beenBrushed = true;
                    break;
                case "Soap":
                    beenBathed = true;
                    break;
                case "Medicine":
                    givenMeds = true;
                    break;
                case "Pet":
                    beenPet = true;
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
        day++;
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
    // creation screen options   
    

    
   
}
