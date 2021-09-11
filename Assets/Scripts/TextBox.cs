using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText = null;
    [SerializeField] private Canvas canvas = null;
    List<string> day1Script;
    int messagesRead = 0;
    Bunny bunny;
    private void Update()
    {

        if (bunny == null)
        {

            bunny = FindObjectOfType<Bunny>();
            day1Script = new List<string>();
            day1Script.Add("Thank you for agreeing to help take care of " + bunny.gameObject.name + "! (press space for next dialogue)");
            day1Script.Add("In order to be the best friend of " + bunny.gameObject.name + ", first you need to learn the controls.");
            day1Script.Add("Use the mousewheel to zoom in and out.");
            day1Script.Add("Press the right mouse button and move the mouse around to look around.");
            day1Script.Add("Each day, you can perform 2 actions to fill your bunny's love meter and make it happy!");
            day1Script.Add("You can brush it, give it a snack, bathe it, pet it, or if it's sick or hurt, give it medicine!");
            day1Script.Add("To pick up an item, move your hand over it (using your mouse) and press the left button.");
            day1Script.Add("Bring the item to " + bunny.gameObject.name + " and press the left mouse button to use it on " + bunny.gameObject.name + ".");
            day1Script.Add("If you change your mind, you can drop the item by pressing the left button again away from the bunny!");
            day1Script.Add("If you move your hand to the bunny without picking up anything, you can pet it!");
            day1Script.Add("Ok, that's it for now! Have fun ;)");

            dialogueText.text = day1Script[messagesRead];
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (messagesRead < day1Script.Count) messagesRead++;
            if (messagesRead < day1Script.Count) dialogueText.text = day1Script[messagesRead];
            else canvas.gameObject.SetActive(false);
        }
    }
}
