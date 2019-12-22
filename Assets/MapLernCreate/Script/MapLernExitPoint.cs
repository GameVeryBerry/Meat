using UnityEngine;
//using UnityEngine.SceneManagement;

public class MapLernExitPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AAAAAAAAA");
        if (collision.gameObject.tag == "player")
        {
            // TODO : SceneManager.LoadScene("GameOver");
        }
    }
}
