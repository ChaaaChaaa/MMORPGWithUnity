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
     * 1.둘다 Collider가 있어야 한다.
     * 2. 둘 중 하나는 IsTrigger : On
     * 3. 둘 중 하나는 RigidBody가 있어야 한다.
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
        //Local <> World <> Viewport <> Screen (화면)

        //Screen 좌표 : 픽셀 좌표와 유사
        // Debug.Log(Input.mousePosition);

        //Viewport 좌표 : Screen 좌표와 비슷하지만 픽셀과 상관없이 화면 비율로 몇퍼센트 차지하는지 표현
        Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //특정 screen 좌표를 알았을때 World좌표를 어떻게 구해야 하는가

        /*
         *  if (Input.GetMouseButtonDown(0)) //마우스 눌렀을때만 check
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


          

        if (Input.GetMouseButtonDown(0)) //마우스 눌렀을때만 check
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            int mask = (1 << 8); //8번 layout에 위치한것만 raycasting에 걸리도록 함

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }

    }
}
