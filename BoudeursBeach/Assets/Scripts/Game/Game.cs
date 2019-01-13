 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;

public class Game : MonoBehaviour
{
    public int wavesDones = 3;
    public int EnemiesGone = 0;
    public int MaxEnemiesThatCanLeave = 5;
     
     public Text timeLeftText;

    void Update()
    {
        int timeLeft = GameObject.FindWithTag("WaveTimer").gameObject.
        timeLeftText.text = "Time until Next Wave:" + Mathf.Round(timeLeft);
        if(timeLeft <= 0)
        {
        }
    }
}
