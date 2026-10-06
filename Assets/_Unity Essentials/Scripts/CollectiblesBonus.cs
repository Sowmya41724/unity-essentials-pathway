using UnityEngine;

public class CollectiblesBonus : MonoBehaviour
{
    public float RotationSpeed;

    public GameObject onCollectEffect;

    // To Play the sound
    public AudioClip collectSound;

    //for counter
    public CollectibleCounter counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (counter == null)
        {
            counter = FindAnyObjectByType<CollectibleCounter>();
        }

        if (counter == null)
        {
            Debug.LogWarning("No CollectibleCounter found in the scene!", this);
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, RotationSpeed, 0);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, 2f);
            }

            if (onCollectEffect != null)
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }

            Destroy(gameObject);

            if (counter != null)
            {
                counter.CollectItem(other.transform.position);
            }

        }
    }
}
