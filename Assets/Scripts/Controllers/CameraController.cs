using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] //public 인것처럼 unity에 표시되는 방식
    Define.CameraMode cameraMode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 delta = new Vector3(0.0f, 6.0f, -5.0f); //Player기준으로 얼마만큼 떨어져 있는가

    [SerializeField]
    GameObject player = null;

    void Start()
    {

    }

    void LateUpdate()
    {
        if (cameraMode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, delta, out hit, delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - player.transform.position).magnitude * 0.8f;
                transform.position = player.transform.position + delta.normalized * dist;
            }
            else
            {
                transform.position = player.transform.position + delta;
                transform.LookAt(player.transform);  //무조건 transform의  object를 지켜보도록  rotation 강제 설정
            }
        }
    }

    public void SetQuaterView(Vector3 inputDelta)
    {
        cameraMode = Define.CameraMode.QuarterView;
        delta = inputDelta;
    }
}
