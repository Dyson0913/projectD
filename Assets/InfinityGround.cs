using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityGround : MonoBehaviour {

	public GameObject referrenceTransform;

    public GameObject[] obstaic;

    public GameObject worldCenter;

    Queue<GameObject> itemQueue;

	public float groundDistance;

	public float grounChunkNum;

	private int groundMiddenNum;

    // Use this for initialization
    void Start()
    {
        //itemQueue.
        itemQueue = new Queue<GameObject>();
		
		groundMiddenNum = (int) (grounChunkNum /2);
		//Debug.Log(groundMiddenNum);

        
		//地版中間那塊對齊畫面中央
		var initX = groundMiddenNum * -groundDistance;
		for (int i = 0; i < grounChunkNum;i++ )
        {
			//var instance = Instantiate(obstaic[0],new Vector2((i*groundDistance),0*1),transform.rotation);			
			var instance = Instantiate(obstaic[0]);
            instance.transform.position = new Vector2((i*groundDistance) + initX  ,transform.position.y);
			instance.transform.parent = worldCenter.transform;
            itemQueue.Enqueue(instance);
        }

		
	
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void distanceUpdate(float playerX)
    {        
        
		//往右
		//if(referrenceTransform.transform.position.x-itemQueue.Peek().transform.position.x>=groundDistance)
		if(referrenceTransform.transform.position.x-itemQueue.ToArray()[groundMiddenNum].transform.position.x>=2f)
        {
            GameObject cube = itemQueue.Dequeue();
            cube.transform.position = new Vector3(itemQueue.ToArray()[itemQueue.Count - 1].transform.position.x+groundDistance, cube.transform.transform.position.y, 0);
            itemQueue.Enqueue(cube);
        }

    }
}
