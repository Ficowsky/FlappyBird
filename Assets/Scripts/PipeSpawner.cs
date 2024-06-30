using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Prywatna zmienna typu float przechowuj¹ca maksymalny czas miêdzy spawnami rur
    [SerializeField] private float _maxTime = 1.5f;

    // Prywatna zmienna typu float przechowuj¹ca zakres wysokoœci spawnowanych rur
    [SerializeField] private float _heightRange = 0.45f;

    // Prywatna zmienna typu GameObject przechowuj¹ca prefab rury
    [SerializeField] private GameObject _pipe;

    // Prywatna zmienna typu float przechowuj¹ca czas od ostatniego spawnu
    private float _timer;

    // Metoda uruchamiana na pocz¹tku dzia³ania skryptu
    private void Start()
    {
        // Spawnuje pierwsz¹ rurê na pocz¹tku
        SpawnPipe();
        // Resetuje timer
        _timer = 0;
    }

    // Metoda uruchamiana co klatkê
    private void Update()
    {
        // Jeœli czas od ostatniego spawnu przekroczy³ maksymalny czas, spawnuje now¹ rurê
        if (_timer > _maxTime)
        {
            SpawnPipe();
            // Resetuje timer
            _timer = 0;
        }

        // Aktualizuje timer
        _timer += Time.deltaTime;
    }

    // Metoda do spawnowania rur
    private void SpawnPipe()
    {
        // Oblicza pozycjê spawnu z losow¹ wysokoœci¹ w zakresie heightRange
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        // Instancjonuje now¹ rurê na obliczonej pozycji
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        // Niszczy rurê po 10 sekundach
        Destroy(pipe, 10f);
    }
}
