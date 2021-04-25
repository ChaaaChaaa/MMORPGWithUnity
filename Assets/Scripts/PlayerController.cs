using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //c# exception speed�� unity�� ǥ��
    float _speed = 10.0f;
    void Start()
    {
        //�Ǽ��� �ٸ������� �̺�Ʈ ȣ��� ����ϵ���
        Managers.Input.KeyAction -= OnKeyBoard;
        //Ű���尡 �������� �Լ� ���� ��û
        Managers.Input.KeyAction += OnKeyBoard;
    }

    void Update() //1frame�� ȣ�� 
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
