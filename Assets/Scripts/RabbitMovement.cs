using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitMovement : MonoBehaviour
{
    //How the rabbit moves
    //I intended that the rabbit would move in game a bit,
    //But this is most likely not going to happen.
    //This only places the rabbit in correct area and makes sure rabbit is not rotated

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            transform.position = new Vector3(0, -1.44f, 0);
            transform.rotation = Quaternion.identity;
        }        
    }
}
