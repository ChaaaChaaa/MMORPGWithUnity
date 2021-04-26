using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //c# exception speed가 unity에 표시
    float _speed = 10.0f;

    Vector3 destinationPosition;
    bool moveToDestination = false; 

    void Start()
    {
        //실수로 다른곳에서 이벤트 호출시 취소하도록
        Managers.Input.KeyAction -= OnKeyBoard;
        //키보드가 눌렸을때 함수 실행 요청
        Managers.Input.KeyAction += OnKeyBoard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    float wait_run_ratio = 0;

    void Update() //1frame당 호출 
    {
        if (moveToDestination)
        {
            Vector3 direction = destinationPosition - transform.position;
            if(direction.magnitude < 0.0001f) //float로 빼기때문에 정확하게 0이 안나옴
            {
                moveToDestination = false;
            }
            else
            {
                //direction가 방향벡터지만 1로 바꾸지 않아서 normalized로 바꾼 후 속도*시간 을 해줘서 거리를 이동한다.
                //목적지에 조금 벗어날 경우 다시 뒤로가는 문제로 왔다갔다 캐릭터가 움직이는 버그 있음
                // transform.position += direction.normalized * _speed * Time.deltaTime;

                //해결점 : _speed * Time.deltaTime 이 이동 값이 캐릭터가 이동할 남은 거리보다 적어야 한다.
                float moveDistance = Mathf.Clamp(_speed * Time.deltaTime, 0, direction.magnitude);
                transform.position += direction.normalized * moveDistance;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),10*Time.deltaTime);
                transform.LookAt(destinationPosition); //이동할 곳을 바라보면서 달릴 수 있도록 설정
            }
        }

        if (moveToDestination)
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
            Animator animator = GetComponent<Animator>();
            animator.SetFloat("wait_run_ratio", wait_run_ratio); //run
            animator.Play("WAIT_RUN");
        }
        else
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
            Animator animator = GetComponent<Animator>();
            animator.SetFloat("wait_run_ratio", wait_run_ratio);
            animator.Play("WAIT_RUN");
        }
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

        moveToDestination = false; //키보드를 누르는건 마우스로 목적지 이동 방식이 아니므로
    }

    void OnMouseClicked(Define.MouseEvent mouseEvent)
    {
        //if(mouseEvent != Define.MouseEvent.Click)
        //{
        //    return;
        //}

        Debug.Log("OnMouseClicked");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            destinationPosition = hit.point; //vector3를 world 기준으로 어느위치인지 좌표 나타냄
            moveToDestination = true;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
