using UnityEngine;

public class Trigger : MonoBehaviour
{
    [HideInInspector] public bool isLevelComplete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Level Complete gameobject
            if (gameObject.CompareTag("Complete") && !isLevelComplete)
            {
                isLevelComplete = true;
                int currentLevel = collision.GetComponent<PlayerMovement>().currentlevel;
                int savedLevel = collision.GetComponent<PlayerMovement>().savedlevel;
                collision.GetComponent<PlayerMovement>().enabled = false;
                collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.GetComponent<SpriteRenderer>().enabled = false;
                if (currentLevel == savedLevel)
                    PlayerPrefasManager.Instance.Level = 1;
                Managers.Instance.uiManager.LevelComplete();
            }

            //Falling Object hit the player
            if (gameObject.CompareTag("Rock"))
                PlayerHealth.Instance.SetDamage(5);

            if (gameObject.CompareTag("Tiyanak"))
            {
                Managers.Instance.audioManager.Play("TiyanakIyak");
                gameObject.SetActive(false);
            }
        }

        //gameObject.SetActive(false);
        if (collision.CompareTag("Dead Zone"))
            BasicObjectPooling.Instance.Queue(gameObject, eObjectPoolType.Rock);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Dead Zone"))
            {
                PlayerHealth.Instance.SetDamage(PlayerHealth.Instance.SetHealth(), true);
            }

            if (CompareTag("FallGround"))
            {
                PlayerHealth.Instance.SetDamage(10);
            }
        }
        
    }
}
