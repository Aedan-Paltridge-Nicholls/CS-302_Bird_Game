using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using System.IO;
using UnityEngine.Audio;
public static class Settings_IO 
{
    private static string SettingsFilePath => Path.Combine(Application.persistentDataPath, "settings.json");
    public static void SaveSettings(Settings_SO SettingsObject)
    {
        string json = JsonUtility.ToJson(SettingsObject, true);
        File.WriteAllText(SettingsFilePath, json);
        Debug.Log($"Settings saved to {SettingsFilePath}");
    }

    public static void LoadSettings(Settings_SO SettingsObject)
    {
        if (File.Exists(SettingsFilePath))
        {
            string json = File.ReadAllText(SettingsFilePath);
            JsonUtility.FromJsonOverwrite(json, SettingsObject);
            Debug.Log($"Settings loaded from {SettingsFilePath}");
        }
        else
        {
            Debug.LogWarning($"Settings file not found at{SettingsFilePath} use defaults");
        }
    }
}
