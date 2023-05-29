using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public void Idle()
    {
        Play("SantinoIdle");
    }

    public void Run()
    {
        Play("SantinoRun");
    }

    public void Jump()
    {
        Play("SantinoJump");
    }

    public void Attack1()
    {
        Play("SantinoAttack");
    }

    public void Skill()
    {
        Play("SantinoSkill");
    }

    public void Ultimate()
    {
        Play("SantinoUltimate");
    }

    public void Hurt()
    {
        Play("SantinoHurt");
    }

    public void Die()
    {
        Play("SantinoDie");
    }

    private void Play(string _sound)
    {
        Managers.Instance.audioManager.Play(_sound);
    }
}
