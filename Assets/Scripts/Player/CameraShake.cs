using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * We use this script to initiate the camera shake effect when we use the TriggerPoint script;
 * 
 */
public class CameraShake : MonoBehaviour
{
	[SerializeField] private Transform camTransform;

	// How long the object should shake for;
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder;
	[SerializeField] private float shakeAmount = 0.05f;
	[SerializeField] private float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}
