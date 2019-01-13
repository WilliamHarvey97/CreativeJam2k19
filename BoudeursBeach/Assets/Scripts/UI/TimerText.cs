using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    void Update() {
        int timerValue = this.GetComponent<TimerClock>().getTimer();
        this.GetComponent<Text>().text = timerValue.ToString();
        if (timerValue <= 0){
            this.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else{
            this.gameObject.transform.parent.gameObject.SetActive(true);
        }

    }
}
