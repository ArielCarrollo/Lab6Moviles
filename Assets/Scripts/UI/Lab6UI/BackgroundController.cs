using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed = 100f;
    public float resetPositionX = -10f; 
    public float startPositionX = 0f; 

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        if (rectTransform.anchoredPosition.x <= resetPositionX)
        {
            rectTransform.anchoredPosition = new Vector2(startPositionX, rectTransform.anchoredPosition.y);
        }
    }
}
