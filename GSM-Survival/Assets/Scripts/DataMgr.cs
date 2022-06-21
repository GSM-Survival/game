using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Sun, Baek
}

public class DataMgr : MonoBehaviour
{
    public static DataMgr instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }
    public Character currentCharacter;

    // Update is called once per frame
    void Update()
    {

    }
}
