using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Image playerImage;
    private float time;
    private Vector3 playerDefaultPos;
    public BackGroundManager backGroundManager;

    [Header("dash")]
    [SerializeField] private Sprite[] dashSprites;
    private int dashNum;
    [SerializeField] private float dashInterval;

    [Header("jump")]
    [SerializeField] private Sprite[] jumpSprites;
    private int jumpNum;
    [SerializeField] private float jumpInterval;
    private bool isJumping;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpGravity;
    private float yVelocity;



    void Start()
    {
        playerDefaultPos = transform.position;
        isJumping = false;
        time = 0;
        dashNum = 0;
        jumpNum = 0;
        playerImage.sprite = dashSprites[dashNum];
    }

    void Update()
    {
        time += Time.deltaTime;

        if (isJumping)
        {
            //ジャンプの上下移動
            yVelocity += jumpGravity * Time.deltaTime;
            transform.position += new Vector3(0, yVelocity * Time.deltaTime, 0);

            //モーションの切り替え
            if (transform.position.y <= playerDefaultPos.y)
            {
                isJumping = false;
                jumpNum = 0;
                dashNum = 0;
                playerImage.sprite = dashSprites[dashNum];
                transform.position = playerDefaultPos;
            }
            else if (time > jumpInterval)
            {
                time = 0;
                jumpNum++;
                if (jumpNum == jumpSprites.Length)
                {
                    isJumping = false;
                    jumpNum = 0;
                    dashNum = 0;
                    playerImage.sprite = dashSprites[dashNum];
                    transform.position = playerDefaultPos;
                }
                else
                {
                    playerImage.sprite = jumpSprites[jumpNum];

                }

            }

        }
        else
        {
            if (time > dashInterval)
            {
                time = 0;
                dashNum++;
                if (dashNum == dashSprites.Length)
                {
                    dashNum = 0;
                }
                playerImage.sprite = dashSprites[dashNum];
            }
        }

        if (Input.GetKeyDown(backGroundManager.jumpKey) && !isJumping)
        {
            isJumping = true;
            jumpNum = 0;
            playerImage.sprite = jumpSprites[jumpNum];
            yVelocity = jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Damage");
        }

    }
}
