using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour {

    private static RuleManager instance;
    public static RuleManager Instacne
    {
        get
        {
            return instance;
        }
    }
    private List<Rule> m_ruleList = new List<Rule>();
    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        Object[] objects = Resources.LoadAll("Rules", typeof(GameObject));
        foreach(var temp in objects)
        {
            Rule rule = ((GameObject)temp).GetComponent<Rule>();
            if(rule.Active)
                m_ruleList.Add(rule);
        }
    }
	
	public Rule GetRandomRule()
    {
        int index = Random.Range(0, m_ruleList.Count);
        return m_ruleList[index];
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
