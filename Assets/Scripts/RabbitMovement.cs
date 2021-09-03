using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitMovement : MonoBehaviour
{

    private void OnLevelWasLoaded(int level)
    {
        transform.position = new Vector3(0, -1.65f, 0);
        transform.rotation = Quaternion.identity;
    }
}
