using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event UnityAction<GameState> OnGameStateChanged;

    void Awake(){
        Instance = this;
    }

    void Start(){
        UpdateGameState(GameState.PlaceUnits);
    }

    public void UpdateGameState(GameState newState){
        State = newState;
        switch (State)
        {
            case GameState.PlaceUnits:
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Decide:
                break;
            case GameState.Victory:
                break;
            case GameState.Defeat:
                break;
        }

        OnGameStateChanged?.Invoke(newState);

    }

    void HandlePlayerTurn(){

    }

}

public enum GameState {
    PlaceUnits,
    PlayerTurn,
    EnemyTurn,
    Decide,
    Victory,
    Defeat
}
