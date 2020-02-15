using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TankEmpty : MonoBehaviour
{
	public float MoveSpeed;
	public float FloatHeight = 0.5f;

	void Update()
	{
		ParseInput();
		UpdateOrientation();
	}

	void ParseInput()
	{
		float forwardInput = Input.GetAxis("MoveForward");
		float sidewaysInput = Input.GetAxis("MoveSideways");

		Vector3 movement = Vector3.zero;
		movement += transform.forward * forwardInput;
		movement += transform.right * sidewaysInput;
		movement.Normalize();

		transform.Translate(movement * MoveSpeed * Time.deltaTime);
	}

	void UpdateOrientation()
	{
		RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit)){
            //float height
			transform.Translate(0, FloatHeight - hit.distance, 0);

			//rotation
			Vector3 oldEulerAngles = transform.rotation.eulerAngles;

			Quaternion planeRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
			transform.eulerAngles = new Vector3(planeRotation.eulerAngles.x, oldEulerAngles.y, planeRotation.eulerAngles.z);

		}
	}
}
