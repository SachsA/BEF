using UnityEngine;

public class FadeInImage : MonoBehaviour
{
    public float delay = 0.0f;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;

    private float startTime;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        startTime = Time.time + delay;
    }

    private void Update()
    {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
    }
}
