using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurret : MonoBehaviour
{
    public float speed;
    
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("RotateTurret") * speed * Time.deltaTime;

		transform.Rotate(0, rotation, 0);
    }
}
