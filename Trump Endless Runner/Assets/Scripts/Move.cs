using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    // Update is called once per frame
    private void Start() {
        Destroy(gameObject,5);
    }
    void Update()
    {
        transform.position += new Vector3(Speed,0f,0f); 
    }
}
