using UnityEngine;
using UnityEngine.UI;

public class JumpIcon : MonoBehaviour
{
    [SerializeField] private Image jumpIconImage;
    void Start()
    {
        jumpIconImage.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {

    }

    public void RotateIcon(KeyCode keyCode)
    {
        float angle = 0;

        switch (keyCode)
        {
            case KeyCode.UpArrow: angle = 0; break;
            case KeyCode.LeftArrow: angle = 90; break;
            case KeyCode.DownArrow: angle = 180; break;
            case KeyCode.RightArrow: angle = 270; break;
        }

        jumpIconImage.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
