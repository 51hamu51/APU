using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    public GameObject backG1;
    public GameObject backG2;

    private Vector3 startPos;
    private Vector3 prePos;
    private bool isG1Head;
    void Start()
    {
        isG1Head = true;
        startPos = backG1.transform.position;
        prePos = backG2.transform.position;
    }

    void Update()
    {
        backG1.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        backG2.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (isG1Head)
        {
            if (backG2.transform.position.x <= startPos.x)
            {
                backG1.transform.position = prePos;
                isG1Head = false;
            }
        }
        else
        {
            if (backG1.transform.position.x <= startPos.x)
            {
                backG2.transform.position = prePos;
                isG1Head = true;
            }
        }
    }
}
