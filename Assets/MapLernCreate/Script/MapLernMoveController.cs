using UnityEngine;


//using UnityEngine.SceneManagement;
public class MapLernMoveController : MonoBehaviour
{
    // 目標地点のオブジェクト
    public GameObject goalPoint;

    Vector3 move_Position;
    Vector3 toGoPoint;

    float moveSpeed = 0.01f; //移動速度

    void Start()
    {
        move_Position = this.transform.position;    //移動させたいオブジェクトの座標
        //toGoPoint = goalPoint.transform.position;   //目的地に設置したオブジェクトの座標
    }

    void Update()
    {
        move_Position.z -= moveSpeed;
        this.transform.position = move_Position;
    }

    public void Init(GameObject gool)
    {
        toGoPoint = gool.transform.position;   //目的地に設置したオブジェクトの座標
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MapLernExitPoint")
        {
            Destroy(this.gameObject);
        }
    }
}