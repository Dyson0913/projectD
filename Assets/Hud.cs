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
	private string[] allRoundData;

	
	void Start () {
		walkdis.text = 0.ToString();
		loadjson(filename);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void distanceUpdate(float acclerate){
		walkdis.text = Mathf.Ceil(acclerate).ToString();
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
            allRoundData = loadedData.allRoundData;
			Debug.Log("allRoundData "+allRoundData[1]);
			gameSubtitle.text = allRoundData[1];
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
	}
}
