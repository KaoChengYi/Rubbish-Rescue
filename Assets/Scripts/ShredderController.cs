using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShredderController : MonoBehaviour
{
    public GameObject shreddedPiecePrefab; 
    public Transform shredderOutputPoint; 
    public Vector2 outputAreaSize = new Vector2(2f, 1f); 
    public float shreddingSpeed = 0.5f; 
    public float flutteringForce = 0.2f; 
    public int numberOfPieces = 4; 
    public float rotationSpeed = 50f; 
    public Button uiButton; 

    private int totalPaperBags; 
    private int shreddedPaperBags;

    private void Start()
    {
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(false);
        }

        totalPaperBags = GameObject.FindGameObjectsWithTag("PaperBag").Length;
        shreddedPaperBags = 0; // Reset the counter
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PaperBag"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ShredObject());
            shreddedPaperBags++;

            if (shreddedPaperBags >= totalPaperBags)
            {
                ShowButton();
            }
        }
    }

    private IEnumerator ShredObject()
    {
        for (int i = 0; i < numberOfPieces; i++)
        {
            float randomX = Random.Range(-outputAreaSize.x / 2f, outputAreaSize.x / 2f);
            float randomY = Random.Range(-outputAreaSize.y / 2f, outputAreaSize.y / 2f);

            Vector3 spawnPosition = shredderOutputPoint.position + new Vector3(randomX, randomY, 0);

            GameObject shreddedPiece = Instantiate(shreddedPiecePrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = shreddedPiece.AddComponent<Rigidbody2D>();
            rb.gravityScale = shreddingSpeed; // Control falling speed

            rb.angularVelocity = Random.Range(-rotationSpeed, rotationSpeed);

            Vector2 flutterForce = new Vector2(Random.Range(-flutteringForce, flutteringForce), 0);
            rb.AddForce(flutterForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }

    private void ShowButton()
    {
        if (uiButton != null)
        {
            uiButton.gameObject.SetActive(true);
        }
    }
}
