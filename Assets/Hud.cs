using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using System.IO;

public class Hud : MonoBehaviour {

	//PlayerPrefs.SetInt("",	

	public Text walkdis;
	// Use this for initialization

	public Text gameSubtitle;

	private string filename = "StartCredit.json";

	//提示文字
	private string[] creditText;
	private int[] displayPo;
	private int CurrentDisplayPo;
	private bool showText;
	
	void Start () {
		walkdis.text = 0.ToString();

		gameSubtitle.text = "";
		CurrentDisplayPo = 0;
		showText = true;

		loadjson(filename);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void distanceUpdate(float acclerate){
		float curDistance = Mathf.Ceil(acclerate);
		walkdis.text = curDistance.ToString();

		//檢查是否播下個文字提示
		if( showText && curDistance > displayPo[CurrentDisplayPo] ){
			subtilteUpdate();
			CurrentDisplayPo = (CurrentDisplayPo + 1);
			//超過後就不再更新
			if( CurrentDisplayPo >= displayPo.Length) showText = false;

		}
	}

	void subtilteUpdate(){
		gameSubtitle.text = creditText[CurrentDisplayPo];
	}

	void loadjson(string filename){
		string filePath = Path.Combine(Application.streamingAssetsPath, filename);

		if(File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath); 
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
			
            // // Retrieve the allRoundData property of loadedData
            creditText = loadedData.creditText;
			displayPo = loadedData.displayPo;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
	}
}
