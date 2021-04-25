using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //c# exception speed�� unity�� ǥ��
    float _speed = 10.0f;
    void Start()
    {

    }

    /*
     * GameObject(Player)
     *   - TransForm
     *   - PlayerController (*)
     */

    void Update() //1frame�� ȣ�� 
    {
        //  Time.deltaTime ���� frame - ���� frame �� ���� : �ʹ� �������� ����
        // transform ���� �����¿�
        if (Input.GetKey(KeyCode.W))
        { 
            // transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed; //�Ÿ� �ӵ� �ð�, �ӵ��� 1 frame ���̿��� �ʹ� ����
            //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed); // global ��ǥ += �۷ι���ȯ��(���� ��ǥ)
            transform.Translate(Vector3.forward * Time.deltaTime * _speed); //�ڱⰡ �ٶ󺸴� ���÷� ����ϹǷ� ������ǥ�� �־ ���� 
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
