using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour{	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	void Update(){
		if (shakeDuration > 0){
			Camera.main.transform.position = Camera.main.transform.position + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else{
			shakeDuration = 0f;	
		}
	}
}
 
