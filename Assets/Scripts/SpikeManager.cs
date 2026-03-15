using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private Transform canvas;
    public float generateMinTime;
    public float generateMaxTime;
    private float targetTime;
    private float time;

    void Start()
    {
        targetTime = Random.Range(generateMinTime, generateMaxTime);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (targetTime <= time)
        {
            time = 0;
            Spawn();
            targetTime = Random.Range(generateMinTime, generateMaxTime);
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(spikePrefab, canvas);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(700, -180);
    }
}
