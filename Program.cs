using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithmique
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercices_TD_1();

            Exercices_TD_3();

            Exercices_TD_4();
        }

        static void Exercices_TD_1()
        {
            Console.WriteLine("Exercices TD1");
            Console.WriteLine();
            Console.WriteLine();

            ///Exercice 1

            // 4) Implémentation de l'arbre de l'exercice 1

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


            ///Exercice 2

            // 1) Parcours en largeur, en profondeur préfixe et en profondeur suffixe 
            // de l'arbre de l'exercice 1

            Console.WriteLine("Arbre de l'exercice 1");
            Console.WriteLine();

            List<Arbre> BreathFirstArbre1 = Arbre.BreadthFirstSearch(a);
            RenderArbreList("Parcours en largeur:", BreathFirstArbre1);

            List<Arbre> DepthFirstArbre1 = Arbre.DepthFirstSearch(a);
            RenderArbreList("Parcours en profondeur préfixe:", DepthFirstArbre1);

            List<Arbre> SuffixSearchArbre1 = Arbre.SuffixSearch(a);
            RenderArbreList("Parcours en profondeur suffixe:", SuffixSearchArbre1);

            //L'arbre de l'exercice 1 n'étant pas un arbre binaire, il n'est pas possible
            //de lui appliquer un parcours en profondeur infixe


            // 2) Implémentation de l'arbre de l'exercice 2, puis 

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
            Console.WriteLine();
            Console.WriteLine("Arbre de l'exercice 2");
            Console.WriteLine();

            List<Arbre> BreathFirstArbre2 = Arbre.BreadthFirstSearch(noeud20);
            RenderArbreList("Parcours en largeur:", BreathFirstArbre2);

            List<Arbre> DepthFirstArbre2 = Arbre.DepthFirstSearch(noeud20);
            RenderArbreList("Parcours en profondeur préfixe:", DepthFirstArbre2);

            List<Arbre> SuffixSearchArbre2 = Arbre.SuffixSearch(noeud20);
            RenderArbreList("Parcours en profondeur suffixe:", SuffixSearchArbre2);

            List<Arbre> InfixeSearchArbre2 = Arbre.InfixeSearch(noeud20);
            RenderArbreList("Parcours en profondeur infixe:", InfixeSearchArbre2);
        }

        static void Exercices_TD_3()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exercices TD3");
            Console.WriteLine();
            Console.WriteLine();

            ///Exercice 1

            // 4) Instanciation de l'arbre de l'exercice 1 puis parcours en profondeur infixe

            Console.WriteLine("Arbre binaire de recherche de l'exercice 1");
            Console.WriteLine();

            List<int> listeDeNoeuds = new() { 20, 5, 25, 3, 12, 19, 21, 28, 8, 13, 50, 6 };

            ArbreBinaireDeRecherche arbreBinaireDeRecherche = new(listeDeNoeuds);
            List<Arbre> resultatInfixeSearch = arbreBinaireDeRecherche.InfixeSearch();

            RenderArbreList("Parcours en profondeur infixe :", resultatInfixeSearch, true);


            ///Exercice 2

            // 1) Instanciation de l'arbre de l'exercice 2 puis parcours en profondeur infixe

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Arbre binaire de recherche de l'exercice 2");
            Console.WriteLine();

            List<int> listeDeNoeuds2 = new() { 25, 60, 35, 10, 5, 20, 65, 45, 70, 40, 50, 55, 30, 15 };

            ArbreBinaireDeRecherche arbreBinaireDeRecherche2 = new(listeDeNoeuds2);
            List<Arbre> resultatInfixeSearch2 = arbreBinaireDeRecherche2.InfixeSearch();

            RenderArbreList("Parcours en profondeur infixe :", resultatInfixeSearch2, true);


            // 2) Instanciation d'un arbre binaire de recherche à partir d'une liste de 10000 valeurs alétoires.
            Random r = new();
            List<int> listeDeNoeuds3 = new();
            
            for (int z = 0; z < 100000; z++)
            {
                listeDeNoeuds3.Add(r.Next(0, int.MaxValue));
            }

            List<int> listeNoeudsArbreBinaire = new(listeDeNoeuds3);
            //Création d'un arbre binaire de recherche à partir de la liste de 10000 valeurs
            ArbreBinaireDeRecherche arbreBinaireDeRecherche3 = new(listeNoeudsArbreBinaire);

            //Création d'une liste de noeud à partir de la liste de 10000 valeurs
            List<Arbre> listeArbres = listeDeNoeuds3.Select(x => new Arbre { IdInt = x }).ToList();

           
            // 3) Comparaison du temps de recherche de 100 valeurs différentes
            List<int> entierARechercher = new();

            for (int z = 0; z < 100; z++)
            {
                entierARechercher.Add(r.Next(0, int.MaxValue));
            }

            Stopwatch stopWatchlisteArbres = new();
            stopWatchlisteArbres.Start();
            foreach (int entier in entierARechercher)
            {
                listeArbres.Any(a => a.IdInt == entier);
            }
            stopWatchlisteArbres.Stop();

            Stopwatch stopWatchArbreBinaire = new();
            stopWatchArbreBinaire.Start();
            foreach (int entier in entierARechercher)
            {
                arbreBinaireDeRecherche3.TrouverUnNoeud(arbreBinaireDeRecherche3.Racine, entier);
            }
            stopWatchArbreBinaire.Stop();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Temps de recherche dans une liste d'entier : " + stopWatchlisteArbres.Elapsed);
            Console.WriteLine("Temps de recherche dans un arbre binaire : " + stopWatchArbreBinaire.Elapsed);

            // 4) Comparaison du temps de tri d'une liste de 10000 noeud 

            Console.WriteLine();
            Console.WriteLine();

            List<Arbre> listeArbres2 = listeDeNoeuds3.Select(x => new Arbre { IdInt = x }).ToList();

            Stopwatch stopWatchTrilisteArbres = new();
            stopWatchTrilisteArbres.Start();            
            listeArbres2.OrderBy(a => a);
            stopWatchTrilisteArbres.Stop();

            List<int> listeDeNoeudArbreBinaire2 = new(listeDeNoeuds3);
            ArbreBinaireDeRecherche arbreBinaireDeRecherche4 = new(listeDeNoeudArbreBinaire2);

            Stopwatch stopWatchTriArbreBinaireDeRecherche = new();
            stopWatchTriArbreBinaireDeRecherche.Start();
            arbreBinaireDeRecherche4.InfixeSearch();
            stopWatchTriArbreBinaireDeRecherche.Stop();

            Console.WriteLine("Temps de tri dans une liste de noeud : " + stopWatchTrilisteArbres.Elapsed);
            Console.WriteLine("Temps de tri dans un arbre binaire : " + stopWatchTriArbreBinaireDeRecherche.Elapsed);
        }

        static void Exercices_TD_4()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Exercices TD4");
            Console.WriteLine();
            Console.WriteLine();


            ///Exercice 1

            // 3) Implémentation d'une méthode permettant de calculer le facteur d'équilibrage

            List<int> listeDeNoeuds = new() { 20, 5, 3, 12, 8, 6, 13, 25, 21, 28 };

            ArbreBinaireDeRecherche arbreBinaireDeRecherche = new(listeDeNoeuds);

            Console.WriteLine("Facteur d'équilibrage de la racine : " + ArbreBinaireDeRecherche.CalculerFacteurEquilibrage(arbreBinaireDeRecherche.Racine));

            // 4) Implémentation d'une méthode permettant de savoir si l'arbre est un arbre équilibré

            Console.WriteLine("L'arbre est " + (arbreBinaireDeRecherche.EstEquilibre() ? "équilibré" : "dégénéré"));


            ///Exercice 2

            // 4) Implémentation d'une méthode permettant d'effectuer une rotation gauche autour d'un noeud

            List<int> listeDeNoeuds2 = new() { 10, 5, 2, 4, 7, 12, 15, 17 };

            ArbreBinaireDeRecherche arbreBinaireDeRecherche2 = new(listeDeNoeuds2);
            Arbre noeud12 = arbreBinaireDeRecherche2.RecupererUnNoeud(12);
            Console.WriteLine("Enfant droit du noeud 12 : " + noeud12.Enfants[1]?.IdInt);
            ArbreBinaireDeRecherche.RotationGauche(noeud12);
            Console.WriteLine("Enfant droit du noeud 12 : " + noeud12.Enfants[1]?.IdInt);
        }

        static void RenderArbreList(string message, List<Arbre> arbreList, bool isIdInt = false)
        {
            Console.WriteLine(message);

            if(isIdInt)
            {
                foreach (Arbre arbre in arbreList)
                {
                    Console.Write(arbre.IdInt + " ");
                }
            }
            else
            {
                foreach (Arbre arbre in arbreList)
                {
                    Console.Write(arbre.Id + " ");
                }
            }
            
            Console.WriteLine();
        }
    }
}
