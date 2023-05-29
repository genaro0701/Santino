using UnityEngine;

public class PlayerAnimation : Singleton<PlayerAnimation>
{
    [SerializeField] private Animator m_SantinoAnim;

    private string[] m_WeaponAnimation = {"Kahoy", "Bamboo", "Sumpit", "Batuta", "Bat"};

    public void SantinoChangeWeapon(int _newWeapon)
    {
        for (int i = 0; i < m_WeaponAnimation.Length; i++)
        {
            bool anim = m_SantinoAnim.GetBool(m_WeaponAnimation[i]);
            if (anim) m_SantinoAnim.SetBool(m_WeaponAnimation[i], false);

            if (i + 1 == _newWeapon) 
            { 
                m_SantinoAnim.SetBool(m_WeaponAnimation[i], true);
                PlayerPrefasManager.Instance.ChangeWeapon = _newWeapon;
            }
        }

        m_SantinoAnim.SetTrigger("Change");
    }

    public void SantinoRun(float Speed)
    {
        m_SantinoAnim.SetFloat("Run", Speed);
    }

    public void SantinoJump(bool Jump = false)
    {
        m_SantinoAnim.SetBool("Jump", Jump);
    }

    public void SantinoAttack()
    {
        m_SantinoAnim.SetTrigger("Attack");
    }

    public void SantinoSkill()
    {
        m_SantinoAnim.SetTrigger("Skill1");
    }

    public void SantinoUltimate()
    {
        m_SantinoAnim.SetTrigger("Skill2");
    }

    public void SantinoHurt()
    {
        m_SantinoAnim.SetTrigger("Hurt");
    }

    public void SantinoDie()
    {
        m_SantinoAnim.SetBool("Die", true);
    }

    public void SantinoAim(float value)
    {
        m_SantinoAnim.SetFloat("Aim", value);
    }
}
