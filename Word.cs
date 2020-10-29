//Nom du programme : Pendu
//Classe : Word
//Autheur : Proph
//Mise à jour le : 27/10/2020

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Pendu
{
    public class Word
    {
        public string Text { get; set; }
        public int Length { get; }

        public Word(string text)
        {
            Text = text.ToUpper();
            Length = text.Length;
        }
        public int GetIndexOf(char letter)
        {
            return Text.IndexOf(letter);
        }
    }
}
