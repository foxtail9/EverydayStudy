using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Q2.[�������� 2]
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

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

        //Q2.[�������� 2] - Dictionary����
        CreatePool("Monster", prefab, poolSize);

        DictionaryGet("Monster"); //Dictionary pools ""Ű������ ��Ȱ��ȭ�� gbj Ȱ��ȭ
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

    public void CreatePool(string key,GameObject prefab,int poolsiz)
    {
        pools[key] = new List<GameObject>();
        for (int i = 0; i < poolsiz; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject DictionaryGet(string key)
    {
        if (pools.ContainsKey(key))
        {
            foreach (GameObject obj in pools[key])
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        return null;
    }

    public void DictionaryRelease(string key, GameObject obj)
    {
        if (pools.ContainsKey(key))
        {
            obj.SetActive(false);
        }
    }
}
