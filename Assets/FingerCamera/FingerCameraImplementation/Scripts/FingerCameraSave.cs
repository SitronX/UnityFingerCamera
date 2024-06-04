using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.SceneView;

public class FingerCameraSave
{
    public static FingerCameraSettings CameraSettings { get; set; }

    static string _settingsPath = Application.persistentDataPath + "/fingerCameraSettings.json";
    public static void SaveFingerCameraSettings()
    {
        string settingsTxt = JsonConvert.SerializeObject(CameraSettings);
        File.WriteAllText(_settingsPath, settingsTxt);
    }
    public static void LoadFingerCameraSettings(bool usePersistence)
    {
        if(CameraSettings == null)
        {
            if (usePersistence)
            {
                if (File.Exists(_settingsPath))
                {
                    string settingsTxt = File.ReadAllText(_settingsPath);
                    CameraSettings = JsonConvert.DeserializeObject<FingerCameraSettings>(settingsTxt);
                }
            }
            else
                CameraSettings=new FingerCameraSettings();
        }   
    }
}
