using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour
{

    private Rigidbody rg;

    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    private AudioSource audioSource;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject created = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rg.velocity = new Vector3(h, 0.0f, v) * speed;

        rg.position = new Vector3
            (
            Mathf.Clamp(rg.position.x, boundary.xmin, boundary.xmax),
            0.0f,
            Mathf.Clamp(rg.position.z, boundary.zmin, boundary.zmax)
            );

        rg.rotation = Quaternion.Euler(0.0f, 0.0f, rg.velocity.x * -tilt);
    }
}
