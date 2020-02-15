using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	AudioSource friendlyHitSound;
	public AudioClip clip;

	void Start()
	{
		friendlyHitSound = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetButton("Fire"))
		{
			RaycastHit hit;
			Vector3 rayOrigin = transform.position;
			Vector3 rayDirection = transform.up;
			Color rayColor;

			if(Physics.Raycast(rayOrigin, rayDirection, out hit)){
				rayColor = Color.green;
				// Debug.Log("hit");

				if(hit.collider.gameObject.tag != "indestructible"){
					Destroy(hit.collider.gameObject);
					Debug.Log("Destroying '"+hit.collider.gameObject.name+"'");
				} 
				else if(hit.collider.gameObject.name.Contains("Friendly")){
					if(!friendlyHitSound.isPlaying){
						friendlyHitSound.play();
					}
				}
			} else {
				rayColor = Color.red;
				// Debug.Log("miss");
			}

			float lineLength;
			if(hit.distance < 0.001f){
				lineLength = 99999f;
			} else {
				lineLength = hit.distance;
			}

			Debug.DrawRay(rayOrigin, rayDirection * lineLength, rayColor);
		}
	}

	// void Update()
	// {
	//     RaycastHit hit;
	//     if (Physics.Raycast(transform.position, -transform.up, out hit)){
	//         //float height
	//     }
	// }
}
