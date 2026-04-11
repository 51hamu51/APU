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
        if (BackGroundManager.Instance.isPlayerDead)
        {
            return;
        }

        transform.localPosition += Vector3.left * speed * Time.deltaTime;

        if (transform.localPosition.x <= -700)
        {
            Destroy(gameObject);
        }
    }
}
