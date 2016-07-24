using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	private Rigidbody rg;

	public float tumble;

	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody>();

        rg.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
