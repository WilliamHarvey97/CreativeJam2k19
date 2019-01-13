using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGoneText : MonoBehaviour
{
    // Update is called once per frame
    public GameObject game;
    
    void Update() {
        this.GetComponent<Text>().text = this.game.GetComponent<Game>().EnemiesGone.ToString();
    }
}
