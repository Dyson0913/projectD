using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	Rigidbody2D playerRigidbody2d;
	
	[Header("horispped")]
	public float speedX;

	[Header("horisY")]
	public float speedY;

	[Header("horesway")]
	public float horizontalDirection;

	const string HORIZONTAL = "Horizontal";

	[Header("最大水平速度")]
	[Range(0,150)]
	public float xForce;

	[Header("最大水平速度")]
	public float maxSpeedX;

	[Header("跳速度")]
	public float yForce;

	[Header("感應地板的距離")]
	[Range(0,0.5f)]
	public float distance;

	[Header("偵測地板的射線起點")]
	public Transform groundCheck;

	[Header("地面圖層")]
	public LayerMask groundLayber;

	public bool grounded;

	private float Xacceleratetion;

	public Hud hudscript;

	public PreAppearZone preAppearZone;

	public InfinityGround infinityGround;

	public InfinityGround bgL1;

	/* 玩家地版射線 */
	bool isGround{
		get {
			Vector2 start = groundCheck.position;
			Vector2 end = new Vector2(start.x,start.y - distance);
			Debug.DrawLine(start,end ,Color.blue);
			grounded = Physics2D.Linecast(start,end,groundLayber);
			return grounded;
		}
	}

	public bool JumpKey{
		get {
			return Input.GetKeyDown(KeyCode.Space);
		}
	}

	void Tryjump(){
		if ( isGround && JumpKey){
			playerRigidbody2d.AddForce(Vector2.up*yForce);
		}
	}

	void controlSpeed(){
		speedX = playerRigidbody2d.velocity.x;
		speedY = playerRigidbody2d.velocity.y;
		float newSpeedX = Mathf.Clamp(speedX,-maxSpeedX,maxSpeedX);
		playerRigidbody2d.velocity = new Vector2(newSpeedX,speedY);
		
	}
	// Use this for initialization
	void Start () {
		playerRigidbody2d = GetComponent<Rigidbody2D>();

	}
	
	/*

	 */
	void MovementX(){
		horizontalDirection = Input.GetAxis(HORIZONTAL);
		Xacceleratetion = xForce*horizontalDirection;
		
		//TODO 看到signal做法再改
		hudscript.GetComponent<Hud>().distanceUpdate(this.transform.position.x);
		//preAppearZone.GetComponent<PreAppearZone>().distanceUpdate(this.transform.position.x);
		infinityGround.GetComponent<InfinityGround>().distanceUpdate(this.transform.position.x);
		bgL1.GetComponent<InfinityGround>().distanceUpdate(this.transform.position.x);

		playerRigidbody2d.AddForce(new Vector2(Xacceleratetion,0));
	}

	// Update is called once per frame
	void Update () {
		MovementX();
		controlSpeed();
		Tryjump();
	}
}
