using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private Transform m_NextPos;

    private Vector3[] m_MovePos = new Vector3[2];
    private float objectSpeed = 3f;
    private Vector3 moveTo;
    private int index;

    private void Start()
    {
        m_MovePos[0] = transform.position;
        moveTo = m_MovePos[1] = m_NextPos.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == moveTo)
        {
            index++;

            if (index >= m_MovePos.Length)
                index = 0;

            moveTo = m_MovePos[index];
        }

        else
            transform.position = Vector3.MoveTowards(transform.position, moveTo, objectSpeed * Time.deltaTime);
    }
}
