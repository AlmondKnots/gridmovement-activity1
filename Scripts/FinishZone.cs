using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public Transform player;
    public float winRadius = 1f;
    public GameObject winPanel;

    private bool hasWon = false;

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void Update()
    {
        if (player == null || hasWon) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= winRadius)
        {
            hasWon = true;

            if (winPanel != null)
                winPanel.SetActive(true);

            PlayerController controller = player.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.DisableMovement();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, winRadius);
    }
}