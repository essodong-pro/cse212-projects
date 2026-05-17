using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));   // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// For example, in an English to German dictionary:
    /// myTranslator.AddWord("book","buch")
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        // Use indexer assignment so existing words are updated if re-added
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the fromWord into the word stored as the translation
    /// </summary>
    public string Translate(string fromWord)
    {
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }
        else
        {
            return "???";
        }
    }
}
