using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText = null;
    [SerializeField] private Canvas canvas = null;
    List<string> day1Script;
    List<string> todayScript;
    int messagesRead = 0;

    private void Start()
    {
        day1Script = new List<string>();
        day1Script.Add("peepee poopoo");
        day1Script.Add("poopoo peepee");
        dialogueText.text = day1Script[messagesRead];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (messagesRead < day1Script.Count) messagesRead++;
            if (messagesRead < day1Script.Count) dialogueText.text = day1Script[messagesRead];
            else canvas.gameObject.SetActive(false);
        }
    }
}
