using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {
	public const int MAX_SOCIALIZING = 12;
	public const int MAX_GLASSES_HP = 4;
	public const float INVULN = 0.2f;

    public float percentOfScreenMovable = 0.4f;
    public static float defaultMovementSpeed = 10f;

    public float movementSpeed;
    [SerializeField]
    public PlayerIndex playerIndex;

    public bool onCoffee;
	public bool onEnergyDrink;
    public int socializing;
    BlurOptimized blur;
	[SerializeField]
	GameObject cracksGameObject;
	Image cracks;
	[SerializeField]
	Sprite[] cracksStates;
    public int glassesHp;

	float invul;

	TrailRenderer trail;

	MotionBlur motBlur;

    SpriteRenderer redSprite;

    void Start() {
		motBlur = Camera.main.GetComponent<MotionBlur> ();
		onEnergyDrink = false;
		trail = GetComponentInChildren<TrailRenderer> ();
        movementSpeed = defaultMovementSpeed;
        redSprite = gameObject.transform.Find("nerd_red").GetComponent<SpriteRenderer>();
       // controller = GetComponent<XInputControl>();
        glassesHp = MAX_GLASSES_HP;
		blur = Camera.main.GetComponent<BlurOptimized> ();
		cracks = cracksGameObject.GetComponent<Image>();
    }

    public void OnHit() {
		if (invul > 0)
			return;
		
		glassesHp--;
		if (glassesHp > 0) {
			cracks.enabled = true;
			cracks.sprite = cracksStates [3 - glassesHp];
			blur.enabled = true;
			cracksGameObject.SetActive (true);
			blur.blurIterations = 4 - glassesHp;
		}
		invul = INVULN;

	}
	public void Heal() {
		glassesHp = MAX_GLASSES_HP;
		cracks.enabled = false;
		blur.enabled = false;
		cracksGameObject.SetActive (false);
		blur.blurIterations = 4;
	}

	public void IncreaseSocializing(int value) {
		socializing+=value;
		Color c = redSprite.color;
		c.a = (float)socializing / MAX_SOCIALIZING;
		redSprite.color = c;


		if (socializing >= MAX_SOCIALIZING && GameManagerBehaviour.instance.levelName != "Level Emoji") {
			// load boss scene 
			SceneManager.LoadScene("Boss 1");
		}
	}

	public void IncreaseSocializing() {
		IncreaseSocializing (1);
	}

    void Update() {
		motBlur.enabled = onCoffee;
		trail.enabled = onEnergyDrink;


		if (invul > 0)
			invul -= Time.deltaTime;
		
        // get camera width
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;


        float hor = 0.0f;
        float ver = 0.0f;
     

       // Debug.Log("hor: " + Input.GetAxis("Horizontal") + "\n" +
        //                "ver: " + Input.GetAxis("Vertical") + "\n");

        //if (hor == 0)
        if (Input.GetAxis("Horizontal") != 0)
        {
            hor = Input.GetAxis("Horizontal" + (playerIndex == PlayerIndex.Two ? "2" : ""));
        }
        else hor = 0.0f;
        // if (ver == 0) 
        if (Input.GetAxis("Vertical") != 0)
        {
            ver = Input.GetAxis("Vertical" + (playerIndex == PlayerIndex.Two ? "2" : ""));
        }
        else ver = 0.0f;

        transform.Translate(hor * Time.deltaTime * movementSpeed, ver * Time.deltaTime * movementSpeed, 0);

        /*
        if (GetComponent<XInputControl>().state.Triggers.Right != GetComponent<XInputControl>().prevState.Triggers.Right) {

            // REFERENCE: GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
            GamePad.SetVibration(GetComponent<XInputControl>().playerIndex, GetComponent<XInputControl>().state.Triggers.Left, GetComponent<XInputControl>().state.Triggers.Right);
        }*/


		if (SceneManager.GetActiveScene ().name.IndexOf("Boss") > -1) {
			percentOfScreenMovable = 1;
		} else {
			percentOfScreenMovable = 0.4f;
		}

        // clamping to movement area
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x,
            -width / 2f * percentOfScreenMovable,
            width / 2f * percentOfScreenMovable);
        pos.y = Mathf.Clamp(pos.y,
            -height / 2f * percentOfScreenMovable,
            height / 2f * percentOfScreenMovable);

        transform.position = pos;
    }
}
