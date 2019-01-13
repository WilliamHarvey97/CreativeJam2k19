using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseEditor : MonoBehaviour
{
    public GameObject towerRef;
    public GameObject particleRef;
    public Material transparentMaterial;
    public Material opaqueMaterial;
    public float particleAnimationDuration;
    public float radius;
    public float reloadTime;

    private GameObject towerClone;
    private GameObject particleClone;
    private ParticleSystem particleEffect;
    private bool isEmpty = true;
    private float particleTimeSinceCreation;
    private MeshRenderer towerRenderer;
    private Collider towerCollider;
    private Collider baseCollider;

    void Awake() {
        InitializeParticleEffects();
        InitiliazeTower();
    }

    void InitializeParticleEffects() {
        this.particleClone = GameObject.Instantiate(particleRef);
        this.particleClone.transform.position = this.transform.position;
        this.particleEffect = particleClone.GetComponent<ParticleSystem>();
        this.particleEffect.Stop();
        this.particleTimeSinceCreation = 0f;
    }

    void InitiliazeTower() {
        this.towerClone = GameObject.Instantiate<GameObject>(towerRef);  
        this.towerClone.transform.position = new Vector3(
                this.transform.position.x,
                towerClone.transform.localScale.y,
                this.transform.position.z);
        this.towerClone.GetComponent<TowerLauncher>().Initialize(radius, reloadTime);
        this.towerClone.SetActive(false);

        this.towerCollider = this.towerClone.GetComponent<Collider>();
        this.baseCollider = this.GetComponent<Collider>();

        this.towerRenderer = this.towerClone.GetComponent<MeshRenderer>();
    }
    
    void Update() {
        if(isTouchingTowerBase() || isTouchingTower()){
            if(Input.GetMouseButtonDown(0) && isEmpty) {
                this.towerClone.SetActive(true);
                this.towerRenderer.material = opaqueMaterial;
                this.particleEffect.Play();
                isEmpty = false;
            } else if(Input.GetMouseButtonDown(1) && !isEmpty) {
                this.towerClone.SetActive(false);
                isEmpty = true;
            } else if (isEmpty){
                this.towerClone.SetActive(true);
                this.towerRenderer.material = transparentMaterial;
            }
        } else if(isEmpty) {
            this.towerClone.SetActive(false);
        }

        updateParticleEffects();
    }

    bool isTouchingTowerBase() {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit towerBaseRayHit;
        return baseCollider.Raycast(rayOrigin, out towerBaseRayHit, Mathf.Infinity);
    }

    bool isTouchingTower() {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit towerRayHit;
        return towerCollider.Raycast(rayOrigin, out towerRayHit, Mathf.Infinity);
    }

    void updateParticleEffects() {
        if(this.particleEffect.isPlaying && particleTimeSinceCreation < particleAnimationDuration) {
            particleTimeSinceCreation += Time.deltaTime;
        } else if(this.particleEffect.isPlaying && particleTimeSinceCreation >= particleAnimationDuration) {
            this.particleEffect.Stop();
            particleTimeSinceCreation = 0f;
        }
    }
}
