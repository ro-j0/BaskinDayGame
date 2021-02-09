using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Transform Player;
    void FixedUpdate()
    {

        transform.position = Player.position;
    }

}
