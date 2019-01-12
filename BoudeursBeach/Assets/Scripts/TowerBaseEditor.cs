using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseEditor : MonoBehaviour
{
    // towerRef can be any class inherited by the TowerLauncher (or the TowerLauncher itself)
    public GameObject towerRef;
    public float radius;
    public float reloadTime;

    private GameObject towerClone;
    private bool isEmpty = true;

    void OnMouseOver() {
        if(Input.GetMouseButtonDown(0) && isEmpty) {
            towerClone = GameObject.Instantiate<GameObject>(towerRef);
            towerClone.transform.position = new Vector3(
                this.transform.position.x,
                towerClone.transform.localScale.y,
                this.transform.position.z);
            TowerLauncher towerLauncher = towerClone.GetComponent<TowerLauncher>();
            towerLauncher.Initialize(radius, reloadTime);
            isEmpty = false;
        } else if(Input.GetMouseButtonDown(1) && !isEmpty) {
            Destroy(towerClone);
            isEmpty = true;
        }
    }
}
