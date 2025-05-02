using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveVariablesManager : MonoBehaviour
{
    private static string rutaArchivo = Application.persistentDataPath + "/gameVariables.json";

    public static void SaveVariables(GameVariables gameVariables)
    {
        string json = JsonUtility.ToJson(gameVariables, true);
        File.WriteAllText(rutaArchivo, json);
    }

    public static GameVariables LoadVariables()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            return JsonUtility.FromJson<GameVariables>(json);
        }
        else
        {
            return new GameVariables(); 
        }
    }
}
