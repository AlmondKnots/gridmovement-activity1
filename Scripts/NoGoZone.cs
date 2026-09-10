using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZone : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public SpriteRenderer zoneRenderer;

    [Header("Thresholds")]
    public float warningRadius = 3f;
    public float dangerRadius = 1f;
    public float maxTimeInZone = 2f;

    [Header("Shake Settings")]
    public float shakeMagnitude = 0.08f;

    private Vector3 originalLocalPosition;
    private Color originalColor;
    private float timeInWarningZone = 0f;

    void Start()
    {
        originalLocalPosition = transform.localPosition;

        if (zoneRenderer != null)
            originalColor = zoneRenderer.color;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= dangerRadius)
        {
            RestartScene();
            return;
        }
        else if (distance <= warningRadius)
        {
            timeInWarningZone += Time.deltaTime;
            ShakeZone();

            if (zoneRenderer != null)
                zoneRenderer.color = Color.red;

            if (timeInWarningZone >= maxTimeInZone)
            {
                RestartScene();
            }
        }
        else
        {
            timeInWarningZone = 0f;
            transform.localPosition = originalLocalPosition;

            if (zoneRenderer != null)
                zoneRenderer.color = originalColor;
        }
    }

    void ShakeZone()
    {
        float offsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
        float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);

        transform.localPosition = originalLocalPosition + new Vector3(offsetX, offsetY, 0f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, warningRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dangerRadius);
    }
}