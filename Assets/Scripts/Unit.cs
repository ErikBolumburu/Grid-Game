using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Vector2 position;
    public GameObject go;
    public Tile occupiedTile;

    void Update(){
        if(UnitManager.Instance.selectedUnit == this) transform.Find("Highlight").gameObject.SetActive(true);
        else transform.Find("Highlight").gameObject.SetActive(false);
    }

    public void MoveToPosition(Tile currentTile, Tile newTile){
        if(newTile.occupiedUnit == null){
            newTile.occupiedUnit = this;
            occupiedTile = newTile;
            position = newTile.position;
            go.transform.position = new Vector2(newTile.position.x, newTile.position.y + UnitManager.yOffset);
            UnitManager.Instance.selectedUnit = null;
            currentTile.occupiedUnit = null;

        }
    } 
}