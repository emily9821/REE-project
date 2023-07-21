using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventLinker
{
    private static Dictionary<string, bool> linkedEvent = new Dictionary<string, bool>();

    public static bool IsAvailable(string targetEventName, Action targetEvent = null)
    {
        if (!linkedEvent.ContainsKey(targetEventName))
            linkedEvent.Add(targetEventName, false);
        else
            targetEvent?.Invoke();

        return linkedEvent[targetEventName];
    }

    public static void LinkerClear() => linkedEvent.Clear();
}