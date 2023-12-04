using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField]
    private string fileName;

    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;

    private FileDataHandler dataHandler;
    private string selectedProfileId = "test";
    public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if ( instance != null )
        {
            Debug.LogError("There is more than one Data Persistance Manager !");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load(selectedProfileId);

        if ( this.gameData == null )
        {
            Debug.Log("No data found in the game, Start a new game in order to continue the game");
            return;
        }

        foreach ( IDataPersistance dataPersistanceObject in dataPersistanceObjects )
        {
            dataPersistanceObject.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObject in dataPersistanceObjects)
        {
            dataPersistanceObject.SaveData(ref gameData);
        }

        dataHandler.Save(gameData, selectedProfileId);
    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("On Scene Loaded Called");
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("On Scene Unloaded Called");
        SaveGame();
    }

    public void ChangeSelectedProfileId(string newProfileId)
    {
        this.selectedProfileId = newProfileId;
        LoadGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public bool HasData()
    {
        return (gameData != null);
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}
