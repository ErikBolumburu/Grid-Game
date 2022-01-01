using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Vector2 position;
    public Color mainColor, offsetColor;
    public GameObject go;
    [SerializeField] private GameObject highlight;
    public Unit occupiedUnit;
    public TileType type;

    public void Initialize(Vector2 _position){
        highlight = transform.Find("Highlight").gameObject;
        position = _position;
        if((position.x + position.y) % 2 == 1){
            go.GetComponent<SpriteRenderer>().color = mainColor;
        }
        else{
            go.GetComponent<SpriteRenderer>().color = offsetColor;
        }
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    void OnMouseClick(){
        GridManager.Instance.TileClicked(this);
    }

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)) OnMouseClick();
    }

}