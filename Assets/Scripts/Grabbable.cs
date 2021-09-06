using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] Vector3 originalLocation;

    public void ResetPosition()
    {
        transform.position = originalLocation;
    }

    
}
