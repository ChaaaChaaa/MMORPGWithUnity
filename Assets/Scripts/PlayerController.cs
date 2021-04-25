using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //c# exception speed가 unity에 표시
    float _speed = 10.0f;
    void Start()
    {
        //실수로 다른곳에서 이벤트 호출시 취소하도록
        Managers.Input.KeyAction -= OnKeyBoard;
        //키보드가 눌렸을때 함수 실행 요청
        Managers.Input.KeyAction += OnKeyBoard;
    }

    void Update() //1frame당 호출 
    {
        
    }

    void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
