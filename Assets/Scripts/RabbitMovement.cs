using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitMovement : MonoBehaviour
{

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            transform.position = new Vector3(0, -1.44f, 0);
            transform.rotation = Quaternion.identity;
        }        
    }
}
