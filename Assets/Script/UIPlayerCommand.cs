using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class UIPlayerCommand : Subject
{

    [SerializeField] float cooldowmPressed = 0.5f;
    [SerializeField] GameObject[] magicsPrefab;
    [SerializeField] float m_speed = 5.0f;
    [SerializeField] float m_attackDelay = 1.0f;
    [SerializeField] float m_breakDistance = 5.0f;

    [Header("Background Effect")]
    [SerializeField] Animator backgroundAnim;
    [SerializeField] float backgroundEffectDuration = 1.0f;

    private GameObject m_player;
    private Character m_character;
    private Animator anim;
    private float lastTimePress = 0.0f;
    private BattleManager battleManager;
    private bool m_reachMonster = false;
    private string m_targetEnemyTag;
    private GameObject m_targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = BattleManager.Instance;

        InitObserver();
    }

    public override void InitObserver()
    {
        AddObserver(GetComponent<UIEnemyPanel>());
        AddObserver(EnemyStatusManager.Instance);
    }

    public void Attack()
    {
        if (Time.time > lastTimePress + cooldowmPressed)
        {
            lastTimePress = Time.time;
            m_targetEnemyTag = battleManager.EnemyPositionTag;
            m_targetEnemy = GameObject.FindGameObjectWithTag(m_targetEnemyTag);
            m_player = GameObject.FindGameObjectWithTag("Member-1");
            m_character = m_player.GetComponent<Character>();

            NotifyObservers(PlayerAction.Attack);

            
            anim = m_player.GetComponent<Animator>();   
            StartCoroutine(AttackProcess());
        }
    }

    private IEnumerator AttackProcess()
    {
        Vector3 originPlayer = m_player.transform.position;

        anim.SetBool("IsRunning", true);
        StartCoroutine(PlayerMoveAnimation(m_targetEnemy, m_player.transform.position, m_targetEnemy.transform.position, m_breakDistance));

        yield return new WaitUntil(() => m_reachMonster);

        StartCoroutine(PlayerMoveAnimation(m_targetEnemy, m_player.transform.position, originPlayer, 0));

        anim.SetBool("IsRunning", false);
    }

    private IEnumerator PlayerMoveAnimation(GameObject enemy, Vector3 start, Vector3 end, float breakDistance)
    {
        while (Vector3.Distance(start, end) > breakDistance)
        {
            m_player.transform.position = Vector3.MoveTowards(start, end, m_speed * Time.deltaTime);
            start = m_player.transform.position;
            yield return new WaitForEndOfFrame();
        }

        m_reachMonster = !m_reachMonster;
        
    }

    public void UseMagic(int index)
    {
        StartCoroutine(BackgroundEffect());
        GameObject magic = Instantiate(magicsPrefab[index], magicsPrefab[index].transform.position, Quaternion.identity);
        
    }

    private IEnumerator BackgroundEffect()
    {
        backgroundAnim.SetBool("IsMeteorSkill", true);
        yield return new WaitForSeconds(backgroundEffectDuration);
        backgroundAnim.SetBool("IsMeteorSkill", false);
    }

    public override void NotifyObservers(PlayerAction action)
    {
        var payload = new Payload(tag: m_targetEnemyTag, damage: m_character.Damage);
        foreach (IObserver observer in Observers)
        {
            observer.OnNotify(action, payload: payload);
        }
    }

    
}
