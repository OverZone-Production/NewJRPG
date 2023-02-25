using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Windows;

public class EnemyStatusManager : MonoBehaviour, IObserver
{
    [SerializeField] List<GameObject> m_enemiseStore;

    private static EnemyStatusManager m_instance;
    private Dictionary<string, EnemyHealth> m_enemiseHealth = new Dictionary<string, EnemyHealth>();
    private string m_numberPattern = "\\d+";

    public static EnemyStatusManager Instance { get => m_instance; set => m_instance = value; }
    public Dictionary<string, EnemyHealth> EnemiseHealth1 { get => m_enemiseHealth; set => m_enemiseHealth = value; }

    void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this);
            return;
        }

        m_instance = this;
    }

    void Start()
    {
        foreach (GameObject enemy in m_enemiseStore)
        {
            m_enemiseHealth.Add(enemy.tag,enemy.GetComponent<EnemyHealth>());
        }    
    }

    public void AttackToEnemy(string tag, float damage)
    {
        MatchCollection matches = Regex.Matches(tag, m_numberPattern);
        int enemyIdx = int.Parse(matches[0].Value) - 1;
        m_enemiseHealth[tag].TakeDamage(damage);
        UIEnemyPanel.Instance.UpdateEnemyHP((int)m_enemiseHealth[tag].CurrentHP, enemyIdx);

    }

    public void OnNotify(PlayerAction action, GameObject objRef = null, Payload payload = null)
    {
        switch (action)
        {
            case PlayerAction.Attack:
                AttackToEnemy(payload.Tag, payload.Damage);
                break;
        }
    }
}
