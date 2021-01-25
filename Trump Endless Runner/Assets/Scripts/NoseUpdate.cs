using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseUpdate : MonoBehaviour
{
    public int i;
    // Start is called before the first frame update
    public GameObject ach;

    bool cou = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        i = PLayerController.liecount;
        switch(i){
            case 1:
                transform.localScale = new Vector3(1.82f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.26f,transform.localPosition.y,transform.localPosition.z);
                break;
            case 2:
                transform.localScale = new Vector3(2.24f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.3f,transform.localPosition.y,transform.localPosition.z);
                break;
            case 3:
                transform.localScale = new Vector3(3.04f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.33f,transform.localPosition.y,transform.localPosition.z);
                break;
            case 4:
                transform.localScale = new Vector3(4.04f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.38f,transform.localPosition.y,transform.localPosition.z);
                break;
            case 5:
                transform.localScale = new Vector3(5.84f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.44f,transform.localPosition.y,transform.localPosition.z);
                break;
            case 6:
                transform.localScale = new Vector3(7.55f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.5f,transform.localPosition.y,transform.localPosition.z);
                break;
            case 7:
                transform.localScale = new Vector3(11.06f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.62f,transform.localPosition.y,transform.localPosition.z);
                break;
            case 8:
                transform.localScale = new Vector3(16f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.8f,transform.localPosition.y,transform.localPosition.z);
                ach.SetActive(true);
                cou = true;
                break;
            case 9:
                transform.localScale = new Vector3(16f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.8f,transform.localPosition.y,transform.localPosition.z);
                break;
            default:
                transform.localScale = new Vector3(0.83f,transform.localScale.y,transform.localScale.z);
                transform.localPosition = new Vector3(0.26f,transform.localPosition.y,transform.localPosition.z);
                break;
        }
 
    }

}