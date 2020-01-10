using UnityEngine;

public class MapLernGenerator : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject Generator;
    public GameObject Gool;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame



    void FixedUpdate()
    {
        float x = StartPoint.gameObject.transform.position.x;
        float y = StartPoint.gameObject.transform.position.y;
        float z = StartPoint.gameObject.transform.position.z;

        GameObject obj = Instantiate(Generator, new Vector3(x, y, z), Quaternion.identity);
        obj.GetComponent<MapLernMoveController>().Init(Gool);
    }

}
