using UnityEngine;

public class MapLernGenerator: MonoBehaviour
{
    public GameObject Generator;
    public GameObject Gool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        GameObject obj= Instantiate(Generator, new Vector3(0.31f, 0.5f, 5.3f), Quaternion.identity);
        obj.GetComponent<MapLernMoveController>().Init(Gool);
    }
  
}
