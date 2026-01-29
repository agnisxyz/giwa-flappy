using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Kuş bu görünmez alandan çıktığı anda skoru artır
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore();
        }
    }
}