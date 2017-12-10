using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private GameObject player;
    public float rotateSpeed = 5;
    Vector3 offset;
    
	void Awake () {
        player = FindObjectOfType<PlayerController>().gameObject;
        offset = player.transform.position - transform.position;
	}
	
	void LateUpdate () {
        //Lock mouse in game
        //Follow y-axis too?
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);

        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = player.transform.position - (rotation * offset);

        transform.LookAt(player.transform);
	}
}
