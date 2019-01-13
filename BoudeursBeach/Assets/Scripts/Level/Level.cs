using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Wave[] waves;
    public TimerClock timerBeforeWave;
    public int timeSpanBeforeWave = 5;
    int currentWaveIndex;
    bool isReadyForNextWave = true;
    bool isLevelCleared = false;

    void Awake() {
        this.currentWaveIndex = 0;
        this.timerBeforeWave.timerInitialTime = this.timeSpanBeforeWave;
        this.timerBeforeWave.startTimer();
    }

    void FixedUpdate() {
        if(timerBeforeWave.getTimer() <= 0) {
            if (this.currentWaveIndex < this.waves.Length && this.isReadyForNextWave) {
                this.isReadyForNextWave = false;
                this.startNextWave();
            }
            this.checkForNextWave();
        }
    }

    private void checkForNextWave() {
        if (this.waves[this.currentWaveIndex].isEnded) {
            this.currentWaveIndex++;
            this.isReadyForNextWave = true;
            this.timerBeforeWave.startTimer();
        }
    }

    private void startNextWave() {
        this.waves[this.currentWaveIndex].setIsReadyToSpawn(true); // Next wave can start!
    }
}
