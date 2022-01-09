using System;
using System.Collections.Generic;

namespace Algorithmique
{
    class ArbreBinaireDeRecherche
    {
        public Arbre Racine { get; } = new Arbre();

        /// <summary>
        /// Constructeur d'un arbre binaire de recherche.
        /// </summary>
        /// <param name="listeNoeuds">Une liste d'entier utiliser pour construire l'arbre.</param>
        public ArbreBinaireDeRecherche(List<int> listeNoeuds)
        {
            Racine.IdInt = listeNoeuds[0];
            Racine.Enfants = new List<Arbre>()
            {
                null,
                null
            };

            listeNoeuds.Remove(Racine.IdInt);

            foreach (int noeudId in listeNoeuds)
            {
                AjouterUnNoeud(Racine, noeudId);
            }
        }

        /// <summary>
        /// Ajoute un noeud à l'arbre binaire de recherche.
        /// </summary>
        /// <param name="noeudParent">Un noeud présent dans l'arbre de recherche.</param>
        /// <param name="nouveauNoeudId">Identifiant numérique du noeud à ajouter.</param>
        /// <returns></returns>
        private bool AjouterUnNoeud(Arbre noeudParent, int nouveauNoeudId)
        {
            if(noeudParent.IdInt == nouveauNoeudId)
            {
                return false;
            }
            if(noeudParent.IdInt < nouveauNoeudId)
            {
                if(noeudParent.Enfants[1] == null)
                {
                    noeudParent.Enfants[1] = new Arbre()
                    {
                        IdInt = nouveauNoeudId,
                        Parent = noeudParent,
                        Enfants = new List<Arbre>()
                        {
                            null,
                            null
                        }
                    };
                    return true;
                }
                else
                {
                    return AjouterUnNoeud(noeudParent.Enfants[1], nouveauNoeudId);
                }
            }
            else
            {
                if (noeudParent.Enfants[0] == null)
                {
                    noeudParent.Enfants[0] = new Arbre()
                    {
                        IdInt = nouveauNoeudId,
                        Parent = noeudParent,
                        Enfants = new List<Arbre>()
                        {
                            null,
                            null
                        }
                    };
                    return true;
                }
                else
                {
                    return AjouterUnNoeud(noeudParent.Enfants[0], nouveauNoeudId);
                }
            }
        }

        /// <summary>
        /// Recherche par profondeur infixe d'un arbre binaire de recherche.
        /// </summary>
        /// <returns>Une liste de noeud résultant de la recherche infixe.</returns>
        public List<Arbre> InfixeSearch()
        {
            List<Arbre> resultat = new();

            return InfixeSearch(Racine, resultat);
        }

        /// <summary>
        /// Indique si un noeud existe dans l'arbre binaire de rechercher.
        /// </summary>
        /// <param name="noeud">Noeud appartenant à l'arbre sur lequel porte la recherche.</param>
        /// <param name="idNoeud">Identifiant numérique du noeud à rechercher.</param>
        /// <returns>True si le noeud a été trouvé, autrement False.</returns>
        public bool TrouverUnNoeud(Arbre noeud, int idNoeud)
        {
            if (noeud.IdInt == idNoeud)
            {
                return true;
            }
            if (noeud.IdInt < idNoeud)
            {
                if (noeud.Enfants[1] == null)
                {
                    return false;
                }
                else
                {
                    return TrouverUnNoeud(noeud.Enfants[1], idNoeud);
                }
            }
            else
            {
                if (noeud.Enfants[0] == null)
                {
                    return false;
                }
                else
                {
                    return TrouverUnNoeud(noeud.Enfants[0], idNoeud);
                }
            }
        }

        /// <summary>
        /// Récupère un noeud présent dans un arbre binaire de recherche.
        /// </summary>
        /// <param name="idNoeud">Identifiant numérique correspondant au noeud recherché.</param>
        /// <returns>Le noeud recherché s'il a été trouvé, autrement null.</returns>
        public Arbre RecupererUnNoeud(int idNoeud)
        {
            return RecupererUnNoeud(Racine, idNoeud);
        }

        /// <summary>
        /// Récupère un noeud présent dans un arbre binaire de recherche.
        /// </summary>
        /// <param name="noeud">Noeud appartement à l'arbre sur lequel porte la récupération.</param>
        /// <param name="idNoeud">Identifiant numérique correspondant au noeud recherché.</param>
        /// <returns>Le noeud recherché s'il a été trouvé, autrement null.</returns>
        private Arbre RecupererUnNoeud(Arbre noeud, int idNoeud)
        {
            if (noeud.IdInt == idNoeud)
            {
                return noeud;
            }
            if (noeud.IdInt < idNoeud)
            {
                if (noeud.Enfants[1] == null)
                {
                    return null;
                }
                else
                {
                    return RecupererUnNoeud(noeud.Enfants[1], idNoeud);
                }
            }
            else
            {
                if (noeud.Enfants[0] == null)
                {
                    return null;
                }
                else
                {
                    return RecupererUnNoeud(noeud.Enfants[0], idNoeud);
                }
            }
        }

