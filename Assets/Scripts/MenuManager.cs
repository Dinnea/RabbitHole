using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour

    //------------------------------------------------
    //              Menu Options
    //-------------------------------------------------
{
    private RabbitChoiceInfo _rabbit;

    // Next screen
    public void PlayNextRoom()
    {
        int scene = SceneManager.GetActiveScene().buildIndex; //what is the current screen
        

        if (scene == 1) 
        {
            _rabbit = FindObjectOfType<RabbitChoiceInfo>();
            if (_rabbit.IsRabbitNamed()) //is rabbit named?
            {
                SceneManager.LoadScene(scene + 1); //you can move on
            }
            else Debug.Log("Please name your bunny!"); // add popup
        }
        else SceneManager.LoadScene(scene + 1); //if not scene with rabbit to be named, just move on
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
 
    public void QuitGame()
    {
        Application.Quit();
    }
}
