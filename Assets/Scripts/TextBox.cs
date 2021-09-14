using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextBox : MonoBehaviour
{
    //------------------------------------------------------------
    //                  Variables
    //------------------------------------------------------------
    [SerializeField] private TextMeshProUGUI _dialogueText = null;
    [SerializeField] private Canvas _canvas = null;
    private List<string> _tutorialmessages;
    int _messagesRead = 0;
    Bunny bunny;

    //------------------------------------------------------------
    //               Show messages
    //------------------------------------------------------------
    private void Update()
    {

        if (bunny == null) //execute only if bunny has not been found yet!
        {
            bunny = FindObjectOfType<Bunny>();
            _tutorialmessages = new List<string>(11);
            _tutorialmessages.Add("Thank you for agreeing to help take care of " + bunny.gameObject.name + "! (press space for next dialogue)");
            _tutorialmessages.Add("In order to be the best friend of " + bunny.gameObject.name + ", first you need to learn the controls.");
            _tutorialmessages.Add("Use the mousewheel to zoom in and out.");
            _tutorialmessages.Add("Press the right mouse button and move the mouse around to look around.");
            _tutorialmessages.Add("Each day, you can perform 2 actions to fill your bunny's love meter and make it happy!");
            _tutorialmessages.Add("You can brush it, give it a snack, bathe it, pet it, or if it's sick or hurt, give it medicine!");
            _tutorialmessages.Add("To pick up an item, move your hand over it (using your mouse) and press the left button.");
            _tutorialmessages.Add("Bring the item to " + bunny.gameObject.name + " and press the left mouse button to use it on " + bunny.gameObject.name + ".");
            _tutorialmessages.Add("If you change your mind, you can drop the item by pressing the left button again away from the bunny!");
            _tutorialmessages.Add("If you move your hand to the bunny without picking up anything, you can pet it!");
            _tutorialmessages.Add("Ok, that's it for now! Have fun ;)");

            _dialogueText.text = _tutorialmessages[_messagesRead]; //play message based on index
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextMessage();
        }
    }

    private void NextMessage()
    {
        if (_messagesRead < _tutorialmessages.Count) _messagesRead++;
        if (_messagesRead < _tutorialmessages.Count) _dialogueText.text = _tutorialmessages[_messagesRead]; //show the right message
        else _canvas.gameObject.SetActive(false); //if all messages read, turn off the box.
    }

    public void Restart()
    {
        _canvas.gameObject.SetActive(true);
        _messagesRead = 0;
        _dialogueText.text = _tutorialmessages[_messagesRead];

    }
}
