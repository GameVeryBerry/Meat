using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // Playerタグが当たったら場合
        if(other.CompareTag("Player"))
        {
            // シーン遷移
            SceneManager.LoadScene("ResultScene");
        }
    }

    private static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }
}
