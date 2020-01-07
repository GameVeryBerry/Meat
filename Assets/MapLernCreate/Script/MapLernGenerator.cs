using UnityEngine;

public class MapLernGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startPoint=null;
    [SerializeField]
    private GameObject generator=null;
    [SerializeField]
    private GameObject goal=null;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame



    void FixedUpdate()
    {
        // ジェネレーターの座標の代入
        float x = startPoint.gameObject.transform.position.x;
        float y = startPoint.gameObject.transform.position.y;
        float z = startPoint.gameObject.transform.position.z;
        // レーンの動く部分の生成
        GameObject obj = Instantiate(generator, new Vector3(x, y, z), Quaternion.identity);
        obj.GetComponent<MapLernMoveController>().Init(goal);
    }

}
