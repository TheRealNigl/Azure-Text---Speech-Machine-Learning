using System.Collections.Generic;

// https://docs.microsoft.com/en-us/azure/cognitive-services/translator/language-support

public static class Languages
{
    // Translate
    // Translator supports the following languages for text to text translation.
    public static Dictionary<string, string> TranslateTextToTextLanguages = new Dictionary<string, string>()
    {
        { "Afrikaans",   "af" },
        { "Arabic",   "ar" },
        {"Assamese", "as" },
        { "Bangla",   "bn" },
        { "Bosnian (Latin)",   "bs" },
        { "Bulgarian",   "bg" },
        { "Catalan",   "ca" },
        { "Chinese Simplified",   "zh-Hans" },
        { "Chinese Simplified",   "zh-Hans" },
        { "Croatian",   "hr" },
        { "Dari", "prs" },
        { "Czech",   "cs" },
        { "Danish",   "da" },
        { "Dutch",   "nl" },
        { "German",   "de" },
        { "Greek",   "el" },
        { "Estonian",   "et" },
        { "Fijian",   "fj" },
        { "Filipino",   "fil" },
        { "Finnish",   "fi" },
        { "French",   "fr" },
        { "German",   "de" },
        { "Greek",   "el" },
        { "Gujarati",   "gu" },
        { "Hebrew",   "he" },
        { "Hindi",   "hi" },
        { "Hungarian",   "hu" },
        { "Icelandic",   "is" },
        { "Indonesian",   "id" },
        { "Irish",   "ga" },
        { "Italian",   "it" },
        { "Japanese",   "ja" },
        { "Klingon",   "tlh" },
        { "Korean",   "ko" },
        { "Latvian",   "lv" },
        { "Lithuanian",   "lt" },
        { "Malay",   "ms" },
        { "Maltese",   "mt" },
        { "Norwegian",   "nb" },
        { "Persian",   "fa" },
        { "Polish",   "pl" },
        { "Portuguese (Brazil)",   "pt-br" },
        { "Punjabi",   "pa" },
        { "Romanian",   "ro" },
        { "Russian",   "ru" },
        { "Serbian (Latin)",   "sr-Latn" },
        { "Slovak",   "sk" },
        { "Slovenian",   "sl" },
        { "Spanish",   "es" },
        { "Swahili",   "sw" },
        { "Swedish",   "sv" },
        { "Tamil",   "ta" },
        { "Thai",   "th" },
        { "Turkish",   "tr" },
        { "Ukrainian",   "uk" },
        { "Urdu",   "ur" },
        { "Vietnamese",   "vi" },
        { "Welsh",   "cy" }
    };

    // Detect
    // Translator detects the following languages for translation and transliteration.
    public static Dictionary<string, string> DetectsSpeechLanguages = new Dictionary<string, string>()
    {
        { "Afrikaans",   "af" },
        { "Arabic",   "ar" },
        { "Bangla",   "bn" },
        { "Bosnian (Latin)",   "bs" },
        { "Bulgarian",   "bg" },
        { "Catalan",   "ca" },
        { "Chinese Simplified",   "zh-Hans" },
        { "Croatian",   "hr" },
        { "Czech",   "cs" },
        { "Danish",   "da" },
        { "Dutch",   "nl" },
        { "German",   "de" },
        { "Greek",   "el" },
        { "Estonian",   "et" },
        { "Fijian",   "fj" },
        { "Filipino",   "fil" },
        { "Finnish",   "fi" },
        { "French",   "fr" },
        { "German",   "de" },
        { "Greek",   "el" },
        { "Gujarati",   "gu" },
        { "Hebrew",   "he" },
        { "Hindi",   "hi" },
        { "Hungarian",   "hu" },
        { "Icelandic",   "is" },
        { "Indonesian",   "id" },
        { "Irish",   "ga" },
        { "Italian",   "it" },
        { "Japanese",   "ja" },
        { "Klingon",   "tlh" },
        { "Korean",   "ko" },
        { "Latvian",   "lv" },
        { "Lithuanian",   "lt" },
        { "Malay",   "ms" },
        { "Maltese",   "mt" },
        { "Norwegian",   "nb" },
        { "Persian",   "fa" },
        { "Polish",   "pl" },
        { "Portuguese (Brazil)",   "pt-br" },
        { "Punjabi",   "pa" },
        { "Romanian",   "ro" },
        { "Russian",   "ru" },
        { "Serbian (Latin)",   "sr-Latn" },
        { "Slovak",   "sk" },
        { "Slovenian",   "sl" },
        { "Spanish",   "es" },
        { "Swahili",   "sw" },
        { "Swedish",   "sv" },
        { "Tamil",   "ta" },
        { "Thai",   "th" },
        { "Turkish",   "tr" },
        { "Ukrainian",   "uk" },
        { "Urdu",   "ur" },
        { "Vietnamese",   "vi" },
        { "Welsh",   "cy" }
    };

