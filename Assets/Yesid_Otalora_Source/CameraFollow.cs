using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5;
    private Vector3 offset;


    void Start()
    {
        offset = player.position - transform.position;
    }


    void LateUpdate()
    {
        if (player)
        {
            transform.position = player.position - offset;
        }
    }
}
