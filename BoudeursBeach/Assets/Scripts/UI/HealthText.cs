using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    // Update is called once per frame
    public GameObject player;
    
    void Update() {
        this.GetComponent<Text>().text = this.player.GetComponent<PlayerController>().health.ToString();
    }
}
