using UnityEngine;

public class Rotator : MonoBehaviour 
{
    [Header("Configurações de Movimento")]
    public float velocidadeGiro = 100f;
    public float alturaFlutuacao = 0.5f; 
    public float velocidadeFlutuacao = 2f;

    private Vector3 posicaoInicial;

    void Start()
    {
        // Guarda a posição onde você colocou o cubo no mapa
        posicaoInicial = transform.position;
    }

    void Update() 
    {
        // 1. GIRA (Apenas no eixo Y para ficar reto)
        transform.Rotate(Vector3.up * velocidadeGiro * Time.deltaTime);

        // 2. FLUTUA (Sobe e desce suavemente)
        // Agora os nomes batem certinho com as variáveis lá de cima!
        float novoY = posicaoInicial.y + Mathf.Sin(Time.time * velocidadeFlutuacao) * alturaFlutuacao;
        transform.position = new Vector3(posicaoInicial.x, novoY, posicaoInicial.z);
    }
}