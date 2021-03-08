using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//안쓸거임

public class SpawnPlayer : MonoBehaviour
{
    public GameObject spawnLocations;
    public GameObject player;
    private Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject)Resources.Load("player", typeof(GameObject));
        spawnLocations = GameObject.FindGameObjectWithTag("SpawnStartingPoints");
        respawnLocation = player.transform.position;
        SpawnCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnCharacter()
    {
        Debug.Log("Spawn Character");
        GameObject.Instantiate(player, spawnLocations.transform.position, Quaternion.identity);
    }
}