    //There is a transliterate section - TO DO

    //Transliterate
    //The Transliterate method supports the following languages.
    //In the "To/From", "<-->" indicates that the language can be transliterated from or to either of the scripts listed.
    //The "-->" indicates that the language can only be transliterated from one script to the other.

    //





    // Dictionary
    // The dictionary supports the following languages to or from English using the Lookup and Examples methods.

    // Detect
    // Translator detects the following languages for translation and transliteration.
    public static Dictionary<string, string> DictionarySpeechLanguages = new Dictionary<string, string>()
    {
        { "Afrikaans",   "af" },
        { "Arabic",   "ar" },
        { "Bangla",   "bn" },
        { "Bosnian (Latin)",   "bs" },
        { "Bulgarian",   "bg" },
        { "Catalan",   "ca" },
        { "Chinese Simplified",   "zh-Hans" },
        { "Croatian",   "hr" },
        { "Czech",   "cs" },
        { "Danish",   "da" },
        { "Dutch",   "nl" },
        { "Estonian",   "et" },
        { "Finnish",   "fi" },
        { "French",   "fr" },
        { "German",   "de" },
        { "Greek",   "el" },
        { "Haitian Creole",   "ht" },
        { "Hebrew",   "he" },
        { "Hindi",   "hi" },
        { "Hungarian",   "hu" },
        { "Icelandic",   "is" },
        { "Indonesian",   "id" },
        { "Irish",   "ga" },
        { "Italian",   "it" },
        { "Japanese",   "ja" },
        { "Klingon",   "tlh" },
        { "Korean",   "ko" },
        { "Latvian",   "lv" },
        { "Lithuanian",   "lt" },
        { "Malay",   "ms" },
        { "Maltese",   "mt" },
        { "Norwegian",   "nb" },
        { "Persian",   "fa" },
        { "Polish",   "pl" },
        { "Portuguese (Brazil)",   "pt-br" },
        { "Punjabi",   "pa" },
        { "Romanian",   "ro" },
        { "Russian",   "ru" },
        { "Serbian (Latin)",   "sr-Latn" },
        { "Slovak",   "sk" },
        { "Slovenian",   "sl" },
        { "Spanish",   "es" },
        { "Swahili",   "sw" },
        { "Swedish",   "sv" },
        { "Tamil",   "ta" },
        { "Thai",   "th" },
        { "Turkish",   "tr" },
        { "Ukrainian",   "uk" },
        { "Urdu",   "ur" },
        { "Vietnamese",   "vi" },
        { "Welsh",   "cy" }
    };

    // Access the Translator language list programmatically

    // You can retrieve a list of supported languages for Translator using the Languages method.
    // You can view the list by feature, language code, as well as the language name in English or any other supported language. 
    // This list is automatically updated by the Microsoft Translator service as new languages are made available.

    // Customization
    // The following languages are available for customization to or from English using Custom Translator.

