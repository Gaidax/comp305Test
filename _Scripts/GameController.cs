//Vasyl Milchevskyi
//300839782
//COMP305

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private int _hullPoints;
    private int _score;
    private List<GameObject> enemies;

    // PUBLIC INSTANCE VARIABLES
    public int enemyCount;
    public Text HullPointsLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;
    public GameObject falcon;
    public GameObject enemy;
    

    //getter and setter for hull points (assignes changes for label as well)
    public int HullPoints
    {
        get
        {
            return _hullPoints;
        }

        set
        {
            _hullPoints = value;
            if (_hullPoints <= 0)
            {
                _endGame();
            }
            else
            {
                HullPointsLabel.text = "Hull Points: " + _hullPoints;
            }
        }
    }

    //getter and setter for Score (for label as well)
    public int ScoreValue
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            ScoreLabel.text = "Score: " + _score;
        }
    }

    //Initializing the game, hull points, score and all the end game labels disabled
    void Start () {
        HullPoints = 5;
        ScoreValue = 0;

        GameOverLabel.gameObject.SetActive(false);
        FinalScoreLabel.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        this._GenerateEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Enemies
	private void _GenerateEnemies() {
        enemies = new List<GameObject>();
		for (int count=0; count < this.enemyCount; count++) {
            Instantiate(enemy);
            enemies.Add(enemy);
		}
	}
    
    //End Game after hull points are zero
    private void _endGame()
    {
        GameOverLabel.gameObject.SetActive(true);
        FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        FinalScoreLabel.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        ScoreLabel.gameObject.SetActive(false);
        HullPointsLabel.gameObject.SetActive(false);
        falcon.SetActive(false);
        setObject(false, enemies);

        //_endGameSound.Play();
    }

    private void setObject(bool set, List<GameObject> obj_list)
    {
        foreach (GameObject obj in obj_list)
        {
            obj.SetActive(set);

        }
    }

    //Loads Main Scene when restart button clicked
    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Main");
    }
}
