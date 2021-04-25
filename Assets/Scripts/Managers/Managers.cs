using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //���ϼ� ����
    public static Managers Instance { // ������ �Ŵ����� ����´�
        get
        {
            init();
            return s_instance;
        }
    }
  
    // Start is called before the first frame update
    void Start()
    //�ƹ��� ������ Managers Instance�� Start()ȣ���ص� ������ ������ ����Ǵ� ���� managers ������ �ν���
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {

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
