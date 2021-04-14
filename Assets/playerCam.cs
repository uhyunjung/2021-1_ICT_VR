using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;

    void start()
    {
        player = (GameObject)Resources.Load("player", typeof(GameObject));
    }

    
}
