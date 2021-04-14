using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move player 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.z += 0.1f;
            transform.position = playerPosition;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.z -= 0.1f;
            transform.position = playerPosition;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.x += 0.1f;
            transform.position = playerPosition;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.x -= 0.1f;
            transform.position = playerPosition;
        }
    }
}
