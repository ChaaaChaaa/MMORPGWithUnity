using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @{collision.gameObject.name} ! ");
    }

    /*
     * 1.�Ѵ� Collider�� �־�� �Ѵ�.
     * 2. �� �� �ϳ��� IsTrigger : On
     * 3. �� �� �ϳ��� RigidBody�� �־�� �Ѵ�.
     */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger! @{other.gameObject.name} ");
    }



    void Start()
    {        
    }
 
    void Update()
    {
        Vector3 look = transform.TransformDirection(Vector3.forward);
        // Debug.DrawRay(transform.position, Vector3.forward, Color.red);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.blue);

        RaycastHit hit;
        //if(Physics.Raycast(transform.position, Vector3.forward))
        if(Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
        {
            Debug.Log($"RayCast {hit.collider.gameObject.name}!");
            //Debug.Log("RayCast ! ");
        }
    }
}
