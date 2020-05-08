using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform transform;
 
    // Desired duration of the shake effect
    private float shakeDuration = 0f;
    
    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.1f;
    
    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.2f;
    
    // The initial position of the GameObject
    Vector3 initialPosition;

void Awake()
{
  if (transform == null)
  {
   transform = GetComponent(typeof(Transform)) as Transform;
  }
}
void OnEnable()
 {
  initialPosition = transform.localPosition;
 }
 void Update()
{
  if (shakeDuration > 0)
  {
   transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
   
   shakeDuration -= Time.deltaTime * dampingSpeed;
  }
  else
  {
   shakeDuration = 0f;
   transform.localPosition = initialPosition;
  }
}
public void TriggerShake() {
  shakeDuration = 0.2f;
}
}
