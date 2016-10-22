//Vasyl Milchevskyi
//300839782
//COMP305

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;
    public GameController gameController;
    public GameObject explosionParticle;

    // PRIVATE INSTANCE VARIABLES
    private float _CurrentSpeed;
	private float _CurrentDrift;

	// Use this for initialization
	void Start () {
		this._Reset ();
	}

    public Vector2 getResetPos()
    {
        return new Vector2(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax); ;
    }
	
	// Update is called once per frame
    //tie fighter movement
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.y <= boundary.yMin) {
			this._Reset();
            gameController.ScoreValue += 10;
		}
	}

	// resets the gameObject
	public void _Reset() {
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		gameObject.GetComponent<Transform> ().position = getResetPos();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            gameController.ScoreValue += 100;
            Instantiate(explosionParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(other.gameObject);
            _Reset();
        }
    }
}
