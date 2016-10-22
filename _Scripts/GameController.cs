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

    // Use this for initialization
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

	// generate Clouds
	private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
            Instantiate(enemy);
            enemies.Add(enemy);
		}
	}

    private void _endGame()
    {
        GameOverLabel.gameObject.SetActive(true);
        FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        FinalScoreLabel.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        ScoreLabel.gameObject.SetActive(false);
        HullPointsLabel.gameObject.SetActive(false);
        falcon.SetActive(false);
        //setObject(false, enemies);

        //_endGameSound.Play();
    }

    private void setObject(bool set, List<GameObject> obj_list)
    {
        foreach (GameObject obj in obj_list)
        {
            obj.SetActive(set);

        }
    }

    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Main");
    }
}
