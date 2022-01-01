using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text unitCountText;

    void Awake(){
        Instance = this;
    }

    void Update(){
        unitCountText.text = "Units: " + UnitManager.Instance.units.Count + "/" + UnitManager.Instance.maxUnits;
    } 

}
