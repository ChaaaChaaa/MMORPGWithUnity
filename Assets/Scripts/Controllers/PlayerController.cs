using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Die,
        Moving,
        Wait,
        Channeling,
        Jumping,
        Falling
    }
    [SerializeField] //c# exception speed가 unity에 표시
    float _speed = 10.0f;

    Vector3 destinationPosition;

    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }
    PlayerState playerState = PlayerState.Wait;

    void UpdateMoving()
    {
        Vector3 direction = destinationPosition - transform.position;
        if (direction.magnitude < 0.0001f) //float로 빼기때문에 정확하게 0이 안나옴
        {
            playerState = PlayerState.Wait; //한state(moving) -> 다른 state(wait)로 넘어가는 상황
        }
        else
        {
            float moveDistance = Mathf.Clamp(_speed * Time.deltaTime, 0, direction.magnitude);
            transform.position += direction.normalized * moveDistance;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10 * Time.deltaTime);
            transform.LookAt(destinationPosition); //이동할 곳을 바라보면서 달릴 수 있도록 설정
        }
        //애니메이션
        Animator animator = GetComponent<Animator>();

        //현재 게임 상태에 대한 정보를 넘겨준다.
        animator.SetFloat("speed", _speed);
    }

    void UpdateWait()
    {       
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0);
    }

    void UpdateDie()
    {
        //아무것도 못함
    }



    void Update()
    {
        switch (playerState)
        {
            case PlayerState.Die:
                UpdateDie();
                break;

            case PlayerState.Moving:
                UpdateMoving();
                break;

            case PlayerState.Wait:
                UpdateWait();
                break;
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
    }

    void OnMouseClicked(Define.MouseEvent mouseEvent)
    {
        if (playerState == PlayerState.Die)
        {
            return;
        }

        Debug.Log("OnMouseClicked");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            destinationPosition = hit.point; //vector3를 world 기준으로 어느위치인지 좌표 나타냄
            playerState = PlayerState.Moving;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
