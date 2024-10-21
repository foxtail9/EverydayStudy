using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    //[구현사항 1]
    private static QuestManager _instance;

    //[구현사항 2]
    public static QuestManager Instance
    {
        get 
        { 
            if( _instance == null)
            {
                _instance = new QuestManager();
            }
            return _instance;
        }
    }

    //[구현사항 3]
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
}
