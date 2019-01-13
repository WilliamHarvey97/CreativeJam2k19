using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public GameObject game;
    void Update() {
        int timerValue = this.game.GetComponent<Game>().getTimeUntilNextWave();
        this.GetComponent<Text>().text = timerValue.ToString();
        if (timerValue <= 0){
            this.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else{
            this.gameObject.transform.parent.gameObject.SetActive(true);
        }

    }
}
