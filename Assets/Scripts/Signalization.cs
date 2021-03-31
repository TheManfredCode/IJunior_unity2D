using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signalization : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exit;
    private AudioSource _audioSource;
    private bool _isInHouse = false;
    private bool _isDescending = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Debug.Log(_audioSource.volume);
        _audioSource.volume = 0.1f;
        Debug.Log(_audioSource.volume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _entered.Invoke();
            _isInHouse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _exit.Invoke();
            _isInHouse = false;
        }
    }

    private void Update()
    {
        if (_isDescending == false && _isInHouse)
        {
            _audioSource.volume += Time.deltaTime / 5;
            _isDescending = _audioSource.volume == 1;
        }
        else if (_isDescending && _isInHouse)
        {
            _audioSource.volume -= Time.deltaTime / 5;
            _isDescending = _audioSource.volume > 0.1;
        }
    }
}
