using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpTextLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI self;
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn(string text)
    {
        if (gameObject.activeInHierarchy == true)
        {
            TurnOff();
        }        
        self.text = text;
        gameObject.SetActive(true);
        Invoke("TurnOff", 3);
    }
}
