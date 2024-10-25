using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Monster;
    public int poolnum = 300;
    List<GameObject> pool = new List<GameObject>();
    //Q2.[구현사항 2]
    Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();


    public void Start()
    {
        //Q2.[List]
        MonsterPool(poolnum);
        //Q2.[Dictionary]
        MonsterPools("Monster", poolnum);
    }

    //Q2.[구현사항 1]
    public void MonsterPool(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject obj = Instantiate(Monster);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    //Q2.[구현사항 1] - Get
    public GameObject PoolGet()
    {
        foreach(GameObject obj in pool)
        {
            obj.SetActive(true);
            return obj;
        }
        return null;
    }
    //Q2.[구현사항 1] - Release
    public void PoolRelease()
    {
        foreach (GameObject obj in pool)
        {
            if (obj.activeInHierarchy)
            {
                obj.SetActive(false);
            }
        }
    }

    //Q2.[구현사항 2]
    public void MonsterPools(string poolKey, int num)
    {
        pools[poolKey] = new List<GameObject>();

        for (int i = 0; i < num; i++)
        {
            GameObject obj = Instantiate(Monster);
            obj.SetActive(false);
            pools[poolKey].Add(obj);
        }
    }
    //Q2.[구현사항 2] - Get
    public GameObject PoolsGet(string poolKey)
    {
        foreach (GameObject obj in pools[poolKey])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    //Q2.[구현사항 2] - Release
    public void PoolsRelease(string poolKey)
    {
        foreach (GameObject obj in pools[poolKey])
        {
            if (obj.activeInHierarchy)
            {
                obj.SetActive(false);
            }
        }
    }
}
