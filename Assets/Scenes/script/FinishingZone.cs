using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")  //player와 FinishingZone이 충돌하면 게임 끝
        {
            //소요시간 가져와야함
        }
    }
}
