using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RabbitStats : MonoBehaviour
{
    public InputField inputName;
    public string Name;

    int health;
    int hunger;
    int cleanliness;
    int happiness;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SetName();
            if (Name != null) Debug.Log(Name);
        }
        
    }
    public void SetName()
    {
        if(string.IsNullOrEmpty(inputName.text) == false)
        {
            Name = inputName.text;
        }
    }

   
}
