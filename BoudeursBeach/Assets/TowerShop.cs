using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    public GameObject game;
    public SelectedTower currentSelectedTower;
    public TowerLauncher[] availableTowers;
    public enum SelectedTower { Ballistic, Heavy };
    void Start()
    {
        currentSelectedTower = SelectedTower.Ballistic;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1)) {
            currentSelectedTower = SelectedTower.Ballistic;
        } else if(Input.GetKeyDown(KeyCode.Keypad2)) {
            currentSelectedTower = SelectedTower.Heavy;
        }
    }
}
