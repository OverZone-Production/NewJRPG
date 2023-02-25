using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public void OnNotify(PlayerAction action, GameObject objRef = null, Payload payload = null);
}
