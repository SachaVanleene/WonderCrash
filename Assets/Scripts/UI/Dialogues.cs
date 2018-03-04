using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conv {
    public List<Interaction> interactionListe;
}

public class Interaction {
    public int id;
    public string interaction;
    public List<Rep> reponseListe;
}

public class Rep {
    public string reponse;
    public int interacSuiv;
    public int soupcon;
}

public static class Dialogues {

    private static Dictionary<string, Conv> _conv = new Dictionary<string, Conv> {
        //**************************************************************************************
        // NIVEAU 0 (tutoriel)
        //**************************************************************************************
        //Conversation (niveau 0, pnj 1, personalité 1)
        {"0.1.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Salut Ernest… ou Jack, ou…je ne sais quel prénom tu préfères aujourd’hui. Tu vas bien ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "... ça pourrait aller mieux vu l’endroit où on est. Écoute, je cherche à foutre le camp d’ici. T’aurais pas un petit contact qui m’aiderait ?", interacSuiv = 2, soupcon = 50 },
                new Rep { reponse = "... Je vais toujours bien moi. Mais j'ai besoin de ton aide pour partir d'ici. Tu connais quelqu'un non ?", interacSuiv = 2, soupcon = 30 },
                new Rep { reponse = "... Non ça va pas, faut que je parte d'ici. T'aurais pas un contact pour m'aider ?", interacSuiv = 2, soupcon = 2 }
                }
            },
            new Interaction { id = 2, interaction = "Ouais ouais je connais quelqu’un. Ya Marco qui traîne souvent dans la salle commune… Va le voir, il connaît bien cet étage. Mais fait gaffe d’être poli si tu veux des réponses, il aime pas être contrarié ce gars là.", reponseListe = null }
        } } },

        //Conversation (niveau 0, pnj 2, personalité 1)
        {"0.2.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "On s'connaît ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Bonjour Marco! Moi c’est Ernest, content de te rencontrer. Fred m’a dit que tu pourrais peut-être m’aider.", interacSuiv = 2, soupcon = 50 },
                new Rep { reponse = "Pas encore. Moi c’est Ernest, c’est ton ami Fred qui m’a dit de venir te voir pour un service.", interacSuiv = 3, soupcon = 2 },
                new Rep { reponse = "Non, mais j’aurais un petit service à te demander.", interacSuiv = 4, soupcon = 20 }
                }
            },
            new Interaction { id = 2, interaction = "Ah, ça fait du bien d’entendre un peu de politesse par ici!  Qu’est ce qu’il te faut mon ami ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je cherche à m’évader d’ici mais je ne sais pas par où commencer...", interacSuiv = 5, soupcon = 15 },
                new Rep { reponse = "Faut que j’me barre, j’ai rien à foutre dans cet asile moi. Je suis sain d’esprit, sain d'esprit, tu vois. Tu peux m’aider ?", interacSuiv = 5, soupcon = 10 },
                new Rep { reponse = "Faut que j'mévade !", interacSuiv = 5, soupcon = 0 }
                }
            },
            new Interaction { id = 3, interaction = "Un ami de Fred est un ami à moi! Qu’est ce qu’il de faut ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je cherche à m’évader d’ici mais je ne sais pas par où commencer...", interacSuiv = 6, soupcon = 3 },
                new Rep { reponse = "Faut que j’me barre, j’ai rien à foutre dans cet asile moi. Je suis sain d’esprit, sain d'esprit, tu vois. Tu peux m’aider ?", interacSuiv = 6, soupcon = 20 },
                new Rep { reponse = "Faut que j'mévade !", interacSuiv = 6, soupcon = 0 }
                }
            },
            new Interaction { id = 4, interaction = "Un bonjour ne ferait pas de mal. Qu’es tu veux ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je cherche à m’évader d’ici mais je ne sais pas par où commencer...", interacSuiv = 7, soupcon = 0 },
                new Rep { reponse = "Faut que j’me barre, j’ai rien à foutre dans cet asile moi. Je suis sain d’esprit, sain d'esprit, tu vois. Tu peux m’aider ?", interacSuiv = 7, soupcon = 50 },
                new Rep { reponse = "Faut que j'mévade !", interacSuiv = 7, soupcon = 0 }
                }
            },
            new Interaction { id = 5, interaction = "J’connais l’asile comme ma poche mon pote. Si tu veux t’évader, commence par rentrer dans la salle de pause des médecins, ils ont des clés qui donnent accès à pas mal d’endroits. Mais attention, ils ne font pas confiance à tout le monde... ", reponseListe = null },
            new Interaction { id = 6, interaction = "T’as de la chance, je connais bien l’asile. Va voir dans le coin de pause des médecins, ils peuvent t’ouvrir pas mal de portes par ici.", reponseListe = null },
            new Interaction { id = 7, interaction = "Regarde dans les salles de ce couloir, j’entends que les médecins sont en pause. Et reviens surtout pas me voir.", reponseListe = null }
        } } },

        //Conversation (niveau 0, pnj 3, personalité 2)
        {"0.3.2", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Bonjour collègue. Comment allez-vous aujourd’hui ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Pas terrible à vrai dire… Un patient vient tout juste de me faire un croche-patte alors que je me baladais dans le couloir...", interacSuiv = 2, soupcon = 30 },
                new Rep { reponse = "Argh, je passe un mauvaise journée! J'ai encore oublié mon stéthoscope dans la salle des gardes...", interacSuiv = 3, soupcon = 10 },
                new Rep { reponse = "Ça va plutôt bien, mais j'ai oublié comment rejoindre l'étage du dessus", interacSuiv = 4, soupcon = 20 }
                }
            },
            new Interaction { id = 2, interaction = "Quoi ?! Ce genre de comportement est intolérable ! Prenez les clés sur la table et allez voir les gardiens dans leur bureau au bout du couloir pour leur en faire part.", reponseListe = null },
            new Interaction { id = 3, interaction = "Haha, tu es bien malin ! Je crois que la porte est ouverte, tu peux aller voir.", reponseListe = null },
            new Interaction { id = 4, interaction = "... D'accord. Parles-en aux gardes peut-être...", reponseListe = null },
        } } }

        //**************************************************************************************
        // NIVEAU 1
        //**************************************************************************************
    };

    public static Conv GetConv(string id) {
        Conv conv;
        Conv erreur = new Conv();
        erreur.interactionListe = new List<Interaction>();
        erreur.interactionListe.Add(new Interaction { id = 0, interaction = "Je n'ai pas envie de parler", reponseListe = null });

        if (_conv.TryGetValue(id, out conv)) {
            return conv;
        } else
        {
            return erreur;
        }
            
    }
}