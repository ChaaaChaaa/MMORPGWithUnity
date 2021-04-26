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
        //Local <> World <> Viewport <> Screen (ȭ��)

        //Screen ��ǥ : �ȼ� ��ǥ�� ����
        // Debug.Log(Input.mousePosition);

        //Viewport ��ǥ : Screen ��ǥ�� ��������� �ȼ��� ������� ȭ�� ������ ���ۼ�Ʈ �����ϴ��� ǥ��
        Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Ư�� screen ��ǥ�� �˾����� World��ǥ�� ��� ���ؾ� �ϴ°�

        /*
         *  if (Input.GetMouseButtonDown(0)) //���콺 ���������� check
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 dir = mousePos - Camera.main.transform.position;
            dir = dir.normalized;

            Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }
         */


          

        if (Input.GetMouseButtonDown(0)) //���콺 ���������� check
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            int mask = (1 << 8); //8�� layout�� ��ġ�Ѱ͸� raycasting�� �ɸ����� ��

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }

    }
}
