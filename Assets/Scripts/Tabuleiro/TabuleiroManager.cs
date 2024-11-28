using UnityEngine;

public class TabuleiroManager : MonoBehaviour
{
    public GameObject cellPrefab; // Prefab da célula
    public Transform[] camadas;  // Referências para as camadas (Camada1, Camada2, Camada3)
    public int numLinhas = 13;   // Número de linhas
    public int numColunas = 13;  // Número de colunas
    public GameObject premioPrefab;

    void Start()
    {
        foreach (Transform camada in camadas)
        {
            GerarTabuleiro(camada);
        }
    }

    void GerarTabuleiro(Transform camada)
    {
        for (int i = 0; i < numLinhas; i++)
        {
            for (int j = 0; j < numColunas; j++)
            {
                GameObject cell = Instantiate(cellPrefab, camada);
                cell.name = $"Cell ({i}, {j})";

                // Adicionar prêmios aleatórios (exemplo: 20% de chance)
                if (Random.value < 0.2f)
                {
                    GameObject premio = Instantiate(premioPrefab, cell.transform);
                    premio.SetActive(false); // Fica oculto inicialmente
                }
            }    
        }
    }
}