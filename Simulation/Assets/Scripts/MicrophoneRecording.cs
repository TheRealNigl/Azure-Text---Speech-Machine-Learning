using System.Collections;
using UnityEngine;

public class MicrophoneRecording : MonoBehaviour
{
    /// <summary>
    /// The audio clip recorded from the microphone.
    /// </summary>
    private AudioClip audioClip = null;
    public AudioClip AudioClip
    {
        get
        {
            return audioClip;
        }
    }

    /// <summary>
    /// Microphone name to record with.
    /// </summary>
    private static string microphoneName = "Built-in Microphone";
    public static string MicrophoneName
    {
        get
        {
            return microphoneName;
        }

        set
        {
            microphoneName = value;
        }
    }

    private string spokeLanguage = "en-US";

    private string translateLanguage = "it-IT";

    private static AudioSource audioSource;

    private void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Record()
    {
        audioClip = Microphone.Start(MicrophoneName, true, 10, 44100);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Stop()
    {
        Microphone.End(MicrophoneName);
        AzureAPICallbacks();
    }

    private void AzureAPICallbacks()
    {
        AzureGetPullRestAPI.SetUpAudioConfiguration();
        //AzureGetPullRestAPI.Listen();
        AzureGetPullRestAPI.SetUpLanguageInterpretation(spokeLanguage, translateLanguage);
        AzureGetPullRestAPI.Translate();
        //AzureGetPullRestAPI.Speak();
    }

    public void Play()
    {
        AzureGetPullRestAPI.WAV(AzureGetPullRestAPI.audioData);
        int sampeCount = AzureGetPullRestAPI.SampleCount;
        int frequency = AzureGetPullRestAPI.Frequency;
        audioClip = AudioClip.Create("soundLenny-Result", sampeCount, 1, frequency, false);
        audioClip.SetData(AzureGetPullRestAPI.LeftChannel, 0);

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
