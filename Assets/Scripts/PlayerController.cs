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

    float _yAngle = 0.0f;

    void Update() //1frame�� ȣ�� 
    {
        // _yAngle += Time.deltaTime * 100.0f;

        // 1. ���� �׳� �ִ� ��� : ���� ȸ���� �����Ͽ� ȸ��
        // transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);
        // =  transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));

        //2. ȸ���ϴ� ���� �� �࿡ �־��ִ� ���(+= delta) : Ư�� ���� �������� �󸶸�ŭ ȸ��
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));



        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward); //Word �������� Ư�� ������ �ٶ�
            //�� �� �ε巴�� ó�� Slerp(Quaternion a,Quaternion b,float t)
            //                             : a:���� ��ġ, b: ������ 0~1 :a�� �����~b�� �����
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);

            //�̵��� ���ڿ�������
            // -> Slerp�� 0.2f�� 2�ù��� ������ �Ĵٺ��� ��Ȳ���� ������ ���⶧���� �ȹٷ� ������ ���� �ʰ� ���� ������ �̵�
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed); //ȸ�� �� ���� �ٶ󺸹Ƿ� ��� �� �������� ����

            //rotation�� �Բ� �̵��Լ��� �� ��쿡�� �̷� �κ��� ���������
            //�ٶ󺸴� ����� ������� word ��ǥ�� ���� ���ϱ� �Ʒ��� ���� ������ -> �ٶ󺸴� ������ ���� ��� ���� �ٶ� �������� ����
            transform.position += Vector3.forward * Time.deltaTime * _speed;

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
