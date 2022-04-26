using UnityEngine;
using UnityEngine.UI;

public class MainMicrophoneLayout : MonoBehaviour
{
    /// <summary>
    /// The parent used to spawn the microphone buttons for the player to choose their microphone to record from.
    /// Also, setting the generic button for each microphone.
    /// </summary>
    [SerializeField]
    private Transform CanvasParent = null;
    [SerializeField]
    private GameObject prefabedMicrophoneButton = null;
    private GameObject[] prefabedMicrophoneButtons = { };
    private string[] microphoneNames = { string.Empty };
    public GameObject recordingButtons = null;

    private void Awake()
    {
        SetButtonsActive(true);
    }

    public void SetMicrophoneIndex(int index)
    {
        MicrophoneRecording.MicrophoneName = Microphone.devices[index];
        SetButtonsActive(false);
    }

    private void CreateButtons()
    {
        if(Microphone.devices.Length > 0)
        {
            int count = 0;

            microphoneNames = Microphone.devices;
            prefabedMicrophoneButtons = new GameObject[microphoneNames.Length];
            foreach (string microphoneName in microphoneNames)
            {
                prefabedMicrophoneButtons[count] = Instantiate(prefabedMicrophoneButton, CanvasParent);
                prefabedMicrophoneButtons[count].GetComponent<MicrophonePress>().MicrophoneIndex = count;
                prefabedMicrophoneButtons[count].GetComponent<Button>().onClick.AddListener(prefabedMicrophoneButton.GetComponent<MicrophonePress>().ReturnIndex);
                prefabedMicrophoneButtons[count].GetComponentInChildren<Text>().text = Microphone.devices[count].ToString();
                count++;
            }
        }
    }

    public void SetButtonsActive(bool visible)
    {
        CreateButtons();

        int count = 0;

        recordingButtons.gameObject.SetActive(!visible);

        if(prefabedMicrophoneButtons != null || prefabedMicrophoneButtons.Length > 0)
        {
            for (int microPhoneCount = 0; microPhoneCount < prefabedMicrophoneButtons.Length; microPhoneCount++)
            {
                string microphoneName = Microphone.devices[microPhoneCount];
                if (microphoneName != null || microphoneName != string.Empty)
                {
                    prefabedMicrophoneButtons[count].SetActive(visible);
                    count++;
                }
            }
        }
    }
}
