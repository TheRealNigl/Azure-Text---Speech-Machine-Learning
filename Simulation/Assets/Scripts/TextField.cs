using UnityEngine;
using UnityEngine.UI;

public class TextField : MonoBehaviour
{
    private TextField textField;
    public TextField thisTextField { get => textField; set => textField = value; }

    public Text outputTextField;

    private void Start()
    {
        
    }

    public void SetOutputText(string outputText)
    {
        outputTextField.text = outputText;
    }
}
