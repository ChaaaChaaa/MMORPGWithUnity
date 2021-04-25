using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //c# exception speed가 unity에 표시
    float _speed = 10.0f;
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
        //  Time.deltaTime 지금 frame - 이전 frame 로 구함 : 너무 빠른것을 방지
        // transform 조정 상하좌우
        if (Input.GetKey(KeyCode.W))
        { 
            // transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed; //거리 속도 시간, 속도가 1 frame 당이여서 너무 빠름
            //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed); // global 좌표 += 글로벌변환기(로컬 좌표)
            transform.Translate(Vector3.forward * Time.deltaTime * _speed); //자기가 바라보는 로컬로 계산하므로 로컬좌표를 넣어도 가능 
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position -= new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed;
            //transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
            //transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed; ;
            //transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
        }
    }
}
