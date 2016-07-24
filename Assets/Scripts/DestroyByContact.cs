using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    public int scoreValue;


    void Start()
    {
        var gameController1 = GameObject.FindWithTag("GameController");

        if(gameController1)
        {
            gameController = gameController1.GetComponent<GameController>();
        }

        if(gameController == null)
        {
            Debug.LogError("Cannot find 'Game Controller'!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundry")
        {
            return;
        }
        GameObject created1 = Instantiate(explosion, transform.position, transform.rotation) as GameObject;

        if (other.tag == "Player")
        {
            GameObject created2 = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
