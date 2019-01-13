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
        Debug.Log("Timer Value: "  + timerValue);
        if (timerValue <= 0) {  // Only Render/disable rendering of all the game objects of the canvas.
            this.gameObject.transform.parent.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0f);
            this.gameObject.transform.parent.gameObject.transform.Find("TimerInfoText").GetComponent<CanvasRenderer>().SetAlpha(0f);
            this.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
        else{
            this.gameObject.transform.parent.gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
            this.gameObject.transform.parent.gameObject.transform.Find("TimerInfoText").GetComponent<CanvasRenderer>().SetAlpha(1f);
            this.gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }
    }
}
