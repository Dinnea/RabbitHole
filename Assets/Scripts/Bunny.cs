using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Bunny : MonoBehaviour
{
    //----------------------------------------------------
    //                   Variables
    //----------------------------------------------------
    private GameObject _info;
    private RabbitChoiceInfo _rabbitInfo;

    //UI interaction objects
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _dayNumber;
    private TextMeshProUGUI _loveNumber;
    private TextMeshProUGUI _actionsNumber;
    private GameObject _ui;
    private Blackout _blackOut;
    private PopUpTextLevel _popUp;

    public float love = 80; //player sees this change
    private float _trueLove = 80; //true love is true value applied in background
    public int day = 1; //what day is it?

    //Variables for checking if daily actions have been completed
    public int actionsDone = 0;
    private bool _givenSnack = false;
    private bool _beenBrushed = false;
    private bool _beenBathed = false;
    private bool _givenMeds = false;
    private bool _beenPet = false;

    //---------------------------- Sound ----------------------------//
    //Sound on action - talk
    private GameObject _audioActionObject;
    private List<AudioSource> _actionAudio;
    // - action
    private GameObject _soundObject;
    private AudioSource _sound;

    //Sound on day transition
    private GameObject _audioTransitionObject;
    private List<AudioSource> _transitionAudio;


    //------------------------------------------------------------
    //                     Gathering UI elements etc
    //--------------------------------------------------------
    private void Awake()
    {
        _info = GameObject.Find("PlayerRabbitInfo");
        _rabbitInfo = _info.GetComponent<RabbitChoiceInfo>();

        _nameText = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
        _nameText.text = _rabbitInfo.bunnyName;

        _dayNumber = GameObject.Find("Day").GetComponent<TextMeshProUGUI>();
        _dayNumber.text += day;

        _loveNumber = GameObject.Find("Love").GetComponent<TextMeshProUGUI>();
        _loveNumber.text += love + "%";

        _actionsNumber = GameObject.Find("actions").GetComponent<TextMeshProUGUI>();
        _actionsNumber.text += 2 - actionsDone;
    }
    private void Start()
    {
        name = _rabbitInfo.bunnyName;  //rename object according to its name
        _ui = GameObject.Find("UI");

        _popUp = _ui.GetComponentInChildren<PopUpTextLevel>();
        _popUp.TurnOff();

        _blackOut = _ui.GetComponentInChildren<Blackout>();

        _audioActionObject = GameObject.Find("Actions Done Sound");
        _actionAudio = new List<AudioSource>(5);
        _actionAudio = _audioActionObject.GetComponents<AudioSource>().ToList();

        _audioTransitionObject = GameObject.Find("Day Transition Sound");
        _transitionAudio = new List<AudioSource>(4);
        _transitionAudio = _audioTransitionObject.GetComponents<AudioSource>().ToList();

        _soundObject = GameObject.Find("Sound");
        _sound = _soundObject.GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        if(day > 1)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //fade from black
            {
                _blackOut.transitionText.gameObject.SetActive(false);
                _transitionAudio[day - 2].Play(0);
                StartCoroutine(_blackOut.FadeToBlack(false, 0.1f));
                _popUp.TurnOn("Day " + day);
            }
        }        
    }

    //------------------------------------------------------------------
    //                        Bunny care
    //------------------------------------------------------------------

    public void TakeCare(string item) //item = what is being used
    {
        if (actionsDone < 2) // can you still do an action?
        {
            switch (item)
            {
                case "snack":
                    if (!_givenSnack)
                    {

                        if (day < 3) //values change based on day
                        {
                            _popUp.TurnOn(name + " enjoyed a piece of cabbage!");
                            love += 10;
                            _givenSnack = true;
                            actionsDone++;
                        }
                        else if (day < 5)
                        {
                            _popUp.TurnOn(name + " ate some cabbage.");
                            love += 5;
                            _givenSnack = true;
                            actionsDone++;
                        }
                        else
                        {
                            love += 0;
                            _popUp.TurnOn(name + " doesn't even touch the cabbage."); //action isnt done - the rabbit didnt eat.
                        }
                        _actionAudio[0].Play(0);
                    }
                    else _popUp.TurnOn("You can't do the same action twice!");
                    break;

                case "brush":
                    if (!_beenBrushed)
                    {
                        if (day < 3)
                        {
                            _popUp.TurnOn(name + " has been brushed. Such smooth fur!");
                            love += 5;
                        }
                        else if (day < 5)
                        {
                            _popUp.TurnOn("Because of the rash, brushing the fur hurt  " + name + "! :( ");
                            love -= 5;
                        }
                        else _popUp.TurnOn(name + " doesn't react.");
                        _sound.Play(0);
                        _actionAudio[1].Play(0);
                        actionsDone++; //action is done in all cases
                        _beenBrushed = true;
                    }
                    else _popUp.TurnOn("You can't do the same action twice!");
                    break;

                case "soap":
                    if (!_beenBathed)
                    {
                        if (day < 3)
                        {
                            love += 5;
                            _popUp.TurnOn(name + " is clean now!");
                        }
                        else if (day < 5)
                        {
                            love -= 5;
                            _popUp.TurnOn("The soap seems to have irritated the rash more...");
                        }
                        else _popUp.TurnOn(name + " doesn't react.");

                        _actionAudio[2].Play(0);
                        _beenBathed = true;//action is done in all cases
                        actionsDone++;
                    }
                    else _popUp.TurnOn("You can't do the same action twice!");
                    break;

                case "medicine":
                    if (!_givenMeds)
                    {
                        if (day == 1)
                        {
                            _popUp.TurnOn(name + " is healthy, no need for medicine!");
                            love -= 5;
                        }
                        else if (day < 5)
                        {
                            _popUp.TurnOn("You think " + name + " is feeling better now.");
                            love += 10;
                        }
                        else _popUp.TurnOn(name + " doesn't react.");

                        _actionAudio[3].Play(0);
                        _givenMeds = true;//action is done in all cases
                        actionsDone++;
                    }
                    else _popUp.TurnOn("You can't do the same action twice!");
                    break;

                case "pet":
                    if (!_beenPet)
                    {
                        if (day == 1)
                        {
                            _popUp.TurnOn("You pet " + name + "! How cute!");
                            love += 10;
                        }
                        else if (day == 2)
                        {
                            _popUp.TurnOn("You comfort " + name + ". Such a cuddly bunny.");
                            love += 5;
                        }
                        else if (day < 5)
                        {
                            _popUp.TurnOn("The bunny is hurt... ");
                            love -= 5;
                        }
                        _actionAudio[4].Play(0);
                        actionsDone++;//action is done in all cases
                        _beenPet = true;
                    }
                    else _popUp.TurnOn("You can't do the same action twice!");
                    break;
            }
            _loveNumber.text = "Love: " + love + "%"; //Disolay current love value
            _actionsNumber.text = "Actions left: " + (2 - actionsDone); //How many actions can you still do?

        }
        else _popUp.TurnOn("No more actions left to do today! Click the pet carrier now."); //Day end message.
    }

    //------------------------------------------------------------------
    //                        Day transition
    //------------------------------------------------------------------

    public void NextDay() //Next day transition
    {
        if (day < 6) //day 6 is final
        {
            day++;
            actionsDone = 0;
            _givenSnack = false;
            _beenBrushed = false;
            _beenBathed = false;
            _givenMeds = false;
            _beenPet = false;

            switch (day) //set the real love value daily
            {            // player has 0 real impact on bunny's condition.
                case 2:
                    _trueLove = 70;
                    break;
                case 3:
                    _trueLove = 60;
                    break;
                case 4:
                    _trueLove = 50;
                    break;
                case 5:
                    _trueLove = 20;
                    break;
                //day 6 is very different
            }
            StartCoroutine(_blackOut.FadeToBlack(true)); //fadeout
            //change variables
            _dayNumber.text = "Day " + day;
            love = _trueLove;
            _loveNumber.text = "Love: " + love + "%";
            _actionsNumber.text = "Actions left: " + (2 - actionsDone);
        }
    }
}
