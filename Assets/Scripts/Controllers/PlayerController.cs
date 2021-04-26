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
    [SerializeField] //c# exception speed�� unity�� ǥ��
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
        if (direction.magnitude < 0.0001f) //float�� ���⶧���� ��Ȯ�ϰ� 0�� �ȳ���
        {
            playerState = PlayerState.Wait; //��state(moving) -> �ٸ� state(wait)�� �Ѿ�� ��Ȳ
        }
        else
        {
            float moveDistance = Mathf.Clamp(_speed * Time.deltaTime, 0, direction.magnitude);
            transform.position += direction.normalized * moveDistance;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10 * Time.deltaTime);
            transform.LookAt(destinationPosition); //�̵��� ���� �ٶ󺸸鼭 �޸� �� �ֵ��� ����
        }
        //�ִϸ��̼�
        Animator animator = GetComponent<Animator>();

        //���� ���� ���¿� ���� ������ �Ѱ��ش�.
        animator.SetFloat("speed", _speed);
    }

    void UpdateWait()
    {       
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0);
    }

    void UpdateDie()
    {
        //�ƹ��͵� ����
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
            destinationPosition = hit.point; //vector3�� world �������� �����ġ���� ��ǥ ��Ÿ��
            playerState = PlayerState.Moving;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
