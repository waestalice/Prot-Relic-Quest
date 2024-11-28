using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    private int currentLayer = 0; // Camada atual da célula
    private UnityEngine.UI.Button cellButton; // Referência ao botão (explicitamente do UI)
    public Color[] layerColors; // Array de cores para cada camada

    private void Start()
    {
        // Obtém a referência ao botão e configura o evento de clique
        cellButton = GetComponent<UnityEngine.UI.Button>();
        if (cellButton != null)
        {
            cellButton.onClick.AddListener(OnCellClicked);
        }

        // Configura a cor inicial da célula (primeira camada)
        UpdateCellColor();
    }

    private void OnCellClicked()
    {
        Debug.Log($"Célula clicada: {gameObject.name}, camada atual: {currentLayer}");

        // Avança para a próxima camada
        currentLayer++;

        // Verifica se ainda há camadas restantes
        if (currentLayer < layerColors.Length)
        {
            UpdateCellColor(); // Atualiza a cor da célula
        }
        else
        {
            Debug.Log("Todas as camadas foram reveladas! Destruindo célula.");

            GetComponent<Image>().color = Color.red;

            // Remove o evento de clique para evitar erros ao destruir
            if (cellButton != null)
            {
                cellButton.onClick.RemoveAllListeners();
                cellButton.interactable = false;
            }

            // Verifica se o objeto está na cena antes de tentar destruí-lo
            if (gameObject.scene.IsValid())
            {
                Destroy(gameObject);
                Debug.Log("Célula destruída.");
            }
            else
            {
                Debug.LogError("Tentativa de destruir um objeto que não está na cena.");
            }
        }
    }

    private void UpdateCellColor()
    {
        if (currentLayer < layerColors.Length)
        {
            // Atualiza a cor da célula com base na camada atual
            GetComponent<Image>().color = layerColors[currentLayer];
        }
    }
}
