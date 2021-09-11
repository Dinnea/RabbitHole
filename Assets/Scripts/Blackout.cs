using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    public GameObject blackOutScreen;
    public bool isFaded = false;

    Color objectColour;
    public void Awake()
    {
        StartCoroutine(FadeToBlack(true));
    }

    private void Update()
    {
        if(objectColour.a == 1)
        {           
            isFaded = true;
        }
    }
    public IEnumerator FadeToBlack(bool faded = false, float fadeSpeed = 5)
    {
        objectColour = blackOutScreen.GetComponent<Image>().color;
        float fadeAmount;

        if (!faded)
        {
            while (objectColour.a < 1)
            {
                fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime);

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                blackOutScreen.GetComponent<Image>().color = objectColour;
                yield return null;
            }
        }
        // fade from black
        else
        {
            while(objectColour.a > 0)
            {
                fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime);

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
                blackOutScreen.GetComponent<Image>().color = objectColour;
                yield return null;
            }
        }
        yield return new WaitForEndOfFrame();
    }
}