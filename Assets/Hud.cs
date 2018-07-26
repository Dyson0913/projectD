using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

	
	public Text walkdis;
	// Use this for initialization
	void Start () {
		walkdis.text = 0.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void distanceUpdate(float acclerate){
		walkdis.text = Mathf.Ceil(acclerate).ToString();
	}
}
