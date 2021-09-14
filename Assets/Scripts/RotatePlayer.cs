using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public IEnumerator Rotate(Vector3 angles, float time = 2)
    {
        Quaternion initial = transform.rotation;
        Quaternion final = Quaternion.Euler(transform.eulerAngles + angles);

        for (float t = 0; t < 1; t+= Time.deltaTime / time)
        {
            transform.rotation = Quaternion.Slerp(initial, final, t);
            yield return null;
        }       
    }
}
