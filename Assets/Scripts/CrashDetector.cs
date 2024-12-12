using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadSceneDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed) {
            FindObjectOfType<PlayerController>().DisableController();

            crashEffect.Play();

            GetComponent<AudioSource>().PlayOneShot(crashSFX);

            Invoke("ReloadScene", reloadSceneDelay);

            hasCrashed = true;
        }
    
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
