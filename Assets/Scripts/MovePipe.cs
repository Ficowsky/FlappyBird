using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    // Prywatna zmienna typu float przechowuj�ca pr�dko�� ruchu
    [SerializeField] private float _speed = 0.65f;

    // Metoda uruchamiana co klatk�
    private void Update()
    {
        // Przesuwa obiekt w lewo z okre�lon� pr�dko�ci�
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
