using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PaperStirring : MonoBehaviour
{
    [Header("Shredded Paper Settings")]
    public GameObject shreddedPaperPrefab;
    public GameObject mushyPaperPrefab;
    public Transform waterContainer;
    public int paperCount = 5;
    public Vector2 containerSize;

    [Header("Stirring Settings")]
    public float stirringSpeed = 1f;
    public float minRotationSpeed = 20f;
    public float maxRotationSpeed = 100f;
    public Button stirButton;
    public Button nextActionButton;
    private bool isStirring = false;
    private float stirringDuration = 5f;

    private void Start()
    {
        SpawnShreddedPaper();
        stirButton.onClick.AddListener(OnStirButtonPressed);
        nextActionButton.gameObject.SetActive(false);
    }

    private void SpawnShreddedPaper()
    {
        for (int i = 0; i < paperCount; i++)
        {
            float randomX = Random.Range(waterContainer.position.x - containerSize.x / 2, waterContainer.position.x + containerSize.x / 2);
            float randomY = Random.Range(waterContainer.position.y - containerSize.y / 2, waterContainer.position.y + containerSize.y / 2);
            GameObject shreddedPaper = Instantiate(shreddedPaperPrefab, new Vector3(randomX, randomY, -9), Quaternion.identity);
            shreddedPaper.tag = "ShreddedPaper";
            shreddedPaper.AddComponent<PaperRotation>().rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

            // Set a random initial rotation
            shreddedPaper.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        }
    }

    private void OnStirButtonPressed()
    {
        isStirring = true;
        StartCoroutine(StirShreddedPaper());
    }

    private IEnumerator StirShreddedPaper()
    {
        float elapsedTime = 0f;
        GameObject[] shreddedPapers = GameObject.FindGameObjectsWithTag("ShreddedPaper");

        while (elapsedTime < stirringDuration)
        {
            foreach (GameObject paper in shreddedPapers)
            {
                Vector2 direction = (Vector2)(paper.transform.position - waterContainer.position);
                direction = Quaternion.Euler(0, 0, stirringSpeed) * direction;
                paper.transform.position = new Vector3(waterContainer.position.x, waterContainer.position.y, -9) + (Vector3)direction;

                PaperRotation paperRotation = paper.GetComponent<PaperRotation>();
                if (paperRotation != null)
                {
                    paper.transform.Rotate(0, 0, paperRotation.rotationSpeed * Time.deltaTime);
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ChangeShreddedPaperToMushy(shreddedPapers);
    }

    private void ChangeShreddedPaperToMushy(GameObject[] shreddedPapers)
    {
        foreach (GameObject paper in shreddedPapers)
        {
            Vector3 position = paper.transform.position;
            Destroy(paper);
            Instantiate(mushyPaperPrefab, position, Quaternion.identity);
        }

        isStirring = false;
        nextActionButton.gameObject.SetActive(true);
    }
}

public class PaperRotation : MonoBehaviour
{
    public float rotationSpeed;
}
