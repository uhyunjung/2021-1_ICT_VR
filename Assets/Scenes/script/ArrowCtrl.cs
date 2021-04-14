using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ArrowCtrl : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = target.position - transform.position;
        vec.Normalize();
        Quaternion q = Quaternion.LookRotation(vec);
        transform.rotation = new Quaternion(q.x+90, q.y, q.z, q.w+90);  // x축 90도 회전 필요


        //transform.LookAt(target);
    }

    
}
