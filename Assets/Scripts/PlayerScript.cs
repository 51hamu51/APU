using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] dashSprites;
    private int dashNum;
    private float time;
    [SerializeField] private float dashInterval;

    void Start()
    {
        time = 0;
        dashNum = 0;
        image.sprite = dashSprites[dashNum];
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > dashInterval)
        {
            time = 0;
            dashNum++;
            if (dashNum == dashSprites.Length)
            {
                dashNum = 0;
            }
            image.sprite = dashSprites[dashNum];
        }
    }
}
