using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    void Start()
    {
        
    }

    /*
     * GameObject(Player)
     *   - TransForm
     *   - PlayerController (*)
     */
 
    void Update() //1frame당 호출 
    {
        // transform 조정 상하좌우

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0.0f, 0.0f, 1.0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0.0f, 0.0f, 1.0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(1.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1.0f, 0.0f, 1.0f);
        }
    }
}
