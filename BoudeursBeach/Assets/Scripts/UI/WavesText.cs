using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesText : MonoBehaviour
{
    public GameObject game;
    
    void Update() {
        int currentWaveIndex = this.game.GetComponent<Game>().getCurrentWaveIndex();
        this.GetComponent<Text>().text = (currentWaveIndex + 1).ToString();
    }
}
