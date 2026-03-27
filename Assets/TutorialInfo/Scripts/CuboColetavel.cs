using UnityEngine;

public class CuboColetavel : MonoBehaviour
{
    public int valorDoPonto = 10;
    public Vector3 velocidadeRotacao = new Vector3(15f, 30f, 45f);

    void Update()
    {
        // Faz o cubo girar sozinho
        transform.Rotate(velocidadeRotacao * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Se quem tocou foi o jogador...
        if (other.CompareTag("Player"))
        {
            // Avisa o GameManager para adicionar os pontos
            GameManager.Instance.AdicionarPontos(valorDoPonto);
           
            // Destrói o cubo
            Destroy(gameObject);
        }
    }
}
