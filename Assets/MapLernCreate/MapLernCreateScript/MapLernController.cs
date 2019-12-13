//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MapLernController : MonoBehaviour
{
    public GameObject MapLernMoveController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0, 1f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MapLernExitPoint")
        {
            Destroy(this.gameObject);
        }
    }
}
