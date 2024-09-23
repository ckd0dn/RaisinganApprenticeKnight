using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // �ش� ������Ʈ�� ������ �ִ� ���� ������Ʈ�� ã�Ƽ� ��ȯ�Ѵ�.
                instance = (T)FindAnyObjectByType(typeof(T));

                if (instance == null) // �ν��Ͻ��� ã�� ���� ���
                {
                    // ���ο� ���� ������Ʈ�� �����Ͽ� �ش� ������Ʈ�� �߰��Ѵ�.
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    // ������ ���� ������Ʈ���� �ش� ������Ʈ�� instance�� �����Ѵ�.
                    instance = obj.GetComponent<T>();

                }

                DontDestroyOnLoad(instance.gameObject); // �ν��Ͻ��� ���� ������Ʈ�� DontDestroyOnLoad�� ����
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // �ν��Ͻ��� ���� ������Ʈ�� �ı�
        }
    }

    // �Ŵ����� �����ϰ� ���� ��� ȣ��
    public void DestroyManager()
    {
        if (instance == this)
        {
            instance = null;
            Destroy(gameObject); // �ν��Ͻ��� ���� ������Ʈ�� �ı�
        }
    }
}