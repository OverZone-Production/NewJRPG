using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPartyPanel : MonoBehaviour
{
    [SerializeField] GameObject[] m_partyMembers;
    // Start is called before the first frame update
    
    public void SetMemberNameAtPosition(string name, int idx)
    {
        var memberName = m_partyMembers[idx].transform.Find("MemberName").GetComponent<TextMeshProUGUI>();
        memberName.text = name;
    }

    public void SetCurrentHP(float value, int idx)
    {
        var memberHP = m_partyMembers[idx].
            transform.Find("Health")
            .transform.Find("MemberCurHP")
            .GetComponent<TextMeshProUGUI>();
        memberHP.text = value.ToString();
    }

    public void SetMaxHP(float value, int idx)
    {
        var memberHP = m_partyMembers[idx]
            .transform.Find("Health")
            .transform.Find("MemberMaxHP")
            .GetComponent<TextMeshProUGUI>();
        memberHP.text = value.ToString();
    }
}
