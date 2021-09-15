using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class RabbitChoiceInfo : MonoBehaviour
{
    /*[SerializeField] GameObject _bunny;
    private MeshRenderer _rendererBunny;
    private List<Material> _materials;*/
    [SerializeField] GameObject _bunnyWhite;
    [SerializeField] GameObject _bunnyBrown;
    [SerializeField] GameObject _bunnyGray;
    [SerializeField] GameObject _bunnyBlack;

    public InputField inputName;
    public string bunnyName;
    public string furColour;    

    void Start()
    {
        /*//possible rabbit coats
        _materials = new List<Material>(4);
        _materials.Add((Material)Resources.Load("White"));
        _materials.Add((Material)Resources.Load("Brown"));
        _materials.Add((Material)Resources.Load("Grey"));
        _materials.Add((Material)Resources.Load("Black"));


        _rendererBunny = _bunny.GetComponentInChildren<MeshRenderer>(); //object to change rabbit coat*/
        DontDestroyOnLoad(gameObject); //keep this on load
    }

    void Update()
    {
        // Stuff only done in character creation
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SetName();
        }
    }
    //------------------------------------------------
    //                Customisation
    //------------------------------------------------
    private void OnLevelWasLoaded(int level)
    {
        //if level = 2 spawn new rabbit (with specific fur colour)
        if (level == 2)
        {
            switch (furColour)
            {
                case "white":
                    Instantiate(_bunnyWhite, new Vector3(-0.85f, -1.26f, 5.68f), Quaternion.identity);
                    //_rendererBunny.material = _materials[0];
                    break;
                case "brown":
                    Instantiate(_bunnyBrown, new Vector3(-0.85f, -1.26f, 5.68f), Quaternion.identity);
                    //_rendererBunny.material = _materials[1];
                    break;
                case "grey":
                    Instantiate(_bunnyBlack, new Vector3(-0.85f, -1.26f, 5.68f), Quaternion.identity);
                    //_rendererBunny.material = _materials[2];
                    break;
                case "black":
                    Instantiate(_bunnyGray, new Vector3(-0.85f, -1.26f, 5.68f), Quaternion.identity);
                    //_rendererBunny.material = _materials[3];
                    break;
            }         
                
             //Instantiate(_bunny, new Vector3 (0, -1.44f, 0 ), Quaternion.identity );
        }
    }

    //------------------------------------------------
    //                Naming
    //------------------------------------------------
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
