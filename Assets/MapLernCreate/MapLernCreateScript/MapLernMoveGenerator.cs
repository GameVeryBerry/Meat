//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MapLernMoveGenerator : MonoBehaviour
{
    //public GameObject MapLernMovePrefab;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //prefab = (GameObject)Resources.Load("Resources/MapLernMovePrefab");
    }

    // Update is called once per frame
    void Update()
    {
        // レーンの生産
        Instantiate(prefab, this.transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MapLernExitPoint")
        {
            Destroy(this); 
        }
    }
}
