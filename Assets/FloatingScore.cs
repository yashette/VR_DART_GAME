using TMPro;
using UnityEngine;

public class FloatingScore : MonoBehaviour
{
    public float lifetime = 1.5f;
    public float floatSpeed = 1f;

    public TextMeshProUGUI scoreText;
    private float timer;

    void Start()
    {
    }

    public void SetScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= lifetime)
            Destroy(gameObject);
    }
}
