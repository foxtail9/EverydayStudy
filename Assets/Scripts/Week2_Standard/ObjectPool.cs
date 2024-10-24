using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Q2.[구현사항 2]
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;
    public int countgameobject = 0;

    void Start()
    {
        //Q2.[구현사항 1]
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

        //Q2.[구현사항 2] - Dictionary생성
        CreatePool("Monster", prefab, poolSize);

        DictionaryGet("Monster"); //Dictionary pools ""키값으로 비활성화된 gbj 활성화
    }
    //Q2.[구현사항 1] : get
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
    //Q2.[구현사항 1] : Release
    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }

    //Q2.[구현사항 2] : Dictionary키 할당하기
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
    //Q2.[구현사항 2] : Dictionary pools key값으로 찾아가 활성화
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
    //Q2.[구현사항 2] : Dictionary pools key값으로 찾아가 비활성화
    public void DictionaryRelease(string key, GameObject obj)
    {
        if (pools.ContainsKey(key))
        {
            obj.SetActive(false);
        }
    }
}
