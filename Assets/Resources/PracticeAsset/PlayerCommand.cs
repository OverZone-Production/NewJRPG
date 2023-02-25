using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCommand : MonoBehaviour
{    

    private GameObject bottomPanel;
    private GameObject attackPanel;
    private GameObject actionPanel;

    private GameObject player;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();

        bottomPanel = GameObject.FindGameObjectWithTag("BottomPanel");
        attackPanel = bottomPanel.transform.Find("AttackPanel").gameObject;
        actionPanel = bottomPanel.transform.Find("ActionPanel").gameObject;
        attackPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnPressAttack()
    {
        attackPanel.SetActive(true);
        actionPanel.SetActive(false);
    }

    public void OnPressBraveSlash()
    {
        attackPanel.SetActive(false);
        anim.SetTrigger("BraveSlash");
    }

    public void OnPressSpinSlash()
    {
        attackPanel.SetActive(false);
        anim.SetTrigger("SpinSlash");
    }

}
