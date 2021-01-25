using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    void Start()
    {
        for(int i = 0; i<101; i++){
            if(i == 100){
                self.SetActive(false);
            }
        }
    }
}
