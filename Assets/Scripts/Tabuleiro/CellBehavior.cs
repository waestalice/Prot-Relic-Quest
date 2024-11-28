using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    private int currentLayer = 0; // Camada atual da c�lula
    private UnityEngine.UI.Button cellButton; // Refer�ncia ao bot�o (explicitamente do UI)
    public Color[] layerColors; // Array de cores para cada camada

    private void Start()
    {
        // Obt�m a refer�ncia ao bot�o e configura o evento de clique
        cellButton = GetComponent<UnityEngine.UI.Button>();
        if (cellButton != null)
        {
            cellButton.onClick.AddListener(OnCellClicked);
        }

        // Configura a cor inicial da c�lula (primeira camada)
        UpdateCellColor();
    }

    private void OnCellClicked()
    {
        Debug.Log($"C�lula clicada: {gameObject.name}, camada atual: {currentLayer}");

        // Avan�a para a pr�xima camada
        currentLayer++;

        // Verifica se ainda h� camadas restantes
        if (currentLayer < layerColors.Length)
        {
            UpdateCellColor(); // Atualiza a cor da c�lula
        }
        else
        {
            Debug.Log("Todas as camadas foram reveladas! Destruindo c�lula.");

            GetComponent<Image>().color = Color.red;

            // Remove o evento de clique para evitar erros ao destruir
            if (cellButton != null)
            {
                cellButton.onClick.RemoveAllListeners();
                cellButton.interactable = false;
            }

            // Verifica se o objeto est� na cena antes de tentar destru�-lo
            if (gameObject.scene.IsValid())
            {
                Destroy(gameObject);
                Debug.Log("C�lula destru�da.");
            }
            else
            {
                Debug.LogError("Tentativa de destruir um objeto que n�o est� na cena.");
            }
        }
    }

    private void UpdateCellColor()
    {
        if (currentLayer < layerColors.Length)
        {
            // Atualiza a cor da c�lula com base na camada atual
            GetComponent<Image>().color = layerColors[currentLayer];
        }
    }
}
