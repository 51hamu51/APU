using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Heart : MonoBehaviour
{
    [SerializeField] private Image heartImage;
    void Start()
    {

    }

    void Update()
    {

    }

    public void FadeOut()
    {
        Sequence seq = DOTween.Sequence();

        seq.Join(heartImage.transform.DOScale(0f, 0.5f));
        seq.Join(heartImage.DOFade(0f, 0.5f));

        seq.OnComplete(() => this.gameObject.SetActive(false));
    }
}
