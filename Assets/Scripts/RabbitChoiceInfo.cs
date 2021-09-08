using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class RabbitChoiceInfo : MonoBehaviour
{
    int test = 1;
    [SerializeField] GameObject bunny;
    public InputField inputName;
    public string bunnyName;

    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Character creation
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SetName();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            if (test == 1)
            {
                
                Instantiate(bunny, new Vector3 (0, 0, 0 ), Quaternion.Euler(0, 0, 0)) ;

            }

            Destroy(gameObject);
        }
    }

    public bool IsRabbitNamed()
    {
        if (string.IsNullOrEmpty(inputName.text) == false)
        {
            return true;
        }
        else return false;
    }

    public void SetName()
    {
        if (IsRabbitNamed())
        {
            bunnyName = inputName.text;
        }
    }
}
