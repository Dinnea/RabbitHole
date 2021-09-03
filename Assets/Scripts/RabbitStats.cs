using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void SetName()
    {
        if(string.IsNullOrEmpty(inputName.text) == false)
        {
            Name = inputName.text;
        }
    }

    private void Update()
    {
        SetName();
        if (Name != null)Debug.Log(Name);
    }
}
