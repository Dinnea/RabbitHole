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
    MeshRenderer renderer;
    List<Material> materials;

    public InputField inputName;
    public string bunnyName;
    public string furColour;

    

    void Start()
    {
        materials = new List<Material>(4);
        materials.Add((Material)Resources.Load("White"));
        materials.Add((Material)Resources.Load("Brown"));
        materials.Add((Material)Resources.Load("Grey"));
        materials.Add((Material)Resources.Load("Black"));


        renderer = bunny.GetComponentInChildren<MeshRenderer>();   //GetComponentInCh<MeshRenderer>();
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
            switch (furColour)
            {
                case "white":
                    renderer.material = materials[0];
                    break;
                case "brown":
                    renderer.material = materials[1];
                    break;
                case "grey":
                    renderer.material = materials[2];
                    break;
                case "black":
                    renderer.material = materials[3];
                    break;
            }         
                
             Instantiate(bunny, new Vector3 (0, -1.44f, 0 ), Quaternion.identity );
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
