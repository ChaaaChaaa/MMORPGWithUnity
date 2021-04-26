using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] //public �ΰ�ó�� unity�� ǥ�õǴ� ���
    Define.CameraMode cameraMode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 delta = new Vector3(0.0f, 6.0f, -5.0f); //Player�������� �󸶸�ŭ ������ �ִ°�

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
                transform.LookAt(player.transform);  //������ transform��  object�� ���Ѻ�����  rotation ���� ����
            }
        }
    }

    public void SetQuaterView(Vector3 inputDelta)
    {
        cameraMode = Define.CameraMode.QuarterView;
        delta = inputDelta;
    }
}
