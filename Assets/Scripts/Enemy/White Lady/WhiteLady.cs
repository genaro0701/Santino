using UnityEngine;

public class WhiteLady : MonoBehaviour
{
    [SerializeField] private Transform m_WhiteLady;
    [SerializeField] private Vector3 m_OffSet;
    [SerializeField] private float m_MoveSpeed = 10f;
    
    private Transform m_Player;
    private bool isFlipped = true;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        if (PlayerPrefasManager.Instance.Page > 0) transform.position = new Vector2 (m_Player.position.x + m_OffSet.x, m_Player.position.y + m_OffSet.y);
    }

    private void FixedUpdate()
    {
        //Santino Facing right
        if (m_Player.localRotation.y >= 0)
        {
            //sundan si santino
            if (transform.position.x < m_Player.position.x + m_OffSet.x)
                transform.Translate(Vector3.right * m_MoveSpeed * Time.deltaTime);
            else
                LookAtPlayer();

            //pumunta sa left side ni santino
            if (transform.position.x > m_Player.position.x + m_OffSet.x)
                transform.Translate(Vector3.left * m_MoveSpeed * Time.deltaTime);
        }

        //Santino Facing Left
        else if (m_Player.localRotation.y < 0)
        {
            //sundan si santino
            if (transform.position.x > m_Player.position.x - m_OffSet.x)
                transform.Translate(Vector3.left * m_MoveSpeed * Time.deltaTime);
            else
                LookAtPlayer();

            //pumunta sa right side ni santino
            if (transform.position.x < m_Player.position.x - m_OffSet.x)
                transform.Translate(Vector3.right * m_MoveSpeed * Time.deltaTime);
        }

        //Move up
        if (transform.position.y < m_Player.position.y + m_OffSet.y)
            transform.Translate(Vector3.up * Time.deltaTime);
        //Move down
        if (transform.position.y > m_Player.position.y + m_OffSet.y)
            transform.Translate(Vector3.down * Time.deltaTime);

    }

    public void LookAtPlayer()
    {
        Vector3 flipped = m_WhiteLady.localScale;
        flipped.z *= -1f;

        if (transform.position.x > m_Player.position.x && isFlipped)
        {
            m_WhiteLady.localScale = flipped;
            m_WhiteLady.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < m_Player.position.x && !isFlipped)
        {
            m_WhiteLady.localScale = flipped;
            m_WhiteLady.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
