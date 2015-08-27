using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	public bool Shaking;
	
	// How long the object should shake for.
	public float shake = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	
	Vector3 CamPos;
	Vector3 CenterPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void Update()
	{
		if (shake > 0)
		{
			camTransform.localPosition = CenterPos + Random.insideUnitSphere * shakeAmount;
			
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0f;
			camTransform.localPosition = CenterPos;
			CenterPos = new Vector3(this.transform.position.x,this.transform.position.y,-20);
		}
	}

	void Shake(){
		shake = 0.05f;
	}
}