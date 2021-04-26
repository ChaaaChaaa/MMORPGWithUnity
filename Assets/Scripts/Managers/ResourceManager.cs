using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{ 
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);
        //Object�� ���� ��ͷ� ���⶧���� Object �ȿ��ִ� �Լ��� ȣ���ϵ��� �ٿ�����.
    }

    public void Destroy(GameObject gameObject)
    {
        if(gameObject == null)
        {
            return;
        }

        Object.Destroy(gameObject);
    }
}