using UnityEngine;

public class LinhaDeChegada : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PassarDeFase();
        }
    }
}