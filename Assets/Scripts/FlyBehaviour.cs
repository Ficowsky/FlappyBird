using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    // Prywatna zmienna typu float przechowuj�ca pr�dko��
    [SerializeField] private float _velocity = 1.5f;

    // Prywatna zmienna typu float przechowuj�ca pr�dko�� rotacji
    [SerializeField] private float _rotationSpeed = 10f;

    // Prywatna zmienna typu Rigidbody2D przechowuj�ca referencj� do komponentu Rigidbody2D
    private Rigidbody2D _rb;

    // Metoda uruchamiana na pocz�tku dzia�ania skryptu
    private void Start()
    {
        // Pobiera komponent Rigidbody2D przypisany do tego obiektu i przypisuje go do zmiennej _rb
        _rb = GetComponent<Rigidbody2D>();
    }

    // Metoda uruchamiana co klatk�
    private void Update()
    {
        // Sprawdza, czy lewy przycisk myszy zosta� wci�ni�ty w tej klatce
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Ustawia pr�dko�� obiektu w g�r�
            _rb.velocity = Vector2.up * _velocity;
        }
    }

    // Metoda uruchamiana w sta�ych odst�pach czasowych
    private void FixedUpdate()
    {
        // Ustawia rotacj� obiektu na podstawie pr�dko�ci i pr�dko�ci rotacji
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
