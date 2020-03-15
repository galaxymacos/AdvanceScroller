using System.Collections.Generic;
using UnityEngine;

public class RandomColorAssigner: MonoBehaviour
{
    [SerializeField] private List<Color> colors;

    private List<Color> oneTimeColors;

    public static RandomColorAssigner instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Can't have more than one random color assigner");
            Destroy(gameObject);
        }
        
        oneTimeColors = new List<Color>();
        foreach (Color color in colors)
        {
            oneTimeColors.Add(color);
        }
    }

    /// <summary>
    /// Assign a non-repetitive color to a pointer
    /// </summary>
    public Color GenerateRandomColorNonRepet()
    {
        if (oneTimeColors.Count == 0)
        {
            Debug.LogError("Not enough color left");
            return default;
        }
        int randomIndex = Random.Range(0, oneTimeColors.Count);
        Color colorToReturn = oneTimeColors[randomIndex];
        oneTimeColors.RemoveAt(randomIndex);
        return colorToReturn;
    }
}