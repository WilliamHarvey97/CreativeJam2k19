using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseEditor : MonoBehaviour
{
    // towerRef can be any class inherited by the TowerLauncher (or the TowerLauncher itself)
    public GameObject towerRef;
    public GameObject particleRef;
    public float particleAnimationDuration;
    public float radius;
    public float reloadTime;

    private GameObject towerClone;
    private GameObject particleClone;
    private ParticleSystem particleEffect;
    private bool isEmpty = true;
    private float particleTimeSinceCreation;

    void Awake() {
        this.particleClone = GameObject.Instantiate(particleRef);
        this.particleClone.transform.position = this.transform.position;
        this.particleEffect = particleClone.GetComponent<ParticleSystem>();
        this.particleEffect.Stop();
        this.particleTimeSinceCreation = 0f;
    }

    void Update() {
        if(this.particleEffect.isPlaying && particleTimeSinceCreation < particleAnimationDuration) {
            particleTimeSinceCreation += Time.deltaTime;
        } else if(this.particleEffect.isPlaying && particleTimeSinceCreation >= particleAnimationDuration) {
            this.particleEffect.Stop();
            particleTimeSinceCreation = 0f;
        }
    }

    void OnMouseOver() {

        if(Input.GetMouseButtonDown(0) && isEmpty) {
            towerClone = GameObject.Instantiate<GameObject>(towerRef);
            towerClone.transform.position = new Vector3(
                this.transform.position.x,
                towerClone.transform.localScale.y,
                this.transform.position.z);
            TowerLauncher towerLauncher = towerClone.GetComponent<TowerLauncher>();
            towerLauncher.Initialize(radius, reloadTime);

            this.particleEffect.Play();
            isEmpty = false;
        } else if(Input.GetMouseButtonDown(1) && !isEmpty) {
            Destroy(towerClone);
            isEmpty = true;
        }

    }
}
