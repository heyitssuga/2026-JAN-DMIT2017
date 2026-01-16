using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class SaveSystem : MonoBehaviour
{
    public List<SaveProfile> profiles = new  List<SaveProfile>();
    public string filePath;
    public void Start()
    {
        CreateSave(new SaveProfile("Allen", 1));
        LoadSave(0);
    }

    public void CreateSave(SaveProfile profile)
    {
        bool fileExists = File.Exists(filePath);

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            if (!fileExists)
            {
                sw.WriteLine("Profile Name, Score");
            }
            
            sw.WriteLine($"{profile.profileName}, {profile.highScore}");
            profiles.Add(profile);
        }
    }

    public void DeleteSave()
    {
        
    }

    public void LoadSave(int saveIndex)
    {
        int highScore = 0;
        string[] lines = File.ReadAllLines(filePath);

        for (int i = 0; i < lines.Length; i++)
        {
            string[] columns = Regex.Split(lines[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            if (columns[0] == profiles[saveIndex].profileName)
            {
                highScore = int.Parse(columns[1]);
                break;
            }

            Debug.Log(highScore);
        }
    }
}

[SerializeField]
public class SaveProfile
{
    public string profileName;
    public int highScore;

    public SaveProfile(string profileName_, int highScore_)
    {
        profileName = profileName_;
        highScore = highScore_;
    }
}
