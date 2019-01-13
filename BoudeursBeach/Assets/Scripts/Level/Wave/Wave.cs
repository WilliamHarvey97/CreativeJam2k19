using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] enemyGroups;
    public float[] timeSpanBetweenGroupSpawn;
    public Transform[] enemyGroupSpawningPoints;
    public int currentSpawningEnemyGroupIndex;
    public int timeBeforeNextWave; // Time to let some rest to the player before beginning of the countdown for the next wave
    public bool isEnded = false;
    bool isReadyToSpawn = false;

    void Start() {
        this.currentSpawningEnemyGroupIndex = 0;
    }

    void FixedUpdate() {
        if(this.currentSpawningEnemyGroupIndex < this.enemyGroups.Length && this.isReadyToSpawn) {
            this.isReadyToSpawn = false;
            StartCoroutine(this.spawnGroup());
        } else if(!this.isEnded) {
            this.waitForNextWave();
        }
    }

    public void setIsReadyToSpawn(bool val) {
        this.isReadyToSpawn = val;
    }

    private IEnumerator waitForNextWave() {
        yield return new WaitForSeconds(this.timeBeforeNextWave);
        this.isEnded = true;
    }

    private IEnumerator spawnGroup() {
        yield return new WaitForSeconds(this.timeSpanBetweenGroupSpawn[this.currentSpawningEnemyGroupIndex]);
        this.isReadyToSpawn = true;
        Instantiate (this.enemyGroups[this.currentSpawningEnemyGroupIndex], this.enemyGroupSpawningPoints[this.currentSpawningEnemyGroupIndex].position, this.enemyGroupSpawningPoints[this.currentSpawningEnemyGroupIndex].rotation);
        this.currentSpawningEnemyGroupIndex++;
    }
}
