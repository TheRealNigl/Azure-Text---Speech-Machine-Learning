using UnityEngine;

public class MicrophonePress : MonoBehaviour
{
    public int MicrophoneIndex;

    public void ReturnIndex()
    {
        FindObjectOfType<MainMicrophoneLayout>().SetMicrophoneIndex(MicrophoneIndex);
    }
}
