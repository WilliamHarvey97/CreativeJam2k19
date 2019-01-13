using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerClock : MonoBehaviour
{
    bool isTimerStarted = false;
    public int timerInitialTime = 60;
    private int timer = 0;

    void Start() {
        this.timer = this.timerInitialTime;
    }

    void FixedUpdate() {
        if(!this.isTimerStarted && this.timer > 0) {
            StartCoroutine(this.decrementTimer());
            this.isTimerStarted = true;
        }
    }

    public void startTimer() {
        this.timer = this.timerInitialTime;
    }

    IEnumerator decrementTimer() {
        yield return new WaitForSeconds(1);
        this.isTimerStarted = false;
        this.timer--;
    }

    public int getTimer() {
        return this.timer;
    }
}
