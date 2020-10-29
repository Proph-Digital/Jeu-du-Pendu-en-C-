//Nom du programme : Pendu
//Classe : GameInstance
//Autheur : Proph
//Mise à jour le : 27/10/2020

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Pendu
{
    public class GameInstance
    {
        private int maxErrors { get; set; }
        public List<char> Guesses { get; }
        public List<char> Misses { get; }
        public List<Word> Words { get; }
        public Word WordToGuess { get; }

        private Random rnd;
        private bool isWin { get; set; }
        private string currentWordGuessed;


        //Constructeur GameInstance pour déterminer la liste des mots ainsi que le random
        public GameInstance(int maxError = 10)
        {
            rnd = new Random();
            this.maxErrors = maxError;

            Words = new List<Word>
            {
                new Word("Programmation"),
                new Word("Soleil"),
                new Word("Ordinateur"),
                new Word("Lune"),
                new Word("Siege"),
                new Word("Dormir"),
                new Word("Crayon"),
                new Word("Telephone"),
                new Word("Montre"),
                new Word("Micro"),
                new Word("Table"),
                new Word("Chaise"),
                new Word("Bouche"),
                new Word("Oreille"),
                new Word("Coeur"),
                new Word("Doigt"),
                new Word("Chat"),
                new Word("Chien"),
                new Word("Serpent"),
                new Word("Lion"),
                new Word("Tigre"),
                new Word("Souris"),
                new Word("Sauter")
            };

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine($"Le mot à deviner contient {WordToGuess.Length} lettres");

            currentWordGuessed = PrintWordToGuess();
        }

        public GameInstance(List<Word> words, int maxError = 10)
        {
            rnd = new Random();
            this.maxErrors = maxError;

            Words = words;

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine("Le mot à deviner contient {0} lettres", WordToGuess.Length);

            currentWordGuessed = PrintWordToGuess();
        }


        //Lancement du jeu
        public void Play()
        {
            while(!isWin)
            {
                Console.WriteLine("Donnez moi une lettre : ");
                char letter = char.ToUpper(Console.ReadKey(true).KeyChar);
                int letterIndex = WordToGuess.GetIndexOf(letter);

                Console.WriteLine();

                if(letterIndex != -1)
                {
                    Console.WriteLine($"Bravo, vous avez trouvé la lettre : {letter}");
                    Guesses.Add(letter);
                }
                else
                {
                    Console.WriteLine($"La lettre {letter} ne se trouve pas dans le mot à deviner !");
                    Misses.Add(letter);
                }

                if(Misses.Count > 0) 
                {
                    Console.WriteLine($"Erreurs ({Misses.Count}) : {string.Join(", ", Misses)}");
                }

                currentWordGuessed = PrintWordToGuess();

                if(currentWordGuessed.IndexOf("_") == -1)
                {
                    isWin = true;
                    Console.WriteLine("Félicitation, vous avez gagné !");
                    Console.ReadKey();
                }

                if(Misses.Count >= maxErrors)
                {
                    Console.WriteLine("Vous avez perdu !");
                    Console.ReadKey();
                    break;
                }
            }
        }

        private string PrintWordToGuess()
        {
            string currentWordGuessed = "";

            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if(Guesses.Contains(WordToGuess.Text[i]))
                {
                    currentWordGuessed += WordToGuess.Text[i];
                }
                else
                {
                    currentWordGuessed += "_";
                }
            }

            Console.WriteLine(currentWordGuessed);
            Console.WriteLine();

            return currentWordGuessed;
        }
    }
}
