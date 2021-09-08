using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    RabbitChoiceInfo rabbit;
    public void PlayNextRoom()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        

        if (scene == 1)
        {
            rabbit = FindObjectOfType<RabbitChoiceInfo>();
            if (string.IsNullOrEmpty(rabbit.bunnyName) == false)
            {
                SceneManager.LoadScene(scene + 1);
            }
            else Debug.Log("Please bunnyName your bunny!");
        }
        else SceneManager.LoadScene(scene + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
