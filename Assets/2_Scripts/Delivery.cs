using System.Runtime.CompilerServices;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(0.9867735f, 1, 0, 1);
    SpriteRenderer spriteRenderer;

    bool hasChicken = false;
    [SerializeField] float destoryChicken = 0.5f;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && !hasChicken)
        {
            Debug.Log("치킨픽업");
            hasChicken = true;
            Destroy(collision.gameObject, destoryChicken);
            spriteRenderer.color = hasChickenColor;
        }
        if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("치킨배달");
            hasChicken = false;
            spriteRenderer.color = noChickenColor;
        }
    }
}
