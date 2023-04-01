using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    // ZAPIS I ODCZYT PLIKU Z KLASA SaveData.cs
    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/Cars.sr";   // %appdata%/localLow/Orlik/KORG/Cars.sr
        if (File.Exists(path))                                          // jesli plik istnieje -> wczytaj
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            Debug.Log("Wczytano");
            return data;
        }
        else // Jesli nie istneje to default
        {
            PlayerData data = new PlayerData();

            Debug.Log("NowyZapis");
            return data;
        }
    }

    public static void Save(PlayerData Car)   //zapisuje klase w %appdata%/localLow/Orlik/KORG/Cars.sr
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Cars.sr";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, Car);
        fileStream.Close();
    }
}

