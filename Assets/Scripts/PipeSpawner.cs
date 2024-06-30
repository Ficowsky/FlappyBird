using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Prywatna zmienna typu float przechowuj�ca maksymalny czas mi�dzy spawnami rur
    [SerializeField] private float _maxTime = 1.5f;

    // Prywatna zmienna typu float przechowuj�ca zakres wysoko�ci spawnowanych rur
    [SerializeField] private float _heightRange = 0.45f;

    // Prywatna zmienna typu GameObject przechowuj�ca prefab rury
    [SerializeField] private GameObject _pipe;

    // Prywatna zmienna typu float przechowuj�ca czas od ostatniego spawnu
    private float _timer;

    // Metoda uruchamiana na pocz�tku dzia�ania skryptu
    private void Start()
    {
        // Spawnuje pierwsz� rur� na pocz�tku
        SpawnPipe();
        // Resetuje timer
        _timer = 0;
    }

    // Metoda uruchamiana co klatk�
    private void Update()
    {
        // Je�li czas od ostatniego spawnu przekroczy� maksymalny czas, spawnuje now� rur�
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
        // Oblicza pozycj� spawnu z losow� wysoko�ci� w zakresie heightRange
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        // Instancjonuje now� rur� na obliczonej pozycji
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        // Niszczy rur� po 10 sekundach
        Destroy(pipe, 10f);
    }
}
