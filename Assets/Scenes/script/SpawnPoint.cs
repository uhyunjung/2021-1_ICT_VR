using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] spawnStartingLocations;
    public GameObject[] spawnEndingLocations;

    public GameObject player;
    public GameObject scoreZone;
    public bool isStart = false;  //player가 시작했는지 확인 -> ending point에 도착하면 false로 바꿈
    public int spawnEnding;
    
    private Vector3 respawnStartLocation;
    private Vector3 respawnEndLocation;

    void Awake()
    {
        spawnStartingLocations = GameObject.FindGameObjectsWithTag("SpawnStartingPoints");
        spawnEndingLocations = GameObject.FindGameObjectsWithTag("SpawnEndingPoints");
    }
    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject)Resources.Load("player", typeof(GameObject));
        respawnStartLocation = player.transform.position;
        SpawnPlayer();
        if (isStart)
        {
            scoreZone = (GameObject)Resources.Load("FinishZone", typeof(GameObject));
            respawnEndLocation = scoreZone.transform.position;
            SpawnEndingPoint();  //activate ending point
        }
    }
    
    private void SpawnPlayer() //spawn포인트에 생성하기
    {
        isStart = true;
        int spawn = Random.Range(0, spawnStartingLocations.Length);
        Debug.Log("spawn player");
        GameObject.Instantiate(player, spawnStartingLocations[spawn].transform.position, new Quaternion(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0));
        GameObject.Find("GameManager").GetComponent<GameManager>().startPoint = spawnStartingLocations[spawn].transform.position;
    }

    private void SpawnEndingPoint() //goal point 생성하기
    {
        spawnEnding = Random.Range(0, spawnEndingLocations.Length);
        GameObject.Instantiate(scoreZone, spawnEndingLocations[spawnEnding].transform.position, Quaternion.identity);
        GameObject.Find("GameManager").GetComponent<GameManager>().goalPoint = spawnEndingLocations[spawnEnding].transform.position;
    }
}
