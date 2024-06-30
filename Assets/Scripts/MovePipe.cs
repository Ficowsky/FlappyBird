using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    // Prywatna zmienna typu float przechowuj¹ca prêdkoœæ ruchu
    [SerializeField] private float _speed = 0.65f;

    // Metoda uruchamiana co klatkê
    private void Update()
    {
        // Przesuwa obiekt w lewo z okreœlon¹ prêdkoœci¹
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
