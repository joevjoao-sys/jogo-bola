using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Necessário para usar a UI moderna da Unity

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Settings")]
    public TextMeshProUGUI textoPontos;
    public TextMeshProUGUI textoNome;
    public string nomeDoAluno = "Gustavo";

    [Header("Game Rules")]
    public Transform jogador;
    public float alturaDaMorte = -5f; // Altura que o jogador cai antes de reiniciar

    private int pontuacaoAtual = 0;

    void Awake()
    {
        // Garante que só exista um GameManager na fase
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        if (textoNome != null)
            textoNome.text = "Aluno: " + nomeDoAluno;
       
        AtualizarUI();
    }

    void Update()
    {
        // Condição de Derrota: Cair da pista
        if (jogador != null && jogador.position.y < alturaDaMorte)
        {
            ReiniciarFase();
        }
    }

    public void AdicionarPontos(int pontos)
    {
        pontuacaoAtual += pontos;
        AtualizarUI();
    }

    private void AtualizarUI()
    {
        if (textoPontos != null)
            textoPontos.text = "Pontos: " + pontuacaoAtual;
    }

    public void ReiniciarFase()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PassarDeFase()
    {
        int proximaFase = SceneManager.GetActiveScene().buildIndex + 1;
       
        // Verifica se existe uma próxima fase configurada
        if (proximaFase < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proximaFase);
        }
        else
        {
            Debug.Log("Fim de Jogo! Todas as fases concluídas.");
            textoPontos.text = "VOCÊ VENCEU!";
        }
    }
}