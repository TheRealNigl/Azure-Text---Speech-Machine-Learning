using UnityEngine;
using Microsoft.CognitiveServices.Speech;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech.Audio;
using System.IO;
using Microsoft.CognitiveServices.Speech.Translation;
using System;

public class AzureGetPullRestAPI : MonoBehaviour
{
    // The key to the cloud service resource
    private static string authenticationKey = "";
    // The region in to the cloud service resource
    private static string authenticationRegion = "";

    // Cognitive services captured Audio Configuration set up through Unity's application
    private static AudioConfig audioConfig;

    /// <summary>
    /// 
    /// </summary>
    private static string SpokenLanguage;

    private static string TargetTranslatedLanguage;

    private static string translatedText;

    /// <summary>
    /// 
    /// </summary>
    public async static void Listen()
    {
        await Task.Run(SpeechRecognitionAsync);
    }

    public async static void Translate()
    {
        await Task.Run(TranslationContinuousAsync);
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SetUpAudioConfiguration()
    {
        ExportClipData(FindObjectOfType<MicrophoneRecording>().AudioClip);
        audioConfig = AudioConfig.FromWavFileInput(path);
    }

    public static void SetUpLanguageInterpretation(string spokenLanguage, string targetTranslatedLanguage)
    {
        SpokenLanguage = spokenLanguage;
        TargetTranslatedLanguage = targetTranslatedLanguage;
    }

    public async static void Speak()
    {
        await Task.Run(SpeakContinousAsync);
    }

    public static byte[] audioData;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private async static Task SpeechRecognitionAsync()
    {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        var config = SpeechConfig.FromSubscription(authenticationKey, authenticationRegion);

        // Creates a speech recognizer from microphone.
        using (var recognizer = new SpeechRecognizer(config, audioConfig))
        {
            // Subscribes to events.
            recognizer.Recognizing += (s, e) => {
                Debug.Log($"RECOGNIZING: Text={e.Result.Text}");
            };

            recognizer.Recognized += (s, e) => {
                var result = e.Result;
                Debug.Log($"Reason: {result.Reason.ToString()}");
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Debug.Log($"Final result: Text: {result.Text}.");
                }
            };

            recognizer.Canceled += (s, e) => {
                Debug.Log($"\n    Recognition Canceled. Reason: {e.Reason.ToString()}, CanceledReason: {e.Reason}");
            };

            recognizer.SessionStarted += (s, e) => {
                Debug.Log("\n    Session started event.");
            };

            recognizer.SessionStopped += (s, e) => {
                Debug.Log("\n    Session stopped event.");
            };

            
            // Allows for continuous speech recgonition
            /*
            // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
            await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

            do
            {
                Debug.Log("Cloud service requsted.");
            } while (enterPressed);

            // Stops recognition.
            await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
            */

            // Allows for speech recognition once
            // Recognize once
            await recognizer.RecognizeOnceAsync().ConfigureAwait(false);
        }
    }

    private async static Task TranslationContinuousAsync()
    {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        var config = SpeechTranslationConfig.FromSubscription(authenticationKey, authenticationRegion);
        config.SpeechSynthesisLanguage = SpokenLanguage;
        config.SpeechRecognitionLanguage = TargetTranslatedLanguage;
        config.AddTargetLanguage("de");

        // Creates a speech recognizer from microphone.
        using (var recognizer = new TranslationRecognizer(config, audioConfig))
        {
            // Subscribes to events.
            recognizer.Recognizing += (s, e) => {
                Debug.Log($"RECOGNIZING: Text={e.Result.Text}");
            };

            recognizer.Recognized += async (s, e) => {
                var result = e.Result;
                Debug.Log($"Reason: {result.Reason.ToString()}");
                if (result.Reason == ResultReason.TranslatedSpeech)
                {
                    translatedText = e.Result.Text;
                    Debug.Log($"Final result: Text: {result.Text}.");
                    await SpeakContinousAsync().ConfigureAwait(false);
                }
            };

            recognizer.Canceled += (s, e) => {
                Debug.Log($"\n    Recognition Canceled. Reason: {e.Reason.ToString()}, CanceledReason: {e.Reason}, Error Code: { e.ErrorCode}, Error Details: {e.ErrorDetails} ");
            };

            recognizer.SessionStarted += (s, e) => {
                Debug.Log("\n    Session started event.");
            };

            recognizer.SessionStopped += (s, e) => {
                Debug.Log("\n    Session stopped event.");
            };


            // Allows for continuous speech recgonition
            /*
            // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
            await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

            do
            {
                Debug.Log("Cloud service requsted.");
            } while (enterPressed);

            // Stops recognition.
            await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
            */

            // Allows for speech recognition once
            // Recognize once
            await recognizer.RecognizeOnceAsync().ConfigureAwait(false);
        }
    }

