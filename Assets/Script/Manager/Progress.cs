using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress
{
    public static bool IsSaveDataExist { get => PlayerPrefs.GetInt("day", -1) != -1; }

    public static void Save() => PlayerPrefs.SetInt("day", PlayerManager.day);

    public static void Load() => PlayerManager.day = PlayerPrefs.GetInt("day");
}