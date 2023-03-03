using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int LevelPlayerHasReached;


    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LevelIncrease()
    {
        LevelPlayerHasReached++;
    }

   
}
