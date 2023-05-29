using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Joystick m_Joystick;

    private bool joystickL, jump, attack, skill1, skill2;

    private void Update()
    {
        if (m_Joystick.Horizontal > .99f)
        {
            m_Animator.SetTrigger("Joystick L");
            joystickL = true;
        }
        if (m_Joystick.Horizontal < -.99f && joystickL)
        {
            m_Animator.SetTrigger("Jump");
            jump = true;
        }
    }

    public void Jump()
    {
        if (jump)
        {
            m_Animator.SetTrigger("Attack");
            attack = true;
        }
    }

    public void Attack()
    {
        if (attack)
        {
            m_Animator.SetTrigger("Skill");
            skill1 = true;
        }
    }
    
    public void Skill()
    {
        if (skill1)
        {
            m_Animator.SetTrigger("Ultimate");
            skill2 = true;
        }
    }

    public void OnDone()
    {
        if (skill2)
        {
            PlayerPrefasManager.Instance.Tutorial = "Tutorial";
            Managers.Instance.uiManager.Tutorial();
        }
    }
}
