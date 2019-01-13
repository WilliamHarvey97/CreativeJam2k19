 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;

public class Game : MonoBehaviour
{
    public Level[] levels;
    public int EnemiesGone = 0;
    public GameObject player;
    public int MaxEnemiesThatCanLeave = 5;
    public Camera camera;
    public int money = 0;
    private int currentWaveIndex = 0;
    private int currentLevelIndex;
    private bool isGameOver = false;

    void Start() {
        this.currentLevelIndex = 0;
        this.startNextLevel();
    }

    void FixedUpdate() {
        if(this.currentLevelIndex < this.levels.Length && this.levels[this.currentLevelIndex].getIsLevelCleared()) {
            this.currentLevelIndex++;
            this.startNextLevel();
        }
        if(this.isPlayerDead()) {
            this.gameOver();
        }
    }

    void movePlayerAndCamera(Vector3 position) {
        Vector3 playerInitialPosition = this.player.transform.position;
        this.player.transform.position = position;
        Vector3 offset = position - playerInitialPosition;
        this.camera.transform.position += offset;
    }

    private void startNextLevel() {
        Debug.Log("Next Level!" + this.currentLevelIndex);
        if(this.currentLevelIndex <= this.levels.Length - 1) {
            this.movePlayerAndCamera(this.levels[this.currentLevelIndex].playerSpawnPoint.transform.position);
            this.levels[this.currentLevelIndex].startLevel();
        } 
    }

    private bool isPlayerDead() {
        return this.player.GetComponent<PlayerController>().health <= 0;
    }

    public int getCurrentWaveIndex() {
        return this.currentWaveIndex;
    }

    public int getCurrentLevelIndex() {
        return this.currentLevelIndex;
    }

    public int getTimeUntilNextWave() {
        return this.levels[this.currentLevelIndex].timerBeforeWave.getTimer();
    }

    public void gameOver() {
        this.isGameOver = true;
        Debug.Log("Game Over!");
    }
    
    // Can be a payment or a refund
    public void addMoney(int dollars) {
        this.money += dollars;
    }
}
