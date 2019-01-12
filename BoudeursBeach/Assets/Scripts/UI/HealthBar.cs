using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject followedObject;
 
    void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(followedObject.transform.position);
    }
}
