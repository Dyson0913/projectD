using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreAppearZone : MonoBehaviour
{

	public GameObject referrenceTransform;

    public GameObject[] obstaic;

    public GameObject worldCenter;

    Queue<GameObject> itemQueue;



    // Use this for initialization
    void Start()
    {
        //itemQueue.
        itemQueue = new Queue<GameObject>();
		
		for (int i = 0; i < 5;i++ )
        {
			var instance = Instantiate(obstaic[0],new Vector2(3+i*10,(i+1)*1),transform.rotation);
            instance.gameObject.name = "Item_"+i.ToString();
			instance.transform.parent = worldCenter.transform;
            itemQueue.Enqueue(instance);     
            //itemQueue.ToArray()[i].SetActive(false);
        }
        
        
		//showZoneItemFlush();
        // Rect rect = this.GetComponent<SpriteRenderer>().sprite.rect;
        // Debug.Log(" h " +rect.height);
        // Debug.Log(" w " +rect.width);        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {       
        var colname =  col.gameObject.name.Substring(0,4);

        if( colname == "Item"){
            var colidx = int.Parse(col.gameObject.name.Substring(5));
            itemQueue.ToArray()[colidx].SetActive(true);
            //Debug.Log(colidx);
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        // var coll2d = Physics2D.OverlapBox(new Vector2(referrenceTransform.transform.position.x,referrenceTransform.transform.position.y),new Vector2(1,1),0);
        // if( coll2d){
        //     Debug.Log("touch "+ coll2d.gameObject.name);
        //     //coll2d.gameObject.SetActive(true);
        // }
    }

	/*更新區物件刷新 */
    void showZoneItemFlush()
    {
		for( int i =0; i< itemQueue.Count; i++){
            itemQueue.ToArray()[i].SetActive(false);
		}
    }

    public void distanceUpdate(float playerX)
    {        
		if(referrenceTransform.transform.position.x-itemQueue.Peek().transform.position.x>=2f)
		//if(referrenceTransform.transform.position.x-itemQueue.ToArray()[2].transform.position.x>=2f)
        {
            GameObject cube = itemQueue.Dequeue();
            cube.transform.position = new Vector3(itemQueue.ToArray()[itemQueue.Count - 1].transform.position.x+1, cube.transform.transform.position.y, 0);
            itemQueue.Enqueue(cube);
        }
    }
}
