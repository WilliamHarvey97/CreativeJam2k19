using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Wave[] waves;
    public TimerClock timerBeforeWave;
    public int timeUntilNextWave = 5;
    int currentWaveIndex;
    bool isReadyForNextWave = true;
    bool isLevelCleared = false;

    void Awake() {
        this.currentWaveIndex = 0;
        this.timerBeforeWave.startTimer(this.timeUntilNextWave);
    }

    void FixedUpdate() {
        if(timerBeforeWave.getTimer() <= 0) {
            if (this.currentWaveIndex < this.waves.Length) {
                if(this.isReadyForNextWave) {
                    this.isReadyForNextWave = false;
                    this.startNextWave();
                }
                this.checkForNextWave();
            } else {
                this.isLevelCleared = true;
            }
        }
    }

    public bool getIsLevelCleared() {
        return this.isLevelCleared;
    }

    private void checkForNextWave() {
        if (this.waves[this.currentWaveIndex].isEnded) {
            this.currentWaveIndex++;
            this.isReadyForNextWave = true;
            if(this.currentWaveIndex < this.waves.Length){
                this.timerBeforeWave.startTimer(this.timeUntilNextWave);
            }
        }
    }

    private void startNextWave() {
        this.waves[this.currentWaveIndex].setIsReadyToSpawn(true); // Next wave can start!
    }
}
