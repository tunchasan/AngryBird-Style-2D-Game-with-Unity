using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private static int _nextLevelIndex = 1;

    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }

        _nextLevelIndex++;

        SceneManager.LoadScene("Level" + _nextLevelIndex);
    }
}
