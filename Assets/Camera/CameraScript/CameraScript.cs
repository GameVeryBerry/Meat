using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //float sin;
    //bool sinState;
    //Quaternion qua;
    public GameObject player;

    //RayCast
    Ray ray;
    RaycastHit hit;
    int distance;
    
    // Start is called before the first frame update
    void Start()
    {
        distance = 100;
        //sin = 0;
        //sinState = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //時間で移動する
        //sin = Mathf.Sin(Time.time);

        //一度マイナスになったらその後は移動を二倍にする
        //if (sin < 0) sinState = true;

        //if (sinState) {
        //    qua = Quaternion.Euler(0, sin / 2, 0);
        //}else
        //{
        //    qua = Quaternion.Euler(0, sin / 4, 0);
        //}
        //transform.rotation = transform.rotation * qua;
        
        
    }
  
    //レンダラーが付いたオブジェクトが画面に入ると処理
    private void OnWillRenderObject()
    {
        //プレイヤーの判定が取れたら
        //if (Camera.current.tag == "GameCamera")
        {
            //プレイヤーの中心
            ray = new Ray(transform.position, player.transform.position - transform.position);
            Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);
            //直接rayがPlayerに当たったらRaycastの当たり判定結果をとる
            if (Physics.Raycast(ray, out hit, distance))
            {
                //タグ名の指定(のちにデストロイに変える)
                if (hit.collider.tag == "Player") Debug.Log("Hit");
            }
        }
    }
}