using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } } //property

    void OnMouseOver() { //OnMouseDown()
        if (isPlaceable && Input.GetMouseButtonDown(0)) {
            Vector3 towerPrefabPosition = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, towerPrefabPosition);
            isPlaceable = !isPlaced;
        }
    }
}
