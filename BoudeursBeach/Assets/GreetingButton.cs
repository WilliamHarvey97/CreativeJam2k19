using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GreetingButton : MonoBehaviour
{
    public Button button;
    public string playingSceneName;

    void Start() {
        this.button.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        SceneManager.LoadScene(this.playingSceneName, LoadSceneMode.Single);
        Debug.Log("Allo");
    }
}
