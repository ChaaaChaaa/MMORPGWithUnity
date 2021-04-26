using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] //c# exception speed�� unity�� ǥ��
    float _speed = 10.0f;

    Vector3 destinationPosition;
    bool moveToDestination = false; 

    void Start()
    {
        //�Ǽ��� �ٸ������� �̺�Ʈ ȣ��� ����ϵ���
        Managers.Input.KeyAction -= OnKeyBoard;
        //Ű���尡 �������� �Լ� ���� ��û
        Managers.Input.KeyAction += OnKeyBoard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    float wait_run_ratio = 0;

    void Update() //1frame�� ȣ�� 
    {
        if (moveToDestination)
        {
            Vector3 direction = destinationPosition - transform.position;
            if(direction.magnitude < 0.0001f) //float�� ���⶧���� ��Ȯ�ϰ� 0�� �ȳ���
            {
                moveToDestination = false;
            }
            else
            {
                //direction�� ���⺤������ 1�� �ٲ��� �ʾƼ� normalized�� �ٲ� �� �ӵ�*�ð� �� ���༭ �Ÿ��� �̵��Ѵ�.
                //�������� ���� ��� ��� �ٽ� �ڷΰ��� ������ �Դٰ��� ĳ���Ͱ� �����̴� ���� ����
                // transform.position += direction.normalized * _speed * Time.deltaTime;

                //�ذ��� : _speed * Time.deltaTime �� �̵� ���� ĳ���Ͱ� �̵��� ���� �Ÿ����� ����� �Ѵ�.
                float moveDistance = Mathf.Clamp(_speed * Time.deltaTime, 0, direction.magnitude);
                transform.position += direction.normalized * moveDistance;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),10*Time.deltaTime);
                transform.LookAt(destinationPosition); //�̵��� ���� �ٶ󺸸鼭 �޸� �� �ֵ��� ����
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

        moveToDestination = false; //Ű���带 �����°� ���콺�� ������ �̵� ����� �ƴϹǷ�
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
            destinationPosition = hit.point; //vector3�� world �������� �����ġ���� ��ǥ ��Ÿ��
            moveToDestination = true;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
