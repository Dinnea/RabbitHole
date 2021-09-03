using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RabbitStats : MonoBehaviour
{
    public InputField inputName;
    public string bunnyName;

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
        if(IsRabbitNamed())
        {
            bunnyName = inputName.text;
        }
    }

    
   
}
