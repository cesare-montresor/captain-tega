using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Scr : MonoBehaviour {
    public GameState_Scr gameState;

    private Slider slider;
    
    void Start() {
        slider = GetComponent<Slider>();
    }
    
    void Update() {
        slider.value = gameState.health;
    }
}
