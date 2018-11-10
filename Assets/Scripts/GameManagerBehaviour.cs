using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public string levelName;

	[SerializeField]
	Boss_Zelina zelina;

	[SerializeField]
	Scene boss;
	[SerializeField]
	public string nextScene_Completed;


    protected GameObject confidenceArrow;

    public int levelProgress;

    private float currentPowerUpDelay;

    private float levelTime;
    public readonly int level;


	IEnumerator Level1() {
		int levelProgressAbs = 0;
		while (levelProgress < MAX_CONFIDENCE) {
			Debug.Log ("Levelprogress: "+levelProgressAbs);
			if (levelProgressAbs ==	 0) {
				enemies [0].SetActive (true);
				levelProgressAbs++;
			}
			Debug.Log (MAX_CONFIDENCE/3);
			if (levelProgressAbs == 1 && levelProgress >= MAX_CONFIDENCE/3) {
				enemies [1].SetActive (true);
				yield return new WaitForSeconds (30f);
				enemies [1].SetActive (false);

				levelProgressAbs++;

			}

			if (levelProgressAbs == 2 && levelProgress >= 2*MAX_CONFIDENCE/3) {
				enemies [0].SetActive (false);
				yield return new WaitForSeconds (3f);
				enemies [2].SetActive (true);
				enemies [3].SetActive (true);
				levelProgressAbs++;
			}
			yield return new WaitForSeconds(1f);
		}


	/*	yield return new WaitForSeconds (2f);
		enemies [0].SetActive (true);
		yield return new WaitForSeconds (12f);
		enemies [1].SetActive (true);
		yield return new WaitForSeconds (12f);
		enemies [0].SetActive (false);
		yield return new WaitForSeconds (3f);
		enemies [1].SetActive (false);

		enemies [2].SetActive (true);
		enemies [3].SetActive (true); */

	}
	IEnumerator LevelZelina() {
		
	//	Debug.Log ("levelPRogress: " + levelProgress);
		zelina.setPhase (0);
		while (zelina.getPhase() == 0) {
			//Debug.Log (levelProgress+" test1337");
			if (levelProgress >= 10) {
				zelina.setPhase (1);
			}
			yield return new WaitForSeconds (0.5f);
		}
		while (zelina.getPhase() == 1) {

			if (levelProgress >= 20) {
				zelina.setPhase(1);
			}
			yield return new WaitForSeconds (0.5f);
		}
		yield break;
	}

    void Start() {
        instance = this;
        player = FindObjectOfType<PlayerBehaviour>();
		confidenceArrow = GameObject.Find ("ConfidenceArrow");
        PickCurrentDelay();
		if (levelName.Equals ("Level1")) {
			StartCoroutine (Level1 ());

		}
		if (levelName.Equals ("Level Zelina")) {
			StartCoroutine (LevelZelina ());
		}
    }

    public void increaseLevelProgress() {
		levelProgress++;
		//Debug.Log ("gege");
		confidenceArrow.transform.rotation = Quaternion.Euler (0, 0, -90 * (1 - Mathf.Min(1, (float)levelProgress / MAX_CONFIDENCE)));
		if (levelProgress == MAX_CONFIDENCE) {
			// load boss scene 
			SceneManager.LoadScene(nextScene_Completed);
		}
	}

    private void PickCurrentDelay() {
        currentPowerUpDelay = Random.Range(minPowerUpDelay, maxPowerUpDelay);
    }

    void Update() {
		if (Input.GetKeyDown ("left ctrl"))
			increaseLevelProgress ();

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
