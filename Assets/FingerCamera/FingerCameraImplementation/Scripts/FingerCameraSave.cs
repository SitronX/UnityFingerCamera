using System.IO;
using UnityEngine;

public class FingerCameraSave
{
    public static FingerCameraSettings CameraSettings { get; set; }

    static string _settingsPath = Application.persistentDataPath + "/fingerCameraSettings.json";
    public static void SaveFingerCameraSettings()
    {
        string settingsTxt = JsonUtility.ToJson(CameraSettings);
        File.WriteAllText(_settingsPath, settingsTxt);
    }
    public static void LoadFingerCameraSettings(bool usePersistence)
    {
        if(CameraSettings == null)
        {
            if (usePersistence)
            {
                try
                {
                    if (File.Exists(_settingsPath))
                    {
                        string settingsTxt = File.ReadAllText(_settingsPath);
                        CameraSettings = JsonUtility.FromJson<FingerCameraSettings>(settingsTxt);

                        if(CameraSettings != null )
                            return;
                    }
                }
                catch { }             
            }
            
            CameraSettings=new FingerCameraSettings();
        }   
    }
}
