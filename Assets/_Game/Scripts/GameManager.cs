using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Hero Hero { get; private set; }
    private void Start()
    {
        Hero = FindObjectOfType<Hero>();
    }
}
