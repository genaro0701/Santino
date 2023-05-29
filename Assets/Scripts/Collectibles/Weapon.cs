using DG.Tweening;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject m_Parent;
    [SerializeField] private int m_WeaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 30), 3, RotateMode.FastBeyond360).OnComplete(() => 
        { 
            transform.DOLocalRotate(new(0, 360, 30), 3, RotateMode.FastBeyond360).OnComplete(() => transform.DORestart()); 
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAnimation.Instance.SantinoChangeWeapon(m_WeaponIndex);
            m_Parent.SetActive(false);
        }
    }
}
