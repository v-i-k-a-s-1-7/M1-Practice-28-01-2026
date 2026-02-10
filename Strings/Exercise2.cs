
// PROBLEM 1
// Write a program to convert the given strings into a PigLatin format. If the given
// string is “God is Great”. The PigLatin format is “odGed siay reatGed”. For every
// word in the given string move the first character to the end of the word. If the
// first character is a vowel concatenate “ay” at the end of the word. Otherwise
// concatenate “ed” at the end of the word.


namespace StringExercises
{
    public class PigLatin
    {
        public string convertToPigLatin(string sentence)
        {
            string list = sentence;
            char delimeter = ' ';

            string[] words = list.Split(delimeter);

            string newSentence = "";
            
            foreach(var word in words)
            {
                char firstLetter = ' ';
                string remaining = "";
                string suffix = "";
                for(int i = 0; i< word.Length ; i++)
                {
                   if(i == 0)
                    {
                        firstLetter = word[i];
                        if ("aeiouAEIOU".Contains(firstLetter))
                        {
                            suffix = "ay";
                        }
                        else
                        {
                            suffix = "ed";
                        }
                    }
                    else
                    {
                        remaining += word[i];
                    }
                }

                string newWord = remaining + firstLetter + suffix;
                newSentence += newWord + " ";
            }
            return newSentence.Trim();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PigLatin sentence = new PigLatin();

            string ans = sentence.convertToPigLatin("God is Great");

            Console.WriteLine(ans);
        }
    }
}