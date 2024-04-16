using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = Color.green;
    [SerializeField] Color blockedColor = new Color(1f, 0.15f, 0.08f);

    TextMeshPro coordinateLabel;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;
    
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        coordinateLabel = GetComponent<TextMeshPro>();
        coordinateLabel.enabled = false;
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
        if (gridManager == null) { return; }
        if (gridManager.GetNode(coordinates) == null) return;

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }
        else if (!node.isWalkable)
        {
            coordinateLabel.color = blockedColor;
        }
        else if (node.isPath)
        {
            coordinateLabel.color = pathColor;
        }
        else if (node.isExplored)
        {
            coordinateLabel.color = exploredColor;
        }
        else
        {
            coordinateLabel.color = defaultColor;
        }
    }

    private void DisplayCoordinates()
    {
        if (gridManager == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        coordinateLabel.text = $"{coordinates.x}, {coordinates.y}";
    }

    void UpdateObjectsName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
