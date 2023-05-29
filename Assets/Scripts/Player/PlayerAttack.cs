using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Stats m_SantinoStats;

    [SerializeField] private Transform m_AttackPoint;
    [SerializeField] private Transform m_FirePointNormal;
    [SerializeField] private Transform m_FirePointMid;
    [SerializeField] private Transform m_FirePointHigh;
    [SerializeField] private LayerMask m_EnemyLayer;
    [SerializeField] private float m_AttackRange = 1.28f;

    [SerializeField] private ButtonManager m_Attack;

    [SerializeField] private PlayerVFX m_VFX;

    private float nextAttackTime, nextSkill1Time, nextSkill2Time;
    private float joystickVertical, wait = .3f;

    private int weapon;

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Mathf.Abs(PlayerMovement.Instance.joystickHorizontal);

        //OnPress Attack Button
        if (m_Attack.attack && move == 0 || Input.GetKeyDown(KeyCode.J) && move == 0)
        {
            if (Time.time >= nextAttackTime)
            {
                weapon = PlayerPrefasManager.Instance.ChangeWeapon;

                //attack animation
                PlayerAnimation.Instance.SantinoAttack();
                
                attack();
            }
        }

        //OnPress Skill Button
        if (m_Attack.skill && move == 0 || Input.GetKeyDown(KeyCode.K) && move == 0)
        {
            if (Time.time >= nextSkill1Time)
            {
                weapon = PlayerPrefasManager.Instance.ChangeWeapon;
               
                if (weapon != 3)
                {
                    Play("SantinoSkill");
                    m_VFX.Skill1VFX();
                    PlayerAnimation.Instance.SantinoSkill();
                }
               
                Skill1();

                StartCoroutine(Managers.Instance.uiManager.CoolDownSkill(nextSkill1Time));
            }
        }

        //OnPress Ultimate Button
        if (m_Attack.ultimate && move == 0 || Input.GetKeyDown(KeyCode.L) && move == 0)
        {
            if (Time.time >= nextSkill2Time)
            {
                weapon = PlayerPrefasManager.Instance.ChangeWeapon;

                if (weapon != 3)
                {
                    Play("SantinoUltimate");
                    m_VFX.Skill2VFX();
                    //ultimate animation
                    PlayerAnimation.Instance.SantinoUltimate();
                }
               
                Skill2();

                StartCoroutine(Managers.Instance.uiManager.CoolDownUltimate(nextSkill2Time));
            }
        }

        if (m_Attack.attack || m_Attack.skill || m_Attack.ultimate)
        {
            m_Attack.attack = false;
            m_Attack.skill = false;
            m_Attack.ultimate = false;
        }

    }


    private void attack()
    {
        //Turn OFF
        switch (weapon)
        {
            case 1:
                Play("SantinoAttack");
                m_VFX.AttackVFX();
                AttackDamage(m_SantinoStats.santino.weapon[1].attackDamage);
                nextAttackTime = Time.time + m_SantinoStats.santino.weapon[1].attackCD;
                break;
            case 2:
                Play("SantinoAttack");
                m_VFX.AttackVFX();
                AttackDamage(m_SantinoStats.santino.weapon[2].attackDamage);
                nextAttackTime = Time.time + m_SantinoStats.santino.weapon[2].attackCD;
                break;
            case 3:
                StartCoroutine(SumpitAttack());
                nextAttackTime = Time.time + m_SantinoStats.santino.weapon[3].attackCD;
                break;
            case 4:
                Play("SantinoAttack");
                m_VFX.AttackVFX();
                AttackDamage(m_SantinoStats.santino.weapon[4].attackDamage);
                nextAttackTime = Time.time + m_SantinoStats.santino.weapon[4].attackCD;
                break;
            case 5:
                Play("SantinoAttack");
                m_VFX.AttackVFX();
                AttackDamage(m_SantinoStats.santino.weapon[5].attackDamage);
                nextAttackTime = Time.time + m_SantinoStats.santino.weapon[5].attackCD;
                break;
        }
    }

    private void Skill1()
    {
        //Turn OFF
        switch (weapon)
        {
            case 1:
                AttackDamage(m_SantinoStats.santino.weapon[1].skill1Damage);
                nextSkill1Time = Time.time + m_SantinoStats.santino.weapon[1].skill1CD;
                break;
            case 2:
                AttackDamage(m_SantinoStats.santino.weapon[2].skill1Damage);
                nextSkill1Time = Time.time + m_SantinoStats.santino.weapon[2].skill1CD;
                break;
            case 3:
                StartCoroutine(SumpitSkill());
                nextSkill1Time = Time.time + m_SantinoStats.santino.weapon[3].skill1CD;
                break;
            case 4:
                AttackDamage(m_SantinoStats.santino.weapon[4].skill1Damage);
                nextSkill1Time = Time.time + m_SantinoStats.santino.weapon[4].skill1CD;
                break;
            case 5:
                AttackDamage(m_SantinoStats.santino.weapon[5].skill1Damage);
                nextSkill1Time = Time.time + m_SantinoStats.santino.weapon[5].skill1CD;
                break;
        }
    }
    
    private void Skill2()
    {
        //Turn OFF
        switch (weapon)
        {
            case 1:
                AttackDamage(m_SantinoStats.santino.weapon[1].skill2Damage);
                nextSkill2Time = Time.time + m_SantinoStats.santino.weapon[1].skill2CD;
                break;
            case 2:
                AttackDamage(m_SantinoStats.santino.weapon[2].skill2Damage);
                nextSkill2Time = Time.time + m_SantinoStats.santino.weapon[2].skill2CD;
                break;
            case 3:
                StartCoroutine(SumpitSkill(true));
                nextSkill2Time = Time.time + m_SantinoStats.santino.weapon[3].skill2CD;
                break;
            case 4:
                AttackDamage(m_SantinoStats.santino.weapon[4].skill2Damage);
                nextSkill2Time = Time.time + m_SantinoStats.santino.weapon[4].skill2CD;
                break;
            case 5:
                AttackDamage(m_SantinoStats.santino.weapon[5].skill2Damage);
                nextSkill2Time = Time.time + m_SantinoStats.santino.weapon[5].skill2CD;
                break;
                
        }
    }

    private IEnumerator SumpitAttack()
    {
        yield return new WaitForSeconds(wait);

        GameObject obj = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Bawang);

        if (joystickVertical == 0 && joystickVertical < .4f)
        {
            obj.transform.position = m_FirePointNormal.position;
            obj.GetComponent<Ammo>().AttackNormal(transform.right);
        }

        else if (joystickVertical >= .4f && joystickVertical < .7f)
        {
            obj.transform.position = m_FirePointMid.position;
            obj.GetComponent<Ammo>().AttackMid(transform.right);
        }

        else if (joystickVertical >= .7f && joystickVertical <= 1f)
        {
            obj.transform.position = m_FirePointHigh.position;
            obj.GetComponent<Ammo>().AttackHigh(transform.right);
        }
    }
    
    private IEnumerator SumpitSkill(bool skill2 = false)
    {
        PlayerAnimation.Instance.SantinoAttack();
        StartCoroutine(SumpitAttack());

        yield return new WaitForSeconds(wait);
        PlayerAnimation.Instance.SantinoSkill();
        yield return new WaitForSeconds(wait);

        GameObject obj2 = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Bawang);
        obj2.transform.position = m_FirePointMid.position;
        obj2.GetComponent<Ammo>().AttackMid(transform.right);

        if (skill2)
        {
            yield return new WaitForSeconds(wait);
            PlayerAnimation.Instance.SantinoUltimate();
            yield return new WaitForSeconds(wait);

            GameObject obj3 = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Bawang);
            obj3.transform.position = m_FirePointHigh.position;
            obj3.GetComponent<Ammo>().AttackHigh(transform.right);
        }
    }

    private void AttackDamage(int damage)
    {
        //basic attack animation

        //detect enemy in range of attack 
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(m_AttackPoint.position, m_AttackRange, m_EnemyLayer);

        foreach (Collider2D enemy in enemyHit)
        {
                //player damage to bungisgis
            if (enemy.CompareTag("Bungisngis"))
                enemy.GetComponent<BungisngisHealth>().SetDamage(damage);
            else if (enemy.CompareTag("Boss Bungisngis"))
                enemy.GetComponent<BossBungisngisHealth>().SetDamage((int)(damage + (damage * .20f)));
            else if (enemy.CompareTag("Kapre"))
                enemy.GetComponent<KapreHealth>().SetDamage((int)(damage));
            else if (enemy.CompareTag("Boss Kapre"))
                enemy.GetComponent<BossKapreHealth>().SetDamage((int)(damage + (damage * .23f)));
            else if (enemy.CompareTag("Mob"))
                enemy.GetComponent<MobHealth>().SetDamage(damage);
            else if (enemy.CompareTag("Boss Tiktik"))
                enemy.GetComponent<BossTiktikHealth>().SetDamage((int)(damage + (damage * .26f)));
            else if (enemy.CompareTag("Manananggal"))
                enemy.GetComponent<MobHealth>().SetDamage((int)(damage + (damage * .29f)));
            else if (enemy.CompareTag("Destructible"))
                //player damage to Wall
                enemy.GetComponent<destructibleWall>().SetDamage(damage);
            else if (enemy.CompareTag("DestructibleVine"))
                //player damage to Wall
                enemy.GetComponent<vineObstacle>().SetDamage(damage);
            else
                Debug.Log(enemy.name + "tag is not assigned!");
        }
    }

    //draw visible sphere in editor
    private void OnDrawGizmosSelected()
    {
        if(m_AttackPoint != null)
            Gizmos.DrawWireSphere(m_AttackPoint.position, m_AttackRange);
    }

    private void Play(string _audio)
    {
        Managers.Instance.audioManager.Play(_audio);
    }
}
