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

    private void Awake()
    {
        transform.position = new Vector3(-0.85f, -1.26f, 5.68f);
        transform.rotation = Quaternion.identity;
    }
}
