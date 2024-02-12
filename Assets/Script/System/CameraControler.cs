using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private GameObject player;

    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}
