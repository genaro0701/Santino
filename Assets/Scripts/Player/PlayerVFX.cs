using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] m_VFX;

    public void AttackVFX()
    {
        m_VFX[0].Play();
    }
    
    public void Skill1VFX()
    {
        m_VFX[1].Play();
    }

    public void Skill2VFX()
    {
        m_VFX[2].Play();
    }

    public void JumpVFX()
    {
        m_VFX[3].Play();
    }

    public void DamageVFX()
    {
        m_VFX[4].Play();
    }
}
