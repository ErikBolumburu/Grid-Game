using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    public const float yOffset = 0.2f;
    public List<Unit> units;
    public int maxUnits;
    public Unit selectedUnit;

    public GameObject knightPrefab, magePrefab;
    
    void Awake(){
        Instance = this;
    }

    void Start()
    {
       units = new List<Unit>(); 
    }

    public void CreateUnit(Tile tile, GameObject prefab){
        tile.position.y += yOffset;
        GameObject unitGO = Instantiate(prefab, tile.position, Quaternion.identity);
        Unit unit = unitGO.GetComponent<Unit>();
        unit.go = unitGO;
        units.Add(unit);
        tile.occupiedUnit = unit;
        unit.occupiedTile = tile;
        if(units.Count == UnitManager.Instance.maxUnits) GameManager.Instance.UpdateGameState(GameState.PlayerTurn);
    }
}
