using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    // Prywatna zmienna typu float przechowuj¹ca prêdkoœæ
    [SerializeField] private float _velocity = 1.5f;

    // Prywatna zmienna typu float przechowuj¹ca prêdkoœæ rotacji
    [SerializeField] private float _rotationSpeed = 10f;

    // Prywatna zmienna typu Rigidbody2D przechowuj¹ca referencjê do komponentu Rigidbody2D
    private Rigidbody2D _rb;

    // Metoda uruchamiana na pocz¹tku dzia³ania skryptu
    private void Start()
    {
        // Pobiera komponent Rigidbody2D przypisany do tego obiektu i przypisuje go do zmiennej _rb
        _rb = GetComponent<Rigidbody2D>();
    }

    // Metoda uruchamiana co klatkê
    private void Update()
    {
        // Sprawdza, czy lewy przycisk myszy zosta³ wciœniêty w tej klatce
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Ustawia prêdkoœæ obiektu w górê
            _rb.velocity = Vector2.up * _velocity;
        }
    }

    // Metoda uruchamiana w sta³ych odstêpach czasowych
    private void FixedUpdate()
    {
        // Ustawia rotacjê obiektu na podstawie prêdkoœci i prêdkoœci rotacji
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
