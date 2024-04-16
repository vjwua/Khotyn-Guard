using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } } //property

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    Pathfinder pathfinder;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.getCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown() {
        if (gridManager.GetNode(coordinates) == null) { return; }
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates)) {
            Vector3 towerPrefabPosition = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, towerPrefabPosition);
            if (isSuccessful)
            {
                gridManager.BlockNode(coordinates); 
                pathfinder.NotifyReceivers();  
            }
        }
    }
}
