using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    //[SerializeField] private AudioClip _buttonSound;
    public void OnClick()
    {
        _audioSource.Play();
        Debug.Log("Sonido");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
