//Nom du programme : Pendu
//Classe : Program
//Autheur : Proph
//Mise à jour le : 27/10/2020

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Pendu
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInstance game = new GameInstance();
            game.Play();
        }
    }
}
