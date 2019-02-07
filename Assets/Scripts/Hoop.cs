using UnityEngine;
using UnityEngine.UI;

public class Hoop : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int _score;
    
    [SerializeField] private AudioClip scoreClip;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().useGravity)
        {
            _score++;
            scoreText.text = "Score: " + _score;
            
            _audioSource.PlayOneShot(scoreClip);
        }
    }
}
