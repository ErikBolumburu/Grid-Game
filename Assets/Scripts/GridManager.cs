using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public int gridWidth;
    public int gridHeight;

    [SerializeField] private GameObject grassTile, waterTile;

    private Dictionary<Vector2, Tile> tiles;
    
    void Awake(){
        Instance = this;
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy(){
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state){
    }

    void Start(){
        Camera.main.transform.position = new Vector3(gridWidth / 2 - 0.5f, gridHeight / 2 - 0.5f, -10);
        tiles = new Dictionary<Vector2, Tile>();
        GenerateWorld();
    }

    void GenerateWorld(){
        for (int x = 0; x < gridWidth; x++)
        {
           for (int y = 0; y < gridHeight; y++)
           {
               InstantiateTile(x, y);
           } 
        }
    }

    public void TileClicked(Tile tile){
        switch(GameManager.Instance.State){
            case GameState.PlaceUnits:
                if(tile.occupiedUnit == null){ 
                    if(tile.type == TileType.Grass) UnitManager.Instance.CreateUnit(tile, UnitManager.Instance.knightPrefab);
                    else Debug.Log("Can Only Place On Grass");
                }
                else{
                    Debug.Log("Tile Occupied");
                }
            break;

            case GameState.PlayerTurn:
                if(tile.occupiedUnit != null){
                    UnitManager.Instance.selectedUnit = tile.occupiedUnit;
                }
                else{
                    if(UnitManager.Instance.selectedUnit != null){
                        UnitManager.Instance.selectedUnit.MoveToPosition(UnitManager.Instance.selectedUnit.occupiedTile, tile);
                    }
                }
            break;
                
        }
    }

    void InstantiateTile(int x, int y){
        TileType tempTileType;
        GameObject randomTile;

        if(Random.Range(0, 6) == 3){
            randomTile =  waterTile.transform.gameObject;
            tempTileType = TileType.Water;
        }
        else{
            randomTile = grassTile.transform.gameObject;
            tempTileType = TileType.Grass;
        }

        GameObject spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
        Tile tile = spawnedTile.GetComponent<Tile>();
        tile.go = spawnedTile;
        tile.name = $"Tile {x} {y}";
        tile.go.transform.SetParent(transform);
        tile.type = tempTileType;
        
        tile.Initialize(new Vector2(x,y));

        tiles[new Vector2(x, y)] = tile;
    }

    public Tile ReturnTileAtPos(Vector2 pos){
        return tiles[pos];
    }
}

public enum TileType{
    Grass,
    Water
}