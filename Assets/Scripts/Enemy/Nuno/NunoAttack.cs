using UnityEngine;
 

public class NunoAttack : MonoBehaviour
{
    [SerializeField] private bool m_LastNuno = false;

    private Transform m_Player;
    private float m_Gravity = 4f;

    private bool isFlipped = false;

    private int m_RockCount;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Attack()
    {
        GameObject rock = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Rock);

        if (rock != null)
        {
            rock.transform.position = new Vector2(m_Player.position.x, m_Player.position.y + 14f);
            rock.GetComponent<Rigidbody2D>().gravityScale = m_Gravity;
            m_RockCount++;
        }

        if (m_RockCount == 3)
        {
            GameObject material = BasicObjectPooling.Instance.Dequeue((eObjectPoolType)Random.Range(0, 4));

            if (material != null)
                material.transform.position = transform.position;

            if (m_LastNuno)
                FindObjectOfType<ButtonManager>().Objective(0);

            Destroy(gameObject);
        }
    }

    public void LookAtPlayer()
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
