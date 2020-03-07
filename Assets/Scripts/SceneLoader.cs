using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadFightingMapFromSavedData()
    {
        var data = SaveSystem.LoadHeroSelectionData();
        SceneManager.LoadScene(data.fightSceneIndex);
    }
}