using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blackout : MonoBehaviour
{
    //--------------------------------------------------
    //               Fade IN / OUT
    //----------------------------------------------
    public GameObject blackOutScreen;
    public bool isFaded = false;
    public TextMeshProUGUI transitionText;

    Color objectColour;
    public void Awake() //fade from black when entering scene for the first time
    {
        StartCoroutine(FadeToBlack(false));
        transitionText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        /*
        if(objectColour.a == 1)
        {           
             
        } 
        
        if(objectColour.a == 0)
        {
            
        }*/
    }
    public IEnumerator FadeToBlack(bool fade = true, float fadeSpeed = 5)
    {
        objectColour = blackOutScreen.GetComponent<Image>().color; //whats the object's colour right now?
        float fadeAmount;

        //fade into black
        if (fade)
        {
            while (objectColour.a < 1) //work only when alpha is below 1
            {
                fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime); //increasing alpha over time

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount); //apply new alpha
                blackOutScreen.GetComponent<Image>().color = objectColour; //save new object colour
                yield return null;
            }
            isFaded = true;
        }
        // fade from black
        else
        {
            while(objectColour.a > 0) //work only if alpha is above 0
            {
                fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime); //decreasing alpha over time

                objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount); //apply new alpha
                blackOutScreen.GetComponent<Image>().color = objectColour; //save new object colour
                yield return null;
            }
            isFaded = false;
        }
        yield return new WaitForEndOfFrame();

        if (isFaded) transitionText.gameObject.SetActive(true);
    }
}