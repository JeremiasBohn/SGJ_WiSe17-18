using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour {
	const int MAX_CONFIDENCE = 20;
    public static GameManagerBehaviour instance;

    public PlayerBehaviour player;

    [SerializeField]
    float minPowerUpDelay = 4f;

    [SerializeField]
    float maxPowerUpDelay = 10f;

    [SerializeField]
    GameObject[] powerUps;

    [SerializeField]
    GameObject[] enemies;

	[SerializeField]
	string levelName;

	[SerializeField]
	Boss_Zelina zelina;


    protected GameObject confidenceArrow;

    public int levelProgress;

    private float currentPowerUpDelay;

    private float levelTime;
    public readonly int level;

	IEnumerator Level1() {
		yield return new WaitForSeconds (2f);
		enemies [0].SetActive (true);
		yield return new WaitForSeconds (12f);
		enemies [1].SetActive (true);
		yield return new WaitForSeconds (12f);
		enemies [0].SetActive (false);
		yield return new WaitForSeconds (3f);
		enemies [1].SetActive (false);

		enemies [2].SetActive (true);
		enemies [3].SetActive (true);

	}
	IEnumerator LevelZelina() {
		if (levelProgress < 10) {
			zelina.setPhase (0);
		} else {
			zelina.setPhase (1);
		}
		yield break;
	}

    void Start() {
        instance = this;
        player = FindObjectOfType<PlayerBehaviour>();
		confidenceArrow = GameObject.Find ("ConfidenceArrow");
        PickCurrentDelay();
		if (levelName.Equals ("Level 1")) {
			StartCoroutine (Level1 ());
		}
		if (levelName.Equals ("Level Zelina")) {
			StartCoroutine (LevelZelina ());
		}
    }

    public void increaseLevelProgress() {
        levelProgress++;
		confidenceArrow.transform.rotation = Quaternion.Euler (0, 0, -90 * (1-((float)levelProgress / MAX_CONFIDENCE)));
		LevelZelina ();
    }

    private void PickCurrentDelay() {
        currentPowerUpDelay = Random.Range(minPowerUpDelay, maxPowerUpDelay);
    }

    void Update() {
        currentPowerUpDelay -= Time.deltaTime;

        if (currentPowerUpDelay <= 0) {
            SpawnPowerUp();
            PickCurrentDelay();
        }
    }

    protected Vector3 PickPosition() {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Vector3 pos = Random.onUnitSphere;
        pos.x *= width;
        pos.y *= height;
		pos.z = 0;

        return pos;
    }

    protected void SpawnPowerUp() {
		GameObject powerUp = powerUps [Random.Range (0, powerUps.Length)];
		Vector3 pos = PickPosition ();
		if (powerUp.name == "PowerUp_Tissue") {
			pos.y = 7;
			pos.x = Mathf.Clamp (pos.x, -6, 6);
		}
        Instantiate(powerUp, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
    }
}
