using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]

public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color clearColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;

    TextMeshPro label;
    Vector2Int coords = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoords();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (!Application.isPlaying)
        {
            DisplayCoords();
            UpdateObjectName();
            label.enabled = true;
        }

        ColorLabel();
        ToggleLabel();
    }
    
    void ColorLabel()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = clearColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }
    void DisplayCoords()
    {
        coords.x = Mathf.RoundToInt(transform.parent.position.x / 5);
        coords.y = Mathf.RoundToInt(transform.parent.position.z / 5);

        label.text = coords.x + "," + coords.y;
    }

    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            label.enabled = !label.enabled;
        }
    }

    void UpdateObjectName()
    {
        transform.parent.name = coords.ToString();
    }
}
