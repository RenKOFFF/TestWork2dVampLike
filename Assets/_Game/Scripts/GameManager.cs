using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Hero Hero { get; private set; }
    private void Awake()
    {
        Hero = FindObjectOfType<Hero>();
    }
}
