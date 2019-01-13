using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesText : MonoBehaviour
{
    public GameObject game;
    
    void Update() {
        this.GetComponent<Text>().text = this.game.GetComponent<Game>().getCurrentWaveIndex().ToString();
    }
}
