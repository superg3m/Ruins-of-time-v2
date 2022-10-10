using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class StatusSystem : MonoBehaviour
{

    public List<string> keys;
    public List<int> values;

    private HealthSystem healthSystem;
    public List<string> statusTracker = new List<string>();

    public Dictionary<string, int> statusDictionary;
    public Dictionary<string, int> statusDictionaryCache;
    bool firstTime = true;
    bool updating;

    public void Awake()
    {
        healthSystem = this.GetComponent<HealthSystem>();
        statusDictionary = new Dictionary<string, int>()
        {
            {"Burn", 0},
            {"Heal", 0},
            {"Poison", 0},
            {"Bleeding", 0},
            {"Vulnerable", 0},
            {"Retain Block", 0}
        };
    }
    public void Update()
    {
        if(updating)
        {
            keys.Clear();
            values.Clear();
            foreach (KeyValuePair<string, int> kvp in statusDictionary)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }
            for (int i = 0; i < statusDictionary.Count; i++)
            {
                if (statusDictionary[keys[i]] < 0)
                {
                    statusDictionary[keys[i]] = 0;
                }
            }
        }
    }

    public void addStatuses(string statusToAdd, int quanity)
    {
        if (statusDictionary[statusToAdd] == 0)
        {
            statusTracker.Add(String.Format("{0} {1}x", statusToAdd, quanity));
            statusDictionary[statusToAdd] += quanity;
        }

        else if (statusDictionary[statusToAdd] > 0)
        {
            statusTracker.Remove(String.Format("{0} {1}x", statusToAdd, statusDictionary[statusToAdd]));
            statusDictionary[statusToAdd] += quanity;
            statusTracker.Add(String.Format("{0} {1}x", statusToAdd, statusDictionary[statusToAdd]));
        }
        updating = true;
    }
    public void removeStatus(string statusToRemove, int quantity)
    {
        statusTracker.Remove(String.Format("{0} {1}x", statusToRemove, statusDictionary[statusToRemove]));
        statusDictionary[statusToRemove] -= quantity;
        if (statusDictionary[statusToRemove] <= 0)
        {
            statusTracker.Remove(String.Format("{0} {1}x", statusToRemove, statusDictionary[statusToRemove]));
        }
        else
        {
            statusTracker.Add(String.Format("{0} {1}x", statusToRemove, statusDictionary[statusToRemove]));
        }
        updating = true;
    }

    public void lowerStatusQuantity()
    {
        if (!firstTime)
        {
            for (int i = 0; i < statusDictionary.Count; i++)
            {
                if (statusDictionary[keys[i]] > 0)
                {
                    statusTracker.Remove(String.Format("{0} {1}x", keys[i], statusDictionary[keys[i]]));
                    if (statusDictionary[keys[i]] - 1 == 0)
                    {
                        statusTracker.Remove(String.Format("{0} {1}x", keys[i], statusDictionary[keys[i]]));
                    }
                    else
                    {
                        statusTracker.Add(String.Format("{0} {1}x", keys[i], statusDictionary[keys[i]] - 1));
                    }
                    statusDictionary[keys[i]] -= 1;
                }

            }
        }
        firstTime = false;
        updating = true;
    }

    public void doEffectDamage()
    {
        foreach(string status in keys)
        {
            switch (status)
            {

                case "Heal":
                    if (statusDictionary[status] > 0)
                    {
                        Debug.Log(status + ": " + statusDictionary[status]);
                    }
                    break;
                
                case "Vulnerable":
                    if (statusDictionary[status] > 0)
                    {
                        Debug.Log(status + ": " + statusDictionary[status]);
                        healthSystem.vulnerable = true;
                    }
                    break;

                case "Retain Block":
                    if (statusDictionary[status] > 0)
                    {
                        Debug.Log(status + ": " + statusDictionary[status]);
                    }
                    break;

                default:
                    if (statusDictionary[status] > 0)
                    {
                        Debug.Log(status + ": " + statusDictionary[status]);
                        healthSystem.addHealth(-statusDictionary[status]);
                    }
                    break;
            }
        }        
    }
}
