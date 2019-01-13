﻿ using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;

public class Game : MonoBehaviour
{
    public Level[] levels;
    public int EnemiesGone = 0;
    public int MaxEnemiesThatCanLeave = 5;
    private int currentWaveIndex = 0;
    private int currentLevelIndex;

    public int getCurrentWaveIndex() {
        return this.currentWaveIndex;
    }

    public int getTimeUntilNextWave() {
        return this.levels[this.currentLevelIndex].timerBeforeWave.getTimer();
    }
}
