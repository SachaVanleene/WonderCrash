using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Unlock {
    OK,
    KO,
    WAIT
}

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
    public Unlock progress = Unlock.WAIT;
}


public static class Dialogues {

    private static Dictionary<string, Conv> _conv = new Dictionary<string, Conv> {
        //**************************************************************************************
        // NIVEAU 0 (tutoriel)
        //**************************************************************************************
        //Conversation (niveau 0, pnj 1, personalité 1)
        {"0.1.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Salut Ernest… ou Jack, ou…je ne sais quel prénom tu préfères aujourd’hui. Tu vas bien ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "... ça pourrait aller mieux vu l’endroit où on est. Écoute, je cherche à foutre le camp d’ici. T’aurais pas un petit contact qui m’aiderait ?", interacSuiv = 2, soupcon = 0 },
                new Rep { reponse = "... Je vais toujours bien moi. Mais j'ai besoin de ton aide pour partir d'ici. Tu connais quelqu'un non ?", interacSuiv = 2, soupcon = 0 },
                new Rep { reponse = "... Non ça va pas, faut que je parte d'ici. T'aurais pas un contact pour m'aider ?", interacSuiv = 2, soupcon = 0 }
                }
            },
            new Interaction { id = 2, interaction = "Ouais ouais je connais quelqu’un. Ya Marco qui traîne souvent dans la salle commune… Va le voir, il connaît bien cet étage. Mais fait gaffe d’être poli si tu veux des réponses, il aime pas être contrarié ce gars là.", reponseListe = null }
        } } },

        //Conversation (niveau 0, pnj 2, personalité 1)
        {"0.2.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "On s'connaît ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Bonjour Marco! Moi c’est Ernest, content de te rencontrer. Fred m’a dit que tu pourrais peut-être m’aider.", interacSuiv = 2, soupcon = 0 },
                new Rep { reponse = "Pas encore. Moi c’est Ernest, c’est ton ami Fred qui m’a dit de venir te voir pour un service.", interacSuiv = 3, soupcon = 0 },
                new Rep { reponse = "Non, mais j’aurais un petit service à te demander.", interacSuiv = 4, soupcon = 0 }
                }
            },
            new Interaction { id = 2, interaction = "Ah, ça fait du bien d’entendre un peu de politesse par ici!  Qu’est ce qu’il te faut mon ami ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je cherche à m’évader d’ici mais je ne sais pas par où commencer...", interacSuiv = 5, soupcon = 0 },
                new Rep { reponse = "Faut que j’me barre, j’ai rien à foutre dans cet asile moi. Je suis sain d’esprit, sain d'esprit, tu vois. Tu peux m’aider ?", interacSuiv = 5, soupcon = 0 },
                new Rep { reponse = "Faut que j'mévade !", interacSuiv = 5, soupcon = 0 }
                }
            },
            new Interaction { id = 3, interaction = "Un ami de Fred est un ami à moi! Qu’est ce qu’il de faut ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je cherche à m’évader d’ici mais je ne sais pas par où commencer...", interacSuiv = 6, soupcon = 0 },
                new Rep { reponse = "Faut que j’me barre, j’ai rien à foutre dans cet asile moi. Je suis sain d’esprit, sain d'esprit, tu vois. Tu peux m’aider ?", interacSuiv = 6, soupcon = 0 },
                new Rep { reponse = "Faut que j'mévade !", interacSuiv = 6, soupcon = 0 }
                }
            },
            new Interaction { id = 4, interaction = "Un bonjour ne ferait pas de mal. Qu’es tu veux ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je cherche à m’évader d’ici mais je ne sais pas par où commencer...", interacSuiv = 7, soupcon = 0 },
                new Rep { reponse = "Faut que j’me barre, j’ai rien à foutre dans cet asile moi. Je suis sain d’esprit, sain d'esprit, tu vois. Tu peux m’aider ?", interacSuiv = 7, soupcon = 0 },
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
                new Rep { reponse = "Pas terrible à vrai dire… Un patient vient tout juste de me faire un croche-patte alors que je me baladais dans le couloir...", interacSuiv = 2, soupcon = 0 },
                new Rep { reponse = "Argh, je passe un mauvaise journée! J'ai encore oublié mon stéthoscope dans la salle des gardes...", interacSuiv = 3, soupcon = 1 },
                new Rep { reponse = "Ça va plutôt bien, mais j'ai oublié comment rejoindre l'étage du dessus", interacSuiv = 4, soupcon = 2 }
                }
            },
            new Interaction { id = 2, interaction = "Quoi ?! Ce genre de comportement est intolérable ! Prenez les clés sur la table et allez voir les gardiens dans leur bureau au bout du couloir pour leur en faire part.", reponseListe = null },
            new Interaction { id = 3, interaction = "Haha, tu es bien malin ! Je crois que la porte est ouverte, tu peux aller voir.", reponseListe = null },
            new Interaction { id = 4, interaction = "... D'accord. Parles-en aux gardes peut-être...", reponseListe = null },
        } } },


        //**************************************************************************************
        // NIVEAU 1
        //**************************************************************************************
        //------------------------------------
        // PNJ 1 = MEDECIN COULOIR
        //------------------------------------
        //Conversation (niveau 1, pnj 1, personalité 1)
        {"1.1.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Eh ! Vous n’êtes pas censés vous balader tout seul dans les couloirs. Qu’est ce que vous faites ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je vous cherchais justement, j’ai un peu mal au ventre...", interacSuiv = 2, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Je me suis perdu", interacSuiv = 2, soupcon = 5, progress = Unlock.KO },
                new Rep { reponse = "J’admirais l’architecture de cette vieille bâtisse", interacSuiv = 2, soupcon = 10, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Je ne vous crois pas ! Retournez à votre cellule !", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 1, personalité 2)
        {"1.1.2", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Ah, bonjour collègue ! Comment s’est passé votre opération avec Alexandre ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Très bien, le patient pourra remarcher d’ici une semaine !", interacSuiv = 2, soupcon = 0 },
                new Rep { reponse = "Je n’ai pas pu y assister malheureusement à cause d’un mal de tête.", interacSuiv = 6, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Bien.", interacSuiv = 7, soupcon = 0 }
                }
            },
            new Interaction { id = 2, interaction = "Il m’avait semblé que c’était une opération au coeur pourtant...", reponseListe = new List<Rep>() {
                new Rep { reponse = "C’était les deux ! Ce patient en a plus pour longtemps à mon avis...", interacSuiv = 3, soupcon = 20, progress = Unlock.KO },
                new Rep { reponse = "Celui là c’était hier, quand vous n’étiez pas là.", interacSuiv = 4, soupcon = 5, progress = Unlock.OK },
                new Rep { reponse = "Peut être bien, je suis fatigué, je ne sais plus ce que je raconte. Je vais me reposer.", interacSuiv = 5, soupcon = 0, progress = Unlock.OK}
                }
            },
            new Interaction { id = 3, interaction = "J’en doute fort... Rebroussez chemin et retourner d'où vous venez", reponseListe = null },
            new Interaction { id = 4, interaction = "Si vous le dites. Bonne journée.", reponseListe = null },
            new Interaction { id = 5, interaction = "Oui bonne idée, passez et reposez vous.", reponseListe = null },
            new Interaction { id = 6, interaction = "Les aléas du métier malheureusement. Peut être que vous devriez vous reposer. Je ne vous embête pas plus longtemps.", reponseListe = null },
            new Interaction { id = 7, interaction = "Je vous ai connu plus bavard. Vous allez bien ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Juste un peu de fatigue.", interacSuiv = 8, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Je ne me reconnais plus", interacSuiv = 9, soupcon = 20, progress = Unlock.KO },
                new Rep { reponse = "Vous doutez de moi ?", interacSuiv = 10, soupcon = 15, progress = Unlock.KO }
                }
            },
            new Interaction { id = 8, interaction = "D’accord. Continuez votre chemin et allez dormir alors.", reponseListe = null },
            new Interaction { id = 9, interaction = "Moi non plus je ne vous reconnais pas. GARDES !", reponseListe = null },
            new Interaction { id = 10, interaction = "Maintenant oui.Qui êtes vous ? Partez avant que je ne vous dénonce.", reponseListe = null },
        } } },

        //Conversation (niveau 1, pnj 1, personalité 3)
        {"1.1.3", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Passage interdit monsieur ! Il y a un grave malade parmis les patients. La zone est en quarantaine.", reponseListe = new List<Rep>() {
                new Rep { reponse = "Mais je suis pressé ! Un patient dangereux aux personnalités multiples tente de s’évader !", interacSuiv = 2, soupcon = 2, progress = Unlock.KO },
                new Rep { reponse = "Ah oui ? Bon. Espérons que ça n’aille pas plus loin.", interacSuiv = 2, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Vous n’avez aucune autorité sur moi. Laissez moi passer !", interacSuiv = 2, soupcon = 1, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Vous pouvez retrousser votre chemin. Aucune personne non docteur ne passe !", reponseListe = null }
        } } },


        //------------------------------------
        // PNJ 2 = PATIENT SALLE COMMUNE
        //------------------------------------
        //Conversation (niveau 1, pnj 2, personalité 1)
        {"1.2.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Salut Ernest ! C’est pas souvent qu’on te voit dans cette salle commune !", reponseListe = new List<Rep>() {
                new Rep { reponse = "Non, je suis là en touriste. D’ailleurs pousse-toi de là, je vais derrière cette porte.", interacSuiv = 2, soupcon = 0 },
                new Rep { reponse = "Ne le dis à personne mais je cherche à m’évader d’ici... Faut que je passe.", interacSuiv = 4, soupcon = 100, progress = Unlock.KO },
                new Rep { reponse = "Je vais voler des cigarettes au garde. J’ai besoin de passer par ici mais je peux t’en rapporter si tu veux.", interacSuiv = 5, soupcon = 0, progress = Unlock.OK }
                }
            },
            new Interaction { id = 2, interaction = "C’est pas en me parlant comme ça que je vais te laisser passer.", reponseListe = new List<Rep>() {
                new Rep { reponse = "Excuse moi, je ne voulais pas te vexer.", interacSuiv = 3, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Désolé frère. Tu sais bien que je ne te vexerai pas intentionnellement.", interacSuiv = 3, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Hey ?! Et la solidarité entre patients alors ?", interacSuiv = 3, soupcon = 0, progress = Unlock.OK }
                }
            },
            new Interaction { id = 3, interaction = "Allez passe", reponseListe = null },
            new Interaction { id = 4, interaction = "Monsieur le garde, c'est lui le patient qui s'évade ! Et oui, je suis une balance !", reponseListe = null },
            new Interaction { id = 5, interaction = "Ok, je te laisse passer. Mais m’oublie pas hein !", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 2, personalité 2)
        {"1.2.2", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "C’est la salle communes des patients ici, pas des médecins.", reponseListe = new List<Rep>() {
                new Rep { reponse = "Laissez moi sortir par cette porte alors.", interacSuiv = 2, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Mes excuses. Vous me laisserez partir au moins ?", interacSuiv = 3, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Ok je pars.", interacSuiv = 4, soupcon = 0, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Vous pouvez faire le tour.", reponseListe = null },
            new Interaction { id = 3, interaction = "Oui, par la porte par laquelle vous êtes arrivés.", reponseListe = null },
            new Interaction { id = 4, interaction = "Je regarde.", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 2, personalité 3)
        {"1.2.3", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Bonjour monsieur.", reponseListe = new List<Rep>() {
                new Rep { reponse = "Bonjour. Laissez moi passer.", interacSuiv = 2, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Pas le temps pour la politesse. Il faut que je passe.", interacSuiv = 2, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Allez vous asseoir. C’est bientôt l’heure de manger.", interacSuiv = 2, soupcon = 0, progress = Unlock.OK }
                }
            },
            new Interaction { id = 2, interaction = "Je ne me mets pas en travers de votre chemin.", reponseListe = null }
        } } },

        //------------------------------------
        // PNJ 3 = PATIENT CELLULE
        //------------------------------------
        //Conversation (niveau 1, pnj 3, personalité 1)
        {"1.3.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Qu’est ce que tu veux ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Laisse moi entrer ! Je vais me faire faire repérer.", interacSuiv = 2, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "J’ai des gardes qui me cherche. Je peux me cacher dans ta cellule s’il te plaît ?", interacSuiv = 3, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Rien en particulier.", interacSuiv = 4, soupcon = 0, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Eh oh, me crie pas dessus. Va demander à quelqu’un d’autre.", reponseListe = null },
            new Interaction { id = 3, interaction = "Allez entre.", reponseListe = null },
            new Interaction { id = 4, interaction = "Ok bonne journée.", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 3, personalité 2)
        {"1.3.2", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "J’ai pas rendez-vous aujourd’hui, qu’est ce que vous voulez ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Rendez-vous santé du mois. Je dois vous examiner.", interacSuiv = 2, soupcon = 5, progress = Unlock.KO },
                new Rep { reponse = "Il y a une quarantaine plus loin. Je dois vérifier que tout va bien ici.", interacSuiv = 3, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Je cherche un garde. Vous en avez vu passer un ?", interacSuiv = 4, soupcon = 0, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Y a jamais eu de rendez-vous du mois...", reponseListe = null },
            new Interaction { id = 3, interaction = "Une quarantaine ? C’est vrai que j’ai l’oreille qui me démange en ce moment. Rentrez vite voir.", reponseListe = null },
            new Interaction { id = 4, interaction = "Il y en a partout ici vous savez.", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 3, personalité 3)
        {"1.3.3", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Je ne parle pas aux gardes moi", reponseListe = new List<Rep>() {
                new Rep { reponse = "On est pas obligé de parler au pire", interacSuiv = 2, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Je vais t'apprendre la politesse moi !", interacSuiv = 3, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Je te prive de nourriture pendant 1 mois si tu me laisse pas rentrer !", interacSuiv = 4, soupcon = 0, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Ba chut alors !", reponseListe = null },
            new Interaction { id = 3, interaction = "Tu me fais pas peur !", reponseListe = null },
            new Interaction { id = 4, interaction = "La bouffe est dégueu de toute façon", reponseListe = null }
        } } },


        //------------------------------------
        // PNJ 4 = MEDECIN 2
        //------------------------------------
        //Conversation (niveau 1, pnj 4, personalité 1)
        {"1.4.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Bonjour. Votre tête me paraît familière, vous auriez pas un cousin qui travaille ici ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Oui, il est médecin.", interacSuiv = 2, soupcon = 10, progress = Unlock.KO },
                new Rep { reponse = "Oui il est gardien ici.", interacSuiv = 2, soupcon = 10, progress = Unlock.KO },
                new Rep { reponse = "Non, j’aime juste bien me déguiser.", interacSuiv = 3, soupcon = 20, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Mmmm, pas sur. Je ne sais pas pourquoi, mais je ne vous fait pas confiance. Retournez d'où vous venez.", reponseListe = null },
            new Interaction { id = 3, interaction = "Haha très drôle ! Allez vous coucher Ernest.", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 4, personalité 2)
        {"1.4.2", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Vous tombez à pic ! J’ai une patiente en urgence avec fièvre, pleurésie et péricardite. C’est un lupus non ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Ce n’est jamais un lupus !", interacSuiv = 2, soupcon = 0},
                new Rep { reponse = "Franchement aucune idée...", interacSuiv = 3, soupcon = 10, progress = Unlock.KO },
                new Rep { reponse = "Les symptômes ne mentent jamais !", interacSuiv = 4, soupcon = 0, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "C’est quoi alors ? Une sclérose en plaques ou une borréliose de lyme ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Une sclérose en plaques", interacSuiv = 5, soupcon = 10, progress = Unlock.KO },
                new Rep { reponse = "Une borréliose de lyme", interacSuiv = 6, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Une indigestion ?", interacSuiv = 7, soupcon = 50, progress = Unlock.KO }
                }
            },
            new Interaction { id = 3, interaction = "Le plus simple est que vous alliez la voir directement.", reponseListe = null },
            new Interaction { id = 4, interaction = "Dommage pour elle... Allez lui annoncer la mauvaise nouvelle !", reponseListe = null },
            new Interaction { id = 5, interaction = "Je pense pas que ça soit ça... Le plus simple est que vous alliez la voir directement.", reponseListe = null },
            new Interaction { id = 6, interaction = "Effectivement ça doit être cela. Je vais annoncer la nouvelle à la patiente.", reponseListe = null },
            new Interaction { id = 6, interaction = "Mais vous n'êtes pas médecin? Vous êtes le patient en fuite ! GARDES !!", reponseListe = null },
        } } },

        //Conversation (niveau 1, pnj 4, personalité 3)
        {"1.4.3", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Alors vous trouvez le détenu en fuite ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je suis à sa recherche en ce moment même !", interacSuiv = 2, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Non mais il est 17h, j’ai fini ma journée moi !", interacSuiv = 3, soupcon = 15, progress = Unlock.KO },
                new Rep { reponse = "Oui il est retourné dans sa cellule !", interacSuiv = 4, soupcon = 10, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "Mmm. Cessez de vous promener et chercher le vraiment.", reponseListe = null },
            new Interaction { id = 3, interaction = "Eh oh ! Retournez chercher l’évadé !", reponseListe = null },
            new Interaction { id = 4, interaction = "Bizarre le garde d’à côté le cherche encore... Faites demi-tour !", reponseListe = null }
        } } },


        //------------------------------------
        // PNJ 5 = MEDECIN 3
        //------------------------------------
        //Conversation (niveau 1, pnj 5, personalité 1)
        {"1.5.1", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Ah Ernest ! Je vous cherchais justement...", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je suis là. Que me voulez-vous ?", interacSuiv = 2, soupcon = 0 },
                new Rep { reponse = "Désolé je suis pressé, je n’ai pas le temps !", interacSuiv = 3, soupcon = 10, progress = Unlock.OK },
                new Rep { reponse = "Non c’est moi qui vous cherchais.", interacSuiv = 4, soupcon = 0 }
                }
            },
            new Interaction { id = 2, interaction = "Votre prise de sang indique que vous ne prenez toujours pas vos médocs. Qu’avez -vous à répondre à cela ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Pouet !", interacSuiv = 5, soupcon = 5, progress = Unlock.KO },
                new Rep { reponse = "Effectivement je ne les prends plus...", interacSuiv = 6, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Plus besoin, je vais beaucoup mieux !", interacSuiv = 5, soupcon = 10, progress = Unlock.KO }
                }
            },
            new Interaction { id = 4, interaction = "Pourquoi me cherchiez-vous ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Je sors quand ?", interacSuiv = 7, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "Une urgence avec Marco, les infirmières vous cherchent!", interacSuiv = 8, soupcon = 0, progress = Unlock.OK },
                new Rep { reponse = "Vous êtes viré !", interacSuiv = 5, soupcon = 10, progress = Unlock.KO }
                }
            },

            new Interaction { id = 3, interaction = "Une autre fois alors...", reponseListe = null },
            new Interaction { id = 5, interaction = "Vous vous trouvez drôle peut-être. Allez du vent !", reponseListe = null },
            new Interaction { id = 6, interaction = "Allez à l'infirmerie les prendre sur le champ !", reponseListe = null },
            new Interaction { id = 7, interaction = "Pas de si tôt.", reponseListe = null },
            new Interaction { id = 8, interaction = "Ah merci,  j’y vais de ce pas !", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 5, personalité 2)
        {"1.5.2", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Pourquoi diable êtes-vous déguisé en docteur Ernest ? Vous cherchez à vous évader ?", reponseListe = new List<Rep>() {
                new Rep { reponse = "Qui est Ernest ? Moi c’est Jean-Eude !", interacSuiv = 2, soupcon = 0, progress = Unlock.KO },
                new Rep { reponse = "C'est la journée métier, du coup j’apprends des trucs au patient !", interacSuiv = 3, soupcon = 5, progress = Unlock.KO },
                new Rep { reponse = "Arrêtez de me confondre avec Ernest !", interacSuiv = 4, soupcon = 0, progress = Unlock.OK }
                }
            },
            new Interaction { id = 2, interaction = "Je vois que ça va toujours pas mieux mon pauvre Ernest...", reponseListe = null },
            new Interaction { id = 3, interaction = "C’est sympa de votre part sauf que les patients sont derrière vous.", reponseListe = null },
            new Interaction { id = 4, interaction = "Oh pardon, vous lui ressemblez fortement pourtant...", reponseListe = null }
        } } },

        //Conversation (niveau 1, pnj 5, personalité 2)
        {"1.5.3", new Conv { interactionListe = new List<Interaction>() {
            new Interaction { id = 1, interaction = "Bonjour ! Il me semble qu’un garde patrouille déjà ici.", reponseListe = new List<Rep>() {
                new Rep { reponse = "Laisse moi passer où je t’enferme dans une cellule !", interacSuiv = 2, soupcon = 30, progress = Unlock.KO },
                new Rep { reponse = "Je viens en back-up ! Un prisonnier est en fuite, on est sur un code 7030 !", interacSuiv = 3, soupcon = 10, progress = Unlock.OK },
                new Rep { reponse = "Je vais voir la directrice de l’asile.", interacSuiv = 4, soupcon = 10, progress = Unlock.KO }
                }
            },
            new Interaction { id = 2, interaction = "GARDES ! GARDES ! GARDES !", reponseListe = null },
            new Interaction { id = 3, interaction = "Hein ? Rien compris...", reponseListe = null },
            new Interaction { id = 4, interaction = "Bizarre, elle est pourtant parti en vacances...", reponseListe = null }
        } } },
    };


    public static Conv GetConv(string id) {
        Conv conv;
        Conv erreur = new Conv();
        erreur.interactionListe = new List<Interaction>();
        erreur.interactionListe.Add(new Interaction { id = 0, interaction = "Je n'ai pas envie de parler", reponseListe = null });

        if (_conv.TryGetValue(id, out conv)) {
            return conv;
        }
        else {
            return erreur;
        }

    }
}