        /// <summary>
        /// Implémentation de l'algorithme de parcours en profondeur infixe pour un arbre binaire de recherche.
        /// </summary>
        /// <param name="arbre">Noeud appartenant à l'arbre binaire de recherche parcouru.</param>
        /// <param name="resultat">La liste de noeuds issue du parcours.</param>
        /// <returns>Une liste de noeuds résultant de la recherche infixe.</returns>
        private static List<Arbre> InfixeSearch(Arbre arbre, List<Arbre> resultat)
        {
            if (arbre.Enfants.Count > 2)
            {
                throw new ArgumentException("Le noeud possède plus de 2 noeuds enfants.");
            }

            if (arbre.Enfants[0] != null)
                InfixeSearch(arbre.Enfants[0], resultat);

            resultat.Add(arbre);

            if (arbre.Enfants[1] != null)
                InfixeSearch(arbre.Enfants[1], resultat);

            return resultat;
        }

        /// <summary>
        /// Détermine si un arbre binaire de recherche est équilibré.
        /// </summary>
        /// <returns>True si l'arbre est équilibré, autrement False.</returns>
        public bool EstEquilibre()
        {
            int result = CalculerFacteurEquilibrage(Racine);

            return result >= -1 && result <= 1;
        }

        /// <summary>
        /// Calcul du facteur d'équilibrage d'un arbre binaire de recherche.
        /// </summary>
        /// <param name="arbre">Noeud appartenant à l'arbre binaire de recherche.</param>
        /// <param name="hauteurGauche">Hauteur du sous arbre gauche.</param>
        /// <param name="hauteurDroite">Hauteur du sous arbre droit.</param>
        /// <returns>Le facteur d'équilibrage.</returns>
        public static int CalculerFacteurEquilibrage(Arbre arbre, int hauteurGauche = 0, int hauteurDroite = 0)
        {
            if(hauteurGauche != 0)
            {
                if (arbre.Enfants.Count > 2)
                {
                    throw new ArgumentException("Le noeud possède plus de 2 noeuds enfants.");
                }
                if (arbre.Enfants.Count > 0 && (arbre.Enfants[0] != null || arbre.Enfants[1] != null))
                {
                    hauteurGauche--;

                    if(arbre.Enfants[0] != null)
                    {
                        hauteurGauche = CalculerFacteurEquilibrage(arbre.Enfants[0], hauteurGauche, 0);
                    }                    
                    if(arbre.Enfants[1] != null)
                    {
                        hauteurDroite = CalculerFacteurEquilibrage(arbre.Enfants[1], hauteurGauche, 0);
                    }

                    return hauteurGauche < hauteurDroite ? hauteurGauche : hauteurDroite;
                }
                else
                {
                    return hauteurGauche;
                }

            }
            else if(hauteurDroite != 0)
            {
                if (arbre.Enfants.Count > 2)
                {
                    throw new ArgumentException("Le noeud possède plus de 2 noeuds enfants.");
                }
                if (arbre.Enfants.Count > 0 && (arbre.Enfants[0] != null || arbre.Enfants[1] != null))
                {
                    hauteurDroite++;

                    if (arbre.Enfants[0] != null)
                    {
                        hauteurGauche = CalculerFacteurEquilibrage(arbre.Enfants[0], 0, hauteurDroite);
                    }                   
                    if (arbre.Enfants[1] != null)
                    {
                        hauteurDroite = CalculerFacteurEquilibrage(arbre.Enfants[1], 0, hauteurDroite);
                    }

                    return hauteurGauche > hauteurDroite ? hauteurGauche : hauteurDroite;
                }
                else
                {
                    return hauteurDroite;
                }
            }
            else
            {
                if (arbre.Enfants[0] != null && hauteurGauche == 0)
                {
                    hauteurGauche--;
                    hauteurGauche = CalculerFacteurEquilibrage(arbre.Enfants[0], hauteurGauche, 0);
                }
                if (arbre.Enfants[1] != null && hauteurDroite == 0)
                {
                    hauteurDroite++;
                    hauteurDroite = CalculerFacteurEquilibrage(arbre.Enfants[1], 0, hauteurDroite);
                }

                return hauteurGauche + hauteurDroite;
            }
        }
    
        /// <summary>
        /// Effectue une rotation gauche sur un noeud.
        /// </summary>
        /// <param name="arbre">Noeud sur lequel sera effectué la rotation gauche.</param>
        public static void RotationGauche(Arbre arbre)
        {
            if(arbre.Enfants[1] != null 
                && arbre.Enfants[1].Enfants[0] == null
                && arbre.Enfants[1].IdInt > arbre.IdInt)
            {              
                var tmpEnfant = arbre.Enfants[1];

                if (arbre.Parent != null)
                {
                    var parent = arbre.Parent;
                    tmpEnfant.Parent = parent;

                    if(parent.Enfants[0] == arbre)
                    {
                        parent.Enfants[0] = tmpEnfant;
                    }
                    else
                    {
                        parent.Enfants[1] = tmpEnfant;
                    }

                }

                arbre.Parent = tmpEnfant;
                tmpEnfant.Enfants[0] = arbre;
                arbre.Enfants[1] = null;
            }
            else
            {
                throw new ArgumentException("Impossible d'effectuer la rotation sur le noeud " + arbre.IdInt);
            }
        }
    }
}
