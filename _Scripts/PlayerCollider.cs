using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public GameController gameController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("TIE Fighter"))
        {
            gameController.HullPoints -= 1;

        }

    }
}
