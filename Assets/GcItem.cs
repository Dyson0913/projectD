using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GcItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {       
        var colname =  col.gameObject.name.Substring(0,4);

        if( colname == "Item"){
            var colidx = int.Parse(col.gameObject.name.Substring(5));
			Object.Destroy(col.gameObject);
            Debug.Log(colidx);
        }
        
       
    }
}
