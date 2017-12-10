using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float spd;
    public int startHealth = 10;
    private int health = 10;
    public int Health
    {
        get { return health; }
    }

    private Vector2 input;

    private Rigidbody bod;
    private Collider col;

	// Use this for initialization
	void Awake () {
        bod = GetComponent<Rigidbody>();
        ResetStats();
	}

    void ResetStats()
    {
        health = startHealth;
    }
	
	// Update is called once per frame
	void Update () {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.x != 0) bod.AddForce(input.x * transform.forward * spd * Time.deltaTime);
        if (input.y != 0) bod.AddForce(-1 * input.y * transform.right * spd * Time.deltaTime);

        if (Health <= 0)
        {
            Debug.Log("D E A D");
        }
    }
}
