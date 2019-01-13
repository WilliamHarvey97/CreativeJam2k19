using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerClock : MonoBehaviour
{
    bool isTimerStarted = false;
    public int timerInitialTime = 30;
    private int timer = 0;

    void FixedUpdate() {
        if(!this.isTimerStarted && this.timer > 0) {
            StartCoroutine(this.decrementTimer());
            this.isTimerStarted = true;
        }
    }

    public void startTimer() {
        this.timer = this.timerInitialTime;
        this.isTimerStarted = false;
    }

    IEnumerator decrementTimer() {
        yield return new WaitForSeconds(1);
        this.timer--;
        this.isTimerStarted = false;
        Debug.Log(this.timer);
    }

    public int getTimer() {
        return this.timer;
    }
}
