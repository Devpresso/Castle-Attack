using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject ballista;
    [SerializeField] bool isPlaceable;
    void OnMouseDown()
    {
        Debug.Log("yay");
        if (isPlaceable)
        {
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = false;
            Debug.Log("hooray");
        }
    }
}
