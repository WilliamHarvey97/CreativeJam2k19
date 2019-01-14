using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Wave[] waves;
    public TimerClock timerBeforeWave;
    public GameObject playerSpawnPoint;
    public int timeUntilNextWave = 5;
    bool isLevelStarted = false;
    int currentWaveIndex;
    bool isReadyForNextWave = true;
    bool isLevelCleared = false;

    void Awake() {
        this.currentWaveIndex = 0;
        this.isLevelStarted = false;
    }

    void FixedUpdate() {
        if(this.isLevelStarted) {
            this.playLevel();
        }
    }

    public void startLevel() {
        this.isLevelStarted = true;
        this.timerBeforeWave.startTimer(this.timeUntilNextWave);
    }

    private void playLevel() {
        if(timerBeforeWave.getTimer() <= 0) {
            if (this.currentWaveIndex < this.waves.Length) {
                if(this.isReadyForNextWave) {
                    this.isReadyForNextWave = false;
                    this.startNextWave();
                }
                this.checkForNextWave();
            } else {
                if(GameObject.FindGameObjectsWithTag("Enemy").Length -1 == 0) {
                    this.isLevelCleared = true;
                    this.isLevelStarted = false;
                } 
            }
        }
    }

    public bool getIsLevelCleared() {
        return this.isLevelCleared;
    }

    public void setIsLevelStarted(bool isLevelStarted) {
        this.isLevelStarted = isLevelStarted;
    }

    public int getCurrentWaveIndex() {
        return this.currentWaveIndex;
    }

    private void checkForNextWave() {
        if (this.waves[this.currentWaveIndex].getIsEnded()) {
            this.currentWaveIndex++;
            this.isReadyForNextWave = true;
            if(this.currentWaveIndex < this.waves.Length){
                this.timerBeforeWave.startTimer(this.timeUntilNextWave);
            }
        }
    }

    private void startNextWave() {
        Debug.Log("Next wave is starting!");
        this.waves[this.currentWaveIndex].setIsReadyToSpawn(true); // Next wave can start!
    }
}
