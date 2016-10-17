using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] groundPrefabs;  //the ground prefabs
    public float spawnHorizon;          //how far away objects spawn
    public float groundWidth;           //the width of the ground prefab
    public float heightOffset;
    public float depthOffset;

    public GameObject player;           //the player, used for ground geenration
    public Transform spawnerParent;     //the object spawning the ground

    private float nextGroundOffset = 0; //the offset for spawning the ground

	// Update is called once per frame
	void Update () {

        float forwardPosition = player.transform.position.x; //the position of the player

        while (forwardPosition + spawnHorizon > nextGroundOffset)
        {
            int randomGroundIndex = Random.Range(0, groundPrefabs.Length);  //picks a ground prefab to spawn at random

            GameObject ground = groundPrefabs[randomGroundIndex];   //the ground prefab to be spawned

            Vector3 nextGroundPosition = nextGroundOffset * Vector3.right;  //the place for the ground to be spawned

            GameObject newGroundObject = Instantiate(ground, nextGroundPosition + new Vector3(0,heightOffset,depthOffset), Quaternion.identity) as GameObject;    //

            newGroundObject.transform.parent = spawnerParent;

            nextGroundOffset += groundWidth; 
        }
	}
}
