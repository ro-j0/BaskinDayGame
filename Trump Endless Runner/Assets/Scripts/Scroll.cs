using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed, limit;
    void Update()
    {
        if(transform.position.x > limit){
            transform.position += new Vector3(-speed,0,0);
        }
        else{
            transform.position = new Vector3(1,transform.position.y,transform.position.z);
        }
    }
}
