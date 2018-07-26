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
			var instance = Instantiate(obstaic[0],new Vector2(10+i*3,(i+1)*1),transform.rotation);
			instance.transform.parent = worldCenter.transform;
            itemQueue.Enqueue(instance);
        }

		//showZoneItemFlush();
        

    }

    // Update is called once per frame
    void Update()
    {

    }

	/*更新區物件刷新 */
    void showZoneItemFlush()
    {
		for( int i =0; i< itemQueue.Count; i++){

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
