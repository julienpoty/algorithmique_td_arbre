using System;
using System.Collections.Generic;

namespace Algorithmique
{
    class Arbre
    {
        public string Id { get; set; }
        public int IdInt { get; set; }
        public List<Arbre> Enfants { get; set; } = new List<Arbre>();
        public Arbre Parent { get; set; }

        public static List<Arbre> BreadthFirstSearch(Arbre arbre)
        {
            Queue<Arbre> noeudsCourants = new();
            noeudsCourants.Enqueue(arbre);
            List<Arbre> resultat = new();

            while (noeudsCourants.Count > 0)
            {
                Arbre noeudCourant = noeudsCourants.Dequeue();
                resultat.Add(noeudCourant);
                foreach (Arbre noeud in noeudCourant.Enfants)
                {
                    noeudsCourants.Enqueue(noeud);
                }
            }
            return resultat;
        }

        public static List<Arbre> DepthFirstSearch(Arbre arbre)
        {
            List<Arbre> resultat = new();

            return DepthFirstSearchAlgorithm(arbre, resultat);
        }

        public static List<Arbre> SuffixSearch(Arbre arbre)
        {
            List<Arbre> resultat = new();

            return SuffixSearchAlgorithm(arbre, resultat);
        }

        public static List<Arbre> InfixeSearch(Arbre arbre)
        {
            List<Arbre> resultat = new();

            return InfixeSearchAlgorithm(arbre, resultat);
        }

        /// <summary>
        /// Implémentation de l'algorithme de parcours en profondeur préfixe.
        /// </summary>
        /// <param name="arbre">Noeud appartenant à l'arbre parcouru.</param>
        /// <param name="resultat">La liste de noeuds issue du parcours.</param>
        /// <returns>Une liste de noeuds résultant de la recherche préfixe.</returns>
        private static List<Arbre> DepthFirstSearchAlgorithm(Arbre arbre, List<Arbre> resultat)
        {
            resultat.Add(arbre);
            foreach (Arbre enfant in arbre.Enfants)
            {
                DepthFirstSearchAlgorithm(enfant, resultat);
            }
            return resultat;
        }

        /// <summary>
        /// Implémentation de l'algorithme de parcours en profondeur suffixe.
        /// </summary>
        /// <param name="arbre">Noeud appartenant à l'arbre parcouru.</param>
        /// <param name="resultat">La liste de noeuds issue du parcours.</param>
        /// <returns>Une liste de noeuds résultant de la recherche suffixe.</returns>
        private static List<Arbre> SuffixSearchAlgorithm(Arbre arbre, List<Arbre> resultat)
        {
            foreach (Arbre enfant in arbre.Enfants)
            {
                SuffixSearchAlgorithm(enfant, resultat);
            }
            resultat.Add(arbre);
            return resultat;
        }

        /// <summary>
        /// Implémentation de l'algorithme de parcours en profondeur infixe.
        /// </summary>
        /// <param name="arbre">Noeud appartenant à l'arbre parcouru.</param>
        /// <param name="resultat">La liste de noeuds issue du parcours.</param>
        /// <returns>Une liste de noeuds résultant de la recherche infixe.</returns>
        private static List<Arbre> InfixeSearchAlgorithm(Arbre arbre, List<Arbre> resultat)
        {
            if (arbre.Enfants.Count > 2)
            {
                throw new ArgumentException("Le noeud possède plus de 2 noeuds enfants.");
            }

            if (arbre.Enfants.Count > 0)
                InfixeSearchAlgorithm(arbre.Enfants[0], resultat);

            resultat.Add(arbre);

            if (arbre.Enfants.Count > 1)
                InfixeSearchAlgorithm(arbre.Enfants[1], resultat);

            return resultat;
        }
    }
}