    // The Key is the language
    // The vlaue is the language code
    public static Dictionary<string, string> CustomizationSpeechLanguages = new Dictionary<string, string>()
    {
        { "Afrikaans",   "af" },
        { "Arabic",   "ar" },
        { "Bangla",   "bn" },
        { "Bosnian (Latin)",   "bs" },
        { "Bulgarian",   "bg" },
        { "Catalan",   "ca" },
        { "Chinese Simplified",   "zh-Hans" },
        { "Chinese Traditional",   "zh-Hant" },
        { "Croatian",   "hr" },
        { "Czech",   "cs" },
        { "Danish",   "da" },
        { "Dutch",   "nl" },
        { "English",   "en" },
        { "Estonian",   "et" },
        { "Fijian",   "fj" },
        { "Filipino",   "fil" },
        { "Finnish",   "fi" },
        { "French",   "fr" },
        { "German",   "de" },
        { "Greek",   "el" },
        { "Gujarati",   "gu" },
        { "Hebrew",   "he" },
        { "Hindi",   "hi" },
        { "Hungarian",   "hu" },
        { "Icelandic",   "is" },
        { "Indonesian",   "id" },
        { "Irish",   "ga" },
        { "Italian",   "it" },
        { "Japanese",   "ja" },
        { "Kannada",   "kn" },
        { "Korean",   "ko" },
        { "Latvian",   "lv" },
        { "Lithuanian",   "lt" },
        { "Malagasy",   "mg" },
        { "Malay",   "ms" },
        { "Maltese",   "mt" },
        { "Maori",   "mi" },
        { "Marathi",   "mr" },
        { "Norwegian",   "nb" },
        { "Persian",   "fa" },
        { "Polish",   "pl" },
        { "Portuguese (Brazil)",   "pt-br" },
        { "Punjabi",   "pa" },
        { "Romanian",   "ro" },
        { "Russian",   "ru" },
        { "Samoan",   "sm" },
        { "Serbian (Latin)",   "sr-Latn" },
        { "Slovak",   "sk" },
        { "Slovenian",   "sl" },
        { "Spanish",   "es" },
        { "Swahili",   "sw" },
        { "Swedish",   "sv" },
        { "Tahitian",   "ty" },
        { "Thai",   "th" },
        { "Tongan",   "to" },
        { "Turkish",   "tr" },
        { "Ukrainian",   "uk" },
        { "Urdu",   "ur" },
        { "Vietnamese",   "vi" },
        { "Welsh",   "cy" }
    };

#region Speech Translation

    // Speech Translation
    // Speech Translation is available by using Translator with Cognitive Services Speech service.View Speech Service documentation to learn more about using speech translation and to view all of the available language options.

    // Speech-to-text
    // Convert speech into text in order to translate to the text language of your choice.Speech-to-text is used for speech to text translation, or for speech-to-speech translation when used in conjunction with speech synthesis.
    public static string[] SpeechToTextLanguages = new string[]
    {
        "Arabic",
        "Cantonese (Traditional)",
        "Catalan",
        "Chinese Simplified",
        "Chinese Traditional",
        "Danish",
        "Dutch",
        "English",
        "Finnish",
        "French",
        "French (Canada)",
        "German",
        "Gujarati",
        "Hindi",
        "Italian",
        "Japanese",
        "Korean",
        "Marathi",
        "Norwegian",
        "Polish",
        "Portuguese (Brazil)",
        "Portuguese (Portugal)",
        "Russian",
        "Spanish",
        "Swedish",
        "Tamil",
        "Telugu",
        "Thai",
        "Turkish"
    };

    // Text to speech
    // Translator detects the following languages for translation and transliteration.
    public static string[] TextToSpeechLanguages = new string[]
    {
        "Arabic",
        "Bulgarian",
        "Cantonese(Traditional)",
        "Catalan",
        "Chinese Simplified",
        "Chinese Traditional",
        "Croatian",
        "Czech",
        "Danish",
        "Dutch",
        "English",
        "Finnish",
        "French",
        "French(Canada)",
        "German",
        "Greek",
        "Hebrew",
        "Hindi",
        "Hungarian",
        "Indonesian",
        "Italian",
        "Japanese",
        "Korean",
        "Malay",
        "Norwegian",
        "Polish",
        "Portuguese(Brazil)",
        "Portuguese(Portugal)",
        "Romanian",
        "Russian",
        "Slovak",
        "Slovenian",
        "Spanish",
        "Swedish",
        "Tamil",
        "Telugu",
        "Thai",
        "Turkish",
        "Vietnamese"
    };
    #endregion
}
