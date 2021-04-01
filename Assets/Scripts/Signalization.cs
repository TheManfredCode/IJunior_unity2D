using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exit;

    private AudioSource _audioSource;
    private float _maxVolume = 1;
    private int _volumeChangeRate = 5;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _entered.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _exit.Invoke();
    }

    private void Update()
    {
        if (_audioSource.volume <= 0.1 || _audioSource.volume == 1)
            _volumeChangeRate *= -1;

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, Time.deltaTime / _volumeChangeRate);
    }
}
