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

    float _yAngle = 0.0f;

    void Update() //1frame당 호출 
    {
        // _yAngle += Time.deltaTime * 100.0f;

        // 1. 값을 그냥 넣는 방식 : 절대 회전값 지정하여 회전
        // transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);
        // =  transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));

        //2. 회전하는 값을 각 축에 넣어주는 방식(+= delta) : 특정 축을 기준으로 얼마만큼 회전
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));



        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward); //Word 기준으로 특정 방향을 바라봄
            //좀 더 부드럽게 처리 Slerp(Quaternion a,Quaternion b,float t)
            //                             : a:현재 위치, b: 목적지 0~1 :a에 가까움~b에 가까움
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);

            //이동이 부자연스러움
            // -> Slerp로 0.2f시 2시방향 정도를 쳐다보능 상황에서 앞으로 가기때문에 똑바로 앞으로 가지 않고 조금 옆으로 이동
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed); //회전 후 앞을 바라보므로 모두 앞 방향으로 설정

            //rotation과 함께 이동함수를 쓸 경우에는 이런 부분을 맞춰줘야함
            //바라보는 방향과 상관없이 word 좌표로 앞을 보니까 아래와 같이 변경함 -> 바라보는 방향이 관련 없어서 실제 바라볼 뱡향으로 변경
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
