using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]

public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color clearColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coords = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoords();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoords();
            UpdateObjectName();
        }

        ColorCoords();
    }
    
    void ColorCoords()
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
        coords.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coords.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coords.x + "," + coords.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coords.ToString();
    }
}
