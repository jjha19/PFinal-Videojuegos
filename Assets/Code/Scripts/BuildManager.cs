using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    //[SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private Tower[] towers;

    private int currentSelectedTower = 0;

    private void Awake()
    {
        main = this;

    }

    public Tower GetSelectedTower()
    {
        return towers[currentSelectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        currentSelectedTower = _selectedTower;
    }
}   
