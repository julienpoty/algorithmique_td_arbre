using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmique
{
    class Arbre
    {
        public string Id { get; set; }
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

        public static void DepthFirstSearch(Arbre arbre, List<Arbre> resultat)
        {
            resultat.Add(arbre);
            foreach (Arbre enfant in arbre.Enfants)
            {
                DepthFirstSearch(enfant, resultat);
            }
        }

        public static void SuffixSearch(Arbre arbre, List<Arbre> resultat)
        {
            foreach (Arbre enfant in arbre.Enfants)
            {
                DepthFirstSearch(enfant, resultat);
            }
            resultat.Add(arbre);
        }

        public static void InfixeSearch(Arbre arbre, List<Arbre> resultat)
        {
            if (arbre.Enfants.Count > 2)
            {
                throw new ArgumentException("Le noeud possède plus de 2 noeuds enfants.");
            }

            if (arbre.Enfants.Count > 0)
                InfixeSearch(arbre.Enfants[0], resultat);

            resultat.Add(arbre);

            if (arbre.Enfants.Count > 1)
                InfixeSearch(arbre.Enfants[1], resultat);
        }
    }
}
