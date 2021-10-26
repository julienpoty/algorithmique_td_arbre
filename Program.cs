using System;
using System.Collections.Generic;

namespace Algorithmique
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Arbre a = new() { Id = "A", Parent = null };
            Arbre b = new() { Id = "B", Parent = a };
            Arbre c = new() { Id = "C", Parent = a };
            Arbre d = new() { Id = "D", Parent = a };
            Arbre e = new() { Id = "E", Parent = b };
            Arbre f = new() { Id = "F", Parent = b };
            Arbre g = new() { Id = "G", Parent = d };
            Arbre h = new() { Id = "H", Parent = d };
            Arbre i = new() { Id = "I", Parent = d };
            Arbre j = new() { Id = "J", Parent = e };
            Arbre k = new() { Id = "K", Parent = e };
            Arbre l = new() { Id = "L", Parent = e };
            Arbre m = new() { Id = "M", Parent = g };
            Arbre n = new() { Id = "N", Parent = i };
            Arbre o = new() { Id = "O", Parent = i };
            Arbre p = new() { Id = "P", Parent = m };

            a.Enfants = new List<Arbre>() { b, c, d };
            b.Enfants = new List<Arbre>() { e, f };
            d.Enfants = new List<Arbre>() { g, h, i };
            e.Enfants = new List<Arbre>() { j, k, l };
            g.Enfants = new List<Arbre>() { m };
            i.Enfants = new List<Arbre>() { n, o };
            m.Enfants = new List<Arbre>() { p };

            List<Arbre> resultat = Arbre.BreadthFirstSearch(a);
            foreach(Arbre tree in resultat)
            {
                Console.Write(tree.Id + " ");
            }
            Console.WriteLine();
            List<Arbre> resultatDepthFirst = new();
            Arbre.DepthFirstSearch(a, resultatDepthFirst);
            foreach (Arbre tree in resultatDepthFirst)
            {
                Console.Write(tree.Id + " ");
            }
            Console.WriteLine();
            List<Arbre> resultatSuffixSearch = new();
            Arbre.SuffixSearch(a, resultatSuffixSearch);
            foreach (Arbre tree in resultatSuffixSearch)
            {
                Console.Write(tree.Id + " ");
            }

            Arbre noeud20 = new() { Id = "20", Parent = null };
            Arbre noeud5 = new() { Id = "5", Parent = noeud20 };
            Arbre noeud25 = new() { Id = "25", Parent = noeud20 };
            Arbre noeud3 = new() { Id = "3", Parent = noeud5 };
            Arbre noeud12 = new() { Id = "12", Parent = noeud5 };
            Arbre noeud21 = new() { Id = "21", Parent = noeud25 };
            Arbre noeud28 = new() { Id = "28", Parent = noeud25 };
            Arbre noeud8 = new() { Id = "8", Parent = noeud12 };
            Arbre noeud13 = new() { Id = "13", Parent = noeud12 };
            Arbre noeud6 = new() { Id = "6", Parent = noeud8 };

            noeud20.Enfants = new List<Arbre>() { noeud5, noeud25 };
            noeud5.Enfants = new List<Arbre>() { noeud3, noeud12 };
            noeud25.Enfants = new List<Arbre>() { noeud21, noeud28 };
            noeud12.Enfants = new List<Arbre>() { noeud8, noeud13 };
            noeud8.Enfants = new List<Arbre>() { noeud6 };
            

            Console.WriteLine();
            List<Arbre> resultatInfixeSearch = new();
            Arbre.InfixeSearch(noeud20, resultatInfixeSearch);
            foreach (Arbre tree in resultatInfixeSearch)
            {
                Console.Write(tree.Id + " ");
            }
        }


    }
}
