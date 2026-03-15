using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JumpIcon : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI nextDisplayText;
    void Start()
    {
        displayText.text = "A";
        nextDisplayText.text = "A";
    }

    void Update()
    {

    }

    public void ChangeDisplay(int keyNum)
    {
        if (keyNum >= 0 && keyNum < 26)
        {
            char letter = (char)('A' + keyNum);
            displayText.text = letter.ToString();
        }
    }
    public void ChangeNextDisplay(int keyNum)
    {
        if (keyNum >= 0 && keyNum < 26)
        {
            char letter = (char)('A' + keyNum);
            nextDisplayText.text = letter.ToString();
        }
    }
}
