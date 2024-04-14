using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro coordinateLabel;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color selectedTileColor = new Color(1f, 0.15f, 0.08f);
    
    void Awake()
    {
        coordinateLabel = GetComponent<TextMeshPro>();
        coordinateLabel.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectsName();
            coordinateLabel.enabled = true;
        
        }
        SetLabelColors();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKey(KeyCode.C))
        {
            coordinateLabel.enabled = !coordinateLabel.IsActive();
        }
    }

    private void SetLabelColors()
    {
        if (waypoint.IsPlaceable)
        {
            coordinateLabel.color = defaultColor;
        }
        else
        {
            coordinateLabel.color = selectedTileColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        coordinateLabel.text = $"{coordinates.x}, {coordinates.y}";
    }

    void UpdateObjectsName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
