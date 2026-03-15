using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = BackGroundManager.Instance.GetScrollSpeed();
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -700)
        {
            Destroy(gameObject);
        }
    }
}
