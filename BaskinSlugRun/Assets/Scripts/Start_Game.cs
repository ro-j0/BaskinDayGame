using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    public GameObject S;
    
    private void OnMouseDown() 
    {
        Debug.Log("Button clcik");
        S.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnMouseUp() {
        Debug.Log("Button release");
        S.GetComponent<SpriteRenderer>().enabled = true;
        SceneManager.LoadScene("Summer");
    }
}
