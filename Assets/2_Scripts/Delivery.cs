using System.Runtime.CompilerServices;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(0.9867735f, 1, 0, 1);
    SpriteRenderer spriteRenderer;
    public AudioSource pickupsound;
    public AudioSource deliverysound;
    bool hasChicken = false;
    [SerializeField] float destoryChicken = 0.5f;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pickupsound.Stop();
        deliverysound.Stop();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && !hasChicken)
        {
            Debug.Log("치킨 픽업");
            hasChicken = true;
            Destroy(collision.gameObject, destoryChicken);
            spriteRenderer.color = hasChickenColor;
            pickupsound.Play();

            // Blocked 오브젝트 모두 제거
            GameObject[] blockedObjects = GameObject.FindGameObjectsWithTag("Blocked");
            foreach (GameObject obj in blockedObjects)
            {
                Destroy(obj);
            }
        }
        else if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("치킨 배달!");
            hasChicken = false;
            spriteRenderer.color = noChickenColor;
            deliverysound.Play();
            GameObject[] blockedObjects = GameObject.FindGameObjectsWithTag("ChickenBanana");
            foreach (GameObject obj in blockedObjects)
            {
                Destroy(obj);
            }
        }
    }
}
