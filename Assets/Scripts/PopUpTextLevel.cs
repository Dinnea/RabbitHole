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
        TurnOff();
        gameObject.SetActive(true);
        self.text = text;
        Invoke("TurnOff", 2);
    }
}
