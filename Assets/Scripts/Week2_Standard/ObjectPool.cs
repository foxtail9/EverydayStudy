using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;
    public int countgameobject = 0;

    void Start()
    {
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

    }

    public GameObject Get()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public void Release(GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        obj.SetActive(false);
    }
}
