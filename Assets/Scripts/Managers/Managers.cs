using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //���ϼ� ����,�̱��� ���
    static Managers Instance
    { // ������ �Ŵ����� ����´�, ������Ƽ ���
        get
        {
            init();
            return s_instance;
        }
    }

    InputManager inputManager = new InputManager();
    public static InputManager Input
    {
        get
        {
            return Instance.inputManager;
        }
    }

    // Start is called before the first frame update
    void Start()
    //�ƹ��� ������ Managers Instance�� Start()ȣ���ص� ������ ������ ����Ǵ� ���� managers ������ �ν���
    {
        init();
    }

    void Update()
    {
        inputManager.OnUpdate();
    }

    /*
     * Ȥ�ö� @Managers�� ���� ��� getInstacne�� Instance�� null�� ���·� ���´�.
     * ���Ŀ� �ڵ尡 �߰��� manager  �����ؼ� ���𤤰��� �Ϸ��� �ϸ� crash�� �߻��ϰ� �ȴ�.
     */
    static void init()
    {
        if (s_instance == null)
        {
            GameObject gameObject = GameObject.Find("@Managers");
            if (gameObject == null)
            {
                gameObject = new GameObject
                {
                    name = "@Managers"
                };
                gameObject.AddComponent<Managers>();
            }

            DontDestroyOnLoad(gameObject);
            s_instance = gameObject.GetComponent<Managers>();
        }

    }
}
