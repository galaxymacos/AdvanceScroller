using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemTester : MonoBehaviour
{
    [SerializeField] private List<GameObject> _champions;

    public List<GameObject> Champions => _champions;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TransitionToNext", 3f);
    }

    public void TransitionToNext()
    {
        print("Transition to main game");
        CreateData();
    }

    private void CreateData()
    {
        FightData fightData = new FightData(_champions, 2);
        SaveSystem.SaveHeroSelectionData(fightData.SaveToString());
        SceneLoader.LoadFightingMapFromSavedData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
