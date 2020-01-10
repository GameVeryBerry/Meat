using UnityEngine;


//using UnityEngine.SceneManagement;
public class MapLernMoveController : MonoBehaviour
{
    // 目標地点のオブジェクト
    [SerializeField]
    private GameObject goalPoint;

    Vector3 move_Position;
    Vector3 toGoPoint;

    float moveSpeed = 0.01f; //移動速度

    void Start()
    {
        move_Position = this.transform.position;    //移動させたいオブジェクトの座標
    }

    void Update()
    {
        //move_Position.z -= moveSpeed;
        float offset_x = toGoPoint.x - move_Position.x;
        float offset_z = toGoPoint.z - move_Position.z;
        float rad = Mathf.Atan2(offset_z, offset_x);

        float vel_x = moveSpeed * Mathf.Cos(rad);
        float vel_z = moveSpeed * Mathf.Sin(rad);

        move_Position.x += vel_x;
        move_Position.z += vel_z;
        this.transform.position = move_Position;
    }

    public void Init(GameObject goal)
    {
        toGoPoint = goal.transform.position;   //目的地に設置したオブジェクトの座標
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MapLernExitPoint")
        {
            Destroy(this.gameObject);

        }
    }
}