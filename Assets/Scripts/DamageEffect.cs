using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] private float deleteTime;

    [SerializeField] private Sprite damage;
    [SerializeField] private Sprite normal;
    [SerializeField] private Image image;
    [SerializeField] private GameObject damagePanel;

    void Start()
    {
        EffectOff();
    }

    public void EffectOff()
    {
        image.sprite = normal;
        damagePanel.SetActive(false);
    }

    public void EffectOn()
    {
        image.sprite = damage;
        damagePanel.SetActive(true);
    }

    public void Damage()
    {
        EffectOn();
        Invoke(nameof(EffectOff), deleteTime);
    }
}