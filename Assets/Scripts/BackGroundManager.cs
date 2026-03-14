using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    public Image[] backGs = new Image[3];

    private Vector3 startPos;
    private Vector3 prePos;
    public int headNum;
    [SerializeField] private Sprite[] backSprites;
    public int[] spriteNums = new int[3];
    public KeyCode jumpKey;
    public JumpIcon jumpIcon;

    void Start()
    {
        jumpKey = KeyCode.UpArrow;
        headNum = 0;
        startPos = backGs[1].transform.position;
        prePos = backGs[2].transform.position;

        backGs[0].sprite = backSprites[0];
        spriteNums[0] = 0;
        backGs[1].sprite = backSprites[0];
        spriteNums[1] = 0;
        backGs[2].sprite = backSprites[0];
        spriteNums[2] = 0;
    }

    void Update()
    {
        for (int i = 0; i < backGs.Length; i++)
        {
            backGs[i].transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        }

        if (backGs[(headNum + 2) % 3].transform.position.x <= startPos.x)
        {
            backGs[headNum].transform.position = prePos;
            headNum = (headNum + 1) % 3;
            EnvironmentChange();
        }
    }

    /// <summary>
    /// 背景画像変更
    /// </summary>
    private void EnvironmentChange()
    {
        int rand = Random.Range(0, 4);
        backGs[(headNum + 2) % 3].sprite = backSprites[rand];
        spriteNums[(headNum + 2) % 3] = rand;
        KeyChange();
    }

    /// <summary>
    /// 操作方法の変更
    /// </summary>
    private void KeyChange()
    {
        switch (spriteNums[(headNum + 1) % 3])
        {
            case 0:
                jumpKey = KeyCode.UpArrow;
                break;

            case 1:
                jumpKey = KeyCode.LeftArrow;
                break;

            case 2:
                jumpKey = KeyCode.DownArrow;
                break;

            case 3:
                jumpKey = KeyCode.RightArrow;
                break;

        }
        jumpIcon.RotateIcon(jumpKey);
    }
}


//spriteNums[(headNum + 1) % 3]が現在のプレイヤーが見えている景色
