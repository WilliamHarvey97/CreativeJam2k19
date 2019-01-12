using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseEditor : MonoBehaviour
{
    public GameObject tower;
    public bool isEmpty = true;
    public float radius;

    void OnMouseOver() {
        if(Input.GetMouseButtonDown(0) && isEmpty) {
            GameObject towerObj = GameObject.Instantiate<GameObject>(tower);
            towerObj.transform.position = new Vector3(
                this.transform.position.x,
                towerObj.transform.localScale.y,
                this.transform.position.z);
            TowerLauncher towerLauncher = towerObj.GetComponent<TowerLauncher>();
            towerLauncher.radius = radius;
            isEmpty = false;
        }
    }
}
