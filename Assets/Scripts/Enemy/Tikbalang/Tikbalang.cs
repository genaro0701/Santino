using UnityEngine;

public class Tikbalang : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rb;
    [SerializeField] private float m_Speed = 10f;

    private Transform m_Player;
    private bool isFlipped = true;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (m_Player.localPosition.x > transform.position.x)
            transform.position = new(m_Player.localPosition.x + 18f, transform.position.y);
    }

    public void Run()
    {
        m_Rb.velocity = Vector2.right * m_Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
            Managers.Instance.uiManager.GameOver();
        else if (collision.CompareTag("Player"))
        {
            int currentLevel = collision.GetComponent<PlayerMovement>().currentlevel;
            int savedLevel = collision.GetComponent<PlayerMovement>().savedlevel;
            collision.GetComponent<PlayerMovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.GetComponent<SpriteRenderer>().enabled = false;
            if (currentLevel == savedLevel)
                PlayerPrefasManager.Instance.Level = 1;
            Managers.Instance.uiManager.LevelComplete();
            FindObjectOfType<ButtonManager>().Objective(0);
        }
    }

    public void LookAt()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > m_Player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < m_Player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
