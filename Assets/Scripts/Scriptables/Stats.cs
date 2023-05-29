
using UnityEngine;

[CreateAssetMenu (fileName = "Stats", menuName = "Stats")]
public class Stats : ScriptableObject
{
    public PlayerStats santino;
    public Bungisngis bungisngis;
    public BossBungisngis bossBungisngis;
    public Nuno nuno;
    public Kapre kapre;
    public BossKapre bossKapre;
    public Mob mob;
    public BossTiktik bossTiktik;
    public Manananggal manananggal;

    [System.Serializable]
    public class PlayerStats
    {
        public int health;
        public Weapon[] weapon;
    }

    [System.Serializable]
    public class Weapon
    {
        public string weaponsName;
        public int attackDamage;
        public float attackCD;
        public int skill1Damage;
        public float skill1CD;
        public int skill2Damage;
        public float skill2CD;
    }

    [System.Serializable]
    public class Bungisngis
    {
        public string name;
        public int health;
        public int attackDamage;
    }

    [System.Serializable]
    public class BossBungisngis
    {
        public string name;
        public int health;
        public int attackDamage;
        public int enlargedAttackDamage;
    }

    [System.Serializable]
    public class Nuno
    {
        public int attackDamage;
    }

    [System.Serializable]
    public class Kapre
    {
        public string name;
        public int health;
        public int attackDamage;
    }

    [System.Serializable]
    public class BossKapre
    {
        public string name;
        public int health;
        public int attackDamage;
    }
    
    [System.Serializable]
    public class Mob
    {
        public string name;
        public int health;
        public int attackDamage;
    }
    
    [System.Serializable]
    public class BossTiktik
    {
        public string name;
        public int health;
        public int attackDamage;
    }
    
    [System.Serializable]
    public class Manananggal
    {
        public string name;
        public int health;
        public int attackDamage;
    }
}
