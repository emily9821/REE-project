using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventLinker
{
    public static Dictionary<string, bool> linkedEvent = new Dictionary<string, bool>();

    public static bool IsAvailable(string targetEventName, Action targetEvent = null)
    {
        if (!linkedEvent.ContainsKey(targetEventName))
            return false;

        if (linkedEvent[targetEventName])
        {
            targetEvent?.Invoke();
            return true;
        }
        return false;
    }

    public static void NewEvent(string targetEventName, bool isCompleted = false)
    {
        if (!linkedEvent.ContainsKey(targetEventName))
            linkedEvent.Add(targetEventName, isCompleted);
        else
            linkedEvent[targetEventName] = isCompleted;
    }

    public static void LinkerClear() => linkedEvent.Clear();
}