    static AudioClip audioClip;

    private async static Task SpeakContinousAsync()
    {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        var config = SpeechConfig.FromSubscription(authenticationKey, authenticationRegion);
        config.SpeechSynthesisLanguage = TargetTranslatedLanguage;
        config.SpeechRecognitionLanguage = SpokenLanguage;

        // Creates a speech recognizer from microphone.
        using (var recognizer = new SpeechSynthesizer(config, audioConfig))
        {
            // Subscribes to events.
            recognizer.Synthesizing += (s, e) => {
                Debug.Log($"RECOGNIZING: Text={e.Result.AudioData.ToString()}");
            };

            recognizer.SynthesisCompleted += (s, e) => {
                var result = e.Result;
                Debug.Log($"Reason: {result.Reason.ToString()}");
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    Debug.Log($"Final result: Text: {result.AudioData.ToString()}.");
                    audioData = result.AudioData;
                    WAV(audioData);
                }
            };

            recognizer.SynthesisCanceled += (s, e) => {
                Debug.Log($"\n    Recognition Canceled. Reason: {e.Result.ToString()}, CanceledReason: {e.Result}");
            };

            recognizer.SynthesisStarted += (s, e) => {
                Debug.Log("\n    Session started event.");
            };

            recognizer.SynthesisCanceled += (s, e) => {
                Debug.Log("\n    Session stopped event.");
            };


            // Allows for continuous speech recgonition
            /*
            // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
            await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

            do
            {
                Debug.Log("Cloud service requsted.");
            } while (enterPressed);

            // Stops recognition.
            await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
            */

            // Allows for speech recognition once
            // Recognize once
            await recognizer.SpeakTextAsync(translatedText).ConfigureAwait(false);
        }        
    }

    ///--------------------------------------------------------------------------------------------------------------------------------
    /// The below functionality is brought from the below reference:
    /// https://stackoverflow.com/questions/50864146/create-a-wav-file-from-unity-audioclip

    static string path;

    static void ExportClipData(AudioClip clip)
    {
        var data = new float[clip.samples * clip.channels];
        clip.GetData(data, 0);
        if(!string.IsNullOrEmpty(Path.Combine(Application.persistentDataPath, "Recording.wav")))
        {
            File.Delete(Path.Combine(Application.persistentDataPath, "Recording.wav"));
        }
        path = Path.Combine(Application.persistentDataPath, "Recording.wav");
        using (var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
        {
            // The following values are based on http://soundfile.sapp.org/doc/WaveFormat/
            var bitsPerSample = (ushort)16;
            var chunkID = "RIFF";
            var format = "WAVE";
            var subChunk1ID = "fmt ";
            var subChunk1Size = (uint)16;
            var audioFormat = (ushort)1;
            var numChannels = (ushort)clip.channels;
            var sampleRate = (uint)clip.frequency;
            var byteRate = (uint)(sampleRate * clip.channels * bitsPerSample / 8);  // SampleRate * NumChannels * BitsPerSample/8
            var blockAlign = (ushort)(numChannels * bitsPerSample / 8); // NumChannels * BitsPerSample/8
            var subChunk2ID = "data";
            var subChunk2Size = (uint)(data.Length * clip.channels * bitsPerSample / 8); // NumSamples * NumChannels * BitsPerSample/8
            var chunkSize = (uint)(36 + subChunk2Size); // 36 + SubChunk2Size
                                                        // Start writing the file.
            WriteString(stream, chunkID);
            WriteInteger(stream, chunkSize);
            WriteString(stream, format);
            WriteString(stream, subChunk1ID);
            WriteInteger(stream, subChunk1Size);
            WriteShort(stream, audioFormat);
            WriteShort(stream, numChannels);
            WriteInteger(stream, sampleRate);
            WriteInteger(stream, byteRate);
            WriteShort(stream, blockAlign);
            WriteShort(stream, bitsPerSample);
            WriteString(stream, subChunk2ID);
            WriteInteger(stream, subChunk2Size);
            foreach (var sample in data)
            {
                // De-normalize the samples to 16 bits.
                var deNormalizedSample = (short)0;
                if (sample > 0)
                {
                    var temp = sample * short.MaxValue;
                    if (temp > short.MaxValue)
                        temp = short.MaxValue;
                    deNormalizedSample = (short)temp;
                }
                if (sample < 0)
                {
                    var temp = sample * (-short.MinValue);
                    if (temp < short.MinValue)
                        temp = short.MinValue;
                    deNormalizedSample = (short)temp;
                }
                WriteShort(stream, (ushort)deNormalizedSample);
            }
        }
    }

    static void WriteString(Stream stream, string value)
    {
        foreach (var character in value)
            stream.WriteByte((byte)character);
    }

    static void WriteInteger(Stream stream, uint value)
    {
        stream.WriteByte((byte)(value & 0xFF));
        stream.WriteByte((byte)((value >> 8) & 0xFF));
        stream.WriteByte((byte)((value >> 16) & 0xFF));
        stream.WriteByte((byte)((value >> 24) & 0xFF));
    }

    static void WriteShort(Stream stream, ushort value)
    {
        stream.WriteByte((byte)(value & 0xFF));
        stream.WriteByte((byte)((value >> 8) & 0xFF));
    }

    // Byte[] to audio clip reference: https://stackoverflow.com/questions/16078254/create-audioclip-from-byte

    static float[] ConvertByteToFloat(byte[] array)
    {
        float[] floatArr = new float[array.Length / 4];
        for (int i = 0; i < floatArr.Length; i++)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array, i * 4, 4);
            floatArr[i] = BitConverter.ToSingle(array, i * 4) / 0x80000000;
        }
        return floatArr;
    }


    ///
    /// https://stackoverflow.com/questions/56031669/unity-some-noise-in-audio-after-convert-byte-to-audioclip
    ///


    // properties

    public static float[] LeftChannel { get; internal set; }
    public static float[] RightChannel { get; internal set; }
    public static int ChannelCount { get; internal set; }
    public static int SampleCount { get; internal set; }
    public static int Frequency { get; internal set; }

    // convert two bytes to one float in the range -1 to 1

    static float bytesToFloat(byte firstByte, byte secondByte)
    {
        // convert two bytes to one short (little endian)
        short s = (short)((secondByte << 8) | firstByte);
        // convert to range from -1 to (just below) 1
        return s / 32768.0F;
    }

    static int bytesToInt(byte[] bytes, int offset = 0)
    {
        int value = 0;
        for (int i = 0; i < 4; i++)
        {
            value |= ((int)bytes[offset + i]) << (i * 8);
        }
        return value;
    }

    private static byte[] GetBytes(string filename)
    {
        return File.ReadAllBytes(filename);
    }
    public static void WAV(byte[] wav)
    {
        // Determine if mono or stereo
        ChannelCount = wav[22];     // Forget byte 23 as 99.999% of WAVs are 1 or 2 channels

        // Get the frequency
        Frequency = bytesToInt(wav, 24);

        // Get past all the other sub chunks to get to the data subchunk:
        int pos = 12;   // First Subchunk ID from 12 to 16

        // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
        while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
        {
            pos += 4;
            int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
            pos += 4 + chunkSize;
        }
        pos += 8;

        // Pos is now positioned to start of actual sound data.
        SampleCount = (wav.Length - pos) / 2;     // 2 bytes per sample (16 bit sound mono)
        if (ChannelCount == 2) SampleCount /= 2;        // 4 bytes per sample (16 bit stereo)

        // Allocate memory (right will be null if only mono sound)
        LeftChannel = new float[SampleCount];
        if (ChannelCount == 2) RightChannel = new float[SampleCount];
        else RightChannel = null;

        // Write to double array/s:
        int i = 0;
        while (pos < wav.Length)
        {
            LeftChannel[i] = bytesToFloat(wav[pos], wav[pos + 1]);
            pos += 2;
            if (ChannelCount == 2)
            {
                RightChannel[i] = bytesToFloat(wav[pos], wav[pos + 1]);
                pos += 2;
            }
            i++;
        }
    }
    public override string ToString()
    {
        return string.Format("[WAV: LeftChannel={0}, RightChannel={1}, ChannelCount={2}, SampleCount={3}, Frequency={4}]", LeftChannel, RightChannel, ChannelCount, SampleCount, Frequency);
    }
}