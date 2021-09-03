using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    RabbitStats rabbit;
    public void PlayNextRoom()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        

        if (scene == 1)
        {
            rabbit = FindObjectOfType<RabbitStats>();
            if (string.IsNullOrEmpty(rabbit.Name) == false)
            {
                SceneManager.LoadScene(scene + 1);
            }
            else Debug.Log("Please name your bunny!");
        }
        else SceneManager.LoadScene(scene + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
