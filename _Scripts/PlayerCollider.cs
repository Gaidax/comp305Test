//Vasyl Milchevskyi
//300839782
//COMP305

using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public GameController gameController;
    public EnemyController enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Checks if player hits TIE Fighter tagged object (enemy)
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("TIE Fighter"))
        {
            gameController.HullPoints -= 1;
            other.GetComponent<Transform>().position = enemy.getResetPos();
        }

    }
}
