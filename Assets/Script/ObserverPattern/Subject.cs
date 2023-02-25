using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<IObserver> m_observers = new List<IObserver>();

    public List<IObserver> Observers { get => m_observers; private set => m_observers = value; }

    public void AddObserver(IObserver observer)
    {
        m_observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        m_observers.Remove(observer);
    }

    public abstract void InitObserver();
    public abstract void NotifyObservers(PlayerAction action);
}
