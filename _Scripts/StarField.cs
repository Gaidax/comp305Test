using UnityEngine;
using System.Collections;

public class StarField : MonoBehaviour {

    public int maxStars = 1000;
    public int universeSize = 10;

    private ParticleSystem.Particle[] points;

    private ParticleSystem _particleSystem;

    private void Create()
    {

        points = new ParticleSystem.Particle[maxStars];

        for (int i = 0; i < maxStars; i++)
        {
            points[i].position = Random.insideUnitSphere * universeSize;
            points[i].startSize = Random.Range(0.05f, 0.05f);
            points[i].startColor = new Color(1, 1, 1, 1);
        }

        _particleSystem = gameObject.GetComponent<ParticleSystem>();

        _particleSystem.SetParticles(points, points.Length);
    }

    // Use this for initialization
    void Start () {
        Create();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
