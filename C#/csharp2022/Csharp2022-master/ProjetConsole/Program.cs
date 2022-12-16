
using ProjetDLL;
using ProjetDLL.Comparateurs;
using ProjetDLL.ConceptsObjets.Abstraction;
using ProjetDLL.ConceptsObjets.Agregation;
using ProjetDLL.ConceptsObjets.Encapsulation;
using ProjetDLL.ConceptsObjets.Heritage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetConsole
{

    enum Jours
    {
        LUNDI = 1,
        MARDI,
        MERCREDI,
        JEUDI,
        VENDREDI
    }

    enum Erreurs
    {
        MINEURE=100,
        MAJEURE,
        CRITIQUE
    }

    enum Profils
    {
        ADMIN,
        MANAGER,
        RH
    }

    enum Autorisation
    {
        LECTURE,
        SUPPRESSION,
        MODIFICATION,
        TOUTES
    }

    enum Etat
    {
        MAUVAIS,
        BON,
        NEUF
    }

    class User
    {
        public string nom;
        public Profils profil;
        public List<Autorisation> autorisations = new List<Autorisation>();
    }

    internal class Program
    {
        //Main: point d'entrée d'une application - la méthode qui sera exécuter au démarrage de l'application
        static void Main(string[] args)
        {
            Test.Afficher();


            #region "Variables"

            Console.WriteLine("*********************VARAIBLES*****************");

            //Variable: zone mémoire qui contient une valeur typée
            //types primitifs (simples - type valeur): entiers, réels, boolean, char
            //entiers: byte(1 o), short(2 o), int(4 o), long(8 o)
            //réels: float(4 o), double(8 o), decimal(16 o)
            //char(2 o)
            //boolean(1 o)
            //types complèxes (type réference): Array, string, classe (objet)

            int myInt = 10;
            int myInt2 = myInt;

            myInt = 30;

            Console.WriteLine(myInt2);

            int[] tab = { 10, 20 };
            int[] tab2 = tab;

            tab[0] = 50;

            Console.WriteLine("tab2[0] = " + tab2[0]);

            double myDouble = 10.5;
            bool myBool = false;
            char myChar = 'c';
            string str = "chaine de caractères";

            //Le mot clé var: inférence de type - le compilateur détermine le type de la variable selon la valeur affectée
            var maVariable = 15.5;
            // maVariable = "chaine"; //cette génère une erreur de compilation

            //Contante: une variable qui contient une valeur typée qu'on ne peut pas modifier
            const double MA_CONSTANTE = 20.35;

            /*Convention de nommage:
             * 
             * Classes + méthodes: PascalCase
             * variables: camelCase
             * snake_case: ma_variable
             */

            //Nombre aléatoire:
            Random random = new Random();
            int aleatoire = random.Next(1, 10);

            Console.WriteLine("aleatoire = " + aleatoire);


            #endregion

            #region "Opérateurs"
            Console.WriteLine("*****************OPERATEURS*****************");

            //Arithmétiques: +, -, * , / , %(modulo - reste de la division entière)
            int modulo = 10 % 3;
            Console.WriteLine("modulo = " + modulo);

            //Incrémentation et décrémentaton ++, --:
            int i = 5;
            i++; // i = i + 1;
            i--; //i = i - 1;

            //Opérateurs combinés:
            i += 5; // i = i + 5;
            i *= 2; // i = i * 2
            i -= 5; // i = i - 5

            //Opérateurs de comparaison: == (égalité), <, <=, >, >=, != (différent) - renvois true ou false
            Console.WriteLine(5 > 10); //false

            //Opérateurs logiques: && (et logique), || (ou logique), ! (non logique), ^ (ou exclusif)

            //Table logique:
            //A     B       A&&B    A||B    A^B
            //v     v        v        v      f
            //v     f        f        v      v
            //f     f        f        f      f
            //f     v        f        v      v   

            #endregion

            #region "Formattage de chaines"

            Console.WriteLine("************Formattage de chaines*************");

            //Concaténation:
            Console.WriteLine("myInt = " + myInt);

            //Interpolation
            int v1 = 10, v2 = 15;
            Console.WriteLine("v1 = {0} - v2 = {1}", v1, v2); //version1 de l'interpolation

            Console.WriteLine($"v1 = {v1} - v2 = {v2}"); //version2 de l'interpolation

            Console.WriteLine("v1 = " + v1 + " - v2 = " + v2); //concaténation de chaines

            //Chaine verbatim + caractères d'echappement
            Console.WriteLine("\t Bonjour,\n je suis chez Dawan.\n Formation c#");

            /*
             * \n: retour chariot - retour à la ligne
             * \t: insérer une tabulation
             * \"
             * \'
             * \\
             * 
             */

            Console.WriteLine(@"    Bonjour,
je suis chez Dawan.
Formation c#");

            string chemin = @"c:\test\test.txt";

            #endregion

            #region "Transtypage - conversion de type"

            Console.WriteLine("*******Transtypage************");

            //Conversion implicite: passage d'un type inférieur à un type supérieur
            byte b = 10;
            int myInt4 = b;

            //Conversion explicite: passage d'un type supérieur à un type inférieur
            //Option1: On peut utiliser le CAST: (int), (bool), (byte)....... 
            //CAST: valable uniquement pour le stypes compatibles

            int myInt5 = 10;
            byte myByte = (byte)myInt5; //risque de perte de données

            //Option2: on peut utiliser la classe Convert
            byte myByte2 = Convert.ToByte(myInt5);

            Console.WriteLine("Quel est votre age?");


            //Si la conversion echoue, la classe Convert génère une Exception qu'il faut gérer via le bloc try - catch
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"age = {age}");
            }
            catch (Exception)
            {
                Console.WriteLine("Ne saisir que des chiffres!!!!!!");
            }







            #endregion

            #region "Conditions"

            Console.WriteLine("************CONDITIONS*************");

            //IF-ELSE

            int nb = 5;
            if (nb > 0)
            {
                Console.WriteLine("nb positif");
            }
            else if (nb == 0)
            {
                Console.WriteLine("nb égal zéro");
            }
            else
            {
                Console.WriteLine("nb négatif");
            }

            //Switch: variante du if/else

            int note = 10;

            switch (note)
            {
                case 0:
                    Console.WriteLine("recalé");
                    break;
                case 10:
                case 11:
                case 12:
                    Console.WriteLine("Juste la moyenne");
                    break;

                default:
                    Console.WriteLine("Réussite garantie");
                    break;
            }

            //Opérateur ternaire: (condition) ? vraie code1: fausse code2

            bool myBool2 = (10 > 5) ? false : true; // if(10>5) { myBool2 = false} else{ myBool2 = true}
            Console.WriteLine($"myBool2 = {myBool2}");

            #endregion

            #region "Boucles"

            Console.WriteLine("****************BOUCLES**************");
            //Boucles itératives: for - foreach
            //Boucles conditionnelles: while - Do/While

            //For: connaitre le nombre d'itérations

            for (int index = 1; index < 5; index++)
            {
                Console.WriteLine("Passage N°: " + index);
            }

            //Foreach: permet de faire un parcours complet d'une collection (tableau, liste.......)
            int[] tableau = { 10, 20, 30, 40 };

            foreach (int item in tableau) //pour chaque int item contenu dans le tableau
            {
                Console.WriteLine(item);
            }

            //While:

            int x = 1;

            while (x < 5) //tant que x est inférieur à 5
            {
                Console.WriteLine("Passage N°: " + x);
                x++;
            }

            //Do-While: le Do-While s'exécute au moins 1 fois

            do //Fais jusqu'à x < 10
            {
                Console.WriteLine("Passage N°: " + x);
                x++;
            } while (x < 10);

            #endregion

            #region "Tableaux"

            Console.WriteLine("***************TABLEAUX*************");

            //Tableau: ensemble d'éléments typés - collection statique

            //1 dimension

            //1ère façon de déclarer un tableau
            int[] monTableau = new int[3]; //tableau de 3 cases
            monTableau[0] = 10;
            monTableau[1] = 10;
            monTableau[2] = 10;

            //2ème façon de déclarer un tableau
            int[] monTableau2 = { 10, 20, 30 };

            //Taille du tableau

            Console.WriteLine("Taille du tableau = " + monTableau.Length);

            //Lister le contenu du tableau

            //Foreach
            foreach (int m in monTableau)
            {
                Console.WriteLine(m);
            }

            //For
            for (int index = 0; index < monTableau.Length; index++)
            {
                Console.WriteLine(monTableau[index]);
            }

            //2 dimensions
            int[,] matrice = new int[2, 3];
            matrice[0, 0] = 10;
            matrice[0, 1] = 20;
            matrice[0, 2] = 30;
            matrice[1, 0] = 40;
            matrice[1, 1] = 50;
            matrice[1, 2] = 60;

            int[,] matrice2 = { { 10, 20, 30 }, { 40, 50, 60 } };

            //Récuperer le nombre de lignes
            Console.WriteLine("Nombre de lignes: " + matrice.GetLength(0)); //2
            Console.WriteLine("Nombre de colonnes: " + matrice.GetLength(1)); //3

            Console.WriteLine(matrice2[1, 0]); // 40

            //Lister le contenu de la matrice

            //Boucler sur les lignes
            for (int ligne = 0; ligne < matrice.GetLength(0); ligne++)
            {
                //Boucler sur les colonnes
                for (int colonne = 0; colonne < matrice.GetLength(1); colonne++)
                {
                    Console.WriteLine(matrice[ligne, colonne]);
                }
            }

            #endregion

            #region "Enumeration"

            Console.WriteLine("******************ENUM************");
            //Enum: une liste de contantes

            Jours j = Jours.LUNDI; //Enum comparée à un tableau, rend le code plus facile à lire
            Console.WriteLine(j);

            Console.WriteLine("Quel est votre code d'erreur (100 - 101- 102)?");
            int codeErreur = Convert.ToInt32(Console.ReadLine());

            Erreurs error = (Erreurs)codeErreur;

            Console.WriteLine("Votre erreur est: " + error);

            User user = new User();
            user.nom = "dawan";
            user.profil = Profils.ADMIN;
            user.autorisations.Add(Autorisation.LECTURE);
            user.autorisations.Add(Autorisation.MODIFICATION);
            user.autorisations.Add(Autorisation.SUPPRESSION);

            if (user.autorisations.Contains(Autorisation.SUPPRESSION))
            {
                Console.WriteLine("Suppression OK");
            }
            else
            {
                Console.WriteLine("Action interdite");
            }

            #endregion

            #region "Méthodes"

            Console.WriteLine("*****************METHODES***************");
            //Méthode: un ensemble d'instructions réutilisables
            //Procédure: une méthode qui ne renvoie aucun résultat
            //Fonction: une méthode qui renvoie un résultat
            //Déclaration d'une méthode:
            // visibilité [static] type_du_retour (void) nom_méthode(paramètres) { instructions; }

            /* MesMethodes mmmm = new MesMethodes(); //instancier la classe MesMethodes ( créer un objet de cette classe)
             mmmm.Afficher();*/

            MesMethodes.Afficher();

            MesMethodes.Afficher("Dawan");

            int resultat = MesMethodes.Somme(10, 20);

            Console.WriteLine($"somme = {resultat}");

            int[] myTab = { 10, 1, 15, 35, 7, 12, 5, 2, -5 };

            MesMethodes.Afficher(myTab);

            int sommeTab = MesMethodes.SommeTab(myTab);

            Console.WriteLine($"Somme de myTab = {sommeTab}");
            //Console.WriteLine($"Somme de myTab = {MesMethodes.SommeTab(myTab)}"); -- 2ème appel de la méthode SommeTab

            Console.WriteLine($"Moyenne de myTab = {MesMethodes.MoyenneTab(myTab)}");
            Console.WriteLine($"Min de myTab = {MesMethodes.MinTab(myTab)}");

            //Appel de la méthode qui possède des params optionnels
            MesMethodes.SommeOptionnelle(10, 25); //45
            MesMethodes.SommeOptionnelle(10, 25, 45); //80

            MesMethodes.PrixTTC(120);
            MesMethodes.PrixTTC(120, 0.055);

            int val1 = 10, val2 = 20;

            Console.WriteLine($"Avant permutation: val1 = {val1} - val2 = {val2}"); // 10 - 20
            MesMethodes.Permuter(ref val1, ref val2);
            Console.WriteLine($"Après permutation: val1 = {val1} - val2 = {val2}"); // 20 - 10

            int[] tab5 = { 1, 2, 3 };

            Console.WriteLine("Tab5 avant modif:");
            MesMethodes.Afficher(tab5);

            MesMethodes.ModifierTableau(tab5);

            Console.WriteLine("Tab5 après modif:");
            MesMethodes.Afficher(tab5);

            //Appel de la méthode avec des params en sortie

            double produit = 0, moyenne = 0;

            double mySomme = MesMethodes.Calculer(10, 20, out produit, out moyenne);
            Console.WriteLine($"somme = {mySomme}");
            Console.WriteLine($"produit = {produit}");
            Console.WriteLine($"moyenne = {moyenne}");

            string chaine = "15fdfgshgf";
            int myInt8 = 0;
            bool conversion = int.TryParse(chaine, out myInt8);
            if (conversion)
            {
                Console.WriteLine($"Conversion OK. myInt8 = {myInt8}");
            }
            else
            {
                Console.WriteLine($"Echec conversion. myInt8 = {myInt8}");
            }

            //Appel de la méthode qui reçoit un nombre variable d'arguments
            MesMethodes.Produit(2, 3);
            MesMethodes.Produit(2, 3, 4);
            MesMethodes.Produit(2, 3, 5, 6);
            MesMethodes.Produit(2, 3, 10, 10, 20, 50);




            #endregion

            #region "Concepts Objets"

            Console.WriteLine("****************CONCEPTS OBJETS**************");

            //Encapsulation - Héritage - Polymorphisme - Abstraction - Agrégation

            //Programmation procédurale
            double longueur = 20;
            double largeur = 15;
            double surf = Surface(longueur, largeur);
            Console.WriteLine("Surafce du rec......");

            double longueur1 = 20;
            double largeur1 = 15;
            double surf1 = Surface(longueur1, largeur1);

            //Encapsulation:
            //1- Rassembler dans une seule et mm classe les paramétres et les fonctions qui traitent du mm sujet
            //2- L'accès aux attributs (propriétés) d'une classe passe forcément par les accesseurs (getteurs/setteurs) - les attributs d'une
            //classe doivent être privés
            //Encapsulation: concerne les attributs d'une classes - ils doivent être privés et accéssibles via 
            //les getteurs/setteurs

            Console.WriteLine("************************ENCAPSULATION***************************");

            Rectangle rec = new Rectangle();
            rec.Longueur = -20;
            
            rec.Surface();
            CompteBancaire cpte = new CompteBancaire();
            cpte.Numero = "sqqsd158";
            cpte.Solde = 1500;

            //CompteBancaire(): méthode spéciale qui porte le nom de la classe qu'on appelle constructeur
            //son rôle est d'instancier la classe en question (créer des objets) en initialisant leurs attributs
            //Toute classe quelque soit son type possède forcément le contructeur par defaut

            CompteBancaire cpte2 = new CompteBancaire(); // Numero = null * Solde = 0
            Console.WriteLine("Numéro = "+cpte2.Numero);
            Console.WriteLine("Solde = "+cpte2.Solde);

            CompteBancaire cpte3 = new CompteBancaire("sdqsd158", 2500);
            Console.WriteLine(cpte3);

            //cpte3.Depot(1500);
            //cpte3.Retrait(1000);

            CompteBancaire.ModifierBanque("LCL");
            Console.WriteLine("Nombre de comptes: "+CompteBancaire.Compteur);

            CompteBancaire cpte4 = new CompteBancaire("sdqsd158", 2500);

            Console.WriteLine("***********Equals***********");

            Console.WriteLine(cpte4.Equals(cpte3));
            //par defaut la méthode Equals compare les réferences
            //Pour comparer les attributs des objets, on doit redéfinir la méthode Equals dans la classe CompteBancaire
            //Les 2 variables cpte3 et cpte4 poitent vers des objets différent en mémoire


            //Héritage:
            //Une classe enfant à accès à tous les membres publiques définies dans la classe mère

            Console.WriteLine("************************HERITAGE***************************");
            Animal a = new Animal();
            a.Nom = "animal";
            a.Age = 5;
            

            Chat c = new Chat();
            c.Nom = "chat";
            c.Age = 5;

            Animal a2 = new Animal("a2", 15);
            Chat c2 = new Chat("chat2", 5, "race");

            c2.Identite();

            Animal a4 = new Animal();
            Animal a5 = new Chat();
            Animal a6 = new Chien();

            object obj = "sqsds";
            object obj1 = true;
            object obj2 = 15;
            object obj3 = new Animal();

            //Un objet de type Animal peut prendre plusieurs formes - Polymorphisme
            //Polymorphisme est une conséquence de l'héritage. Le fait qu'un objet puisse prendre la forme de tous
            //les objets enfants

            int[] intTab = new int[2];
            intTab[0] = 10;
            intTab[1] = 25;

            //Collection polymorphique:

            Animal[] animaux = new Animal[3];
            animaux[0] = new Animal();
            animaux[1] = new Chat();
            animaux[2] = new Chien();

            Identite(new Animal());
            Identite(new Chat());
            Identite(new Chien());

            Identite2(new Animal());

            Console.WriteLine("************************Abstraction***************************");
            //Une classe abstraite est une classe qu'on ne peut pas instancier
            Homme h = new Homme();
            Femme f = new Femme("","");
            Personne p = new Femme("nom","prenom");
            f.Identite();
            h.Identite();

            MyMethod(new Homme());
            MyMethod2(new ClientImpl());

            Console.WriteLine("************************Agrégation - Association - Composition*************");
            Client client = new Client("nomClient", new Adresse(10, "rue de lyon 75010 Paris"));

            IClient ic = new ClientImpl();
            /*
             * TP_Objets_2:
             * Un client souhaite gérer les salariés de son ETS
             * - Tous les salariés possèdent un nom, un prenom, un âge compris entre 18 et 65 et un salaire minimum de 2000
             * - Tous les salariés doivent signaler leur présence (pointer)
             * - Dev: leur période d'essai est de 2 mois, et chaque Dev possède un Manager
             * - Consultant: leur période d'essai est de 3 mois, et chaque consultant possède un Manager
             * - Manager: chaque manager gère une collection de salariés
             * - Seul le Manager peut modifier le salaire d'un salarié autre qu'un Manager.
             * 
             * Définir le modèle objet
             */

            #endregion

            #region "Exception"

            Console.WriteLine("***********************EXCEPTION*****************");
            //Exception: une erreur qui provoque l'arrêt de l'application
            //Pour éviter l'arrêt de l'application on doit gérer l'exception
            //Pour gérer l'exception, on utilise le bloc try - catch
            //Finally: optionnel

            int val = 10;
            int[] myTableau = { 10, 15 };
            


            try
            {
              
                Console.WriteLine(val / 2);
                Console.WriteLine(myTableau[0]);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Remplir un fichier de log.....");
            }
            catch(IndexOutOfRangeException e1)
            {
                Console.WriteLine("Remplir une table dans la BD......");
            }
            finally
            {
                //Sert en pratique à libérer les ressources utilisées dans le bloc try: (BD, fichiers, API....)
                Console.WriteLine("Bloc finally.........");
            }

           

            try
            {
                Division(0);
            }
            catch (Exception)
            {
                //Chaque appelant peut choisir le traitement à mettre en place: remplir un fichier, une BD....
            }


            //Test de l'exception personnalisée:
            CompteBancaire compte = new CompteBancaire("sdqsdqs", 1500);

            
            try
            {
                compte.Retrait(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("suite de l'application.........");

            #endregion

            #region "La classe String"

            Console.WriteLine("**************CLASSE STRING***************");

            //On peut créer des objets de type string sans faire appel au constructeur, via une chaine littérale

            string str2 = "test";
            str2.Concat("e"); //les objets de type string sont immuables, on ne peut pas les modifier en mémoire

            string str3 = new string('c', 4); 

            Console.WriteLine(str2);

            GC.Collect(); //appel explicite au Garabge collector - rien ne garantie son passage immédiat
                          //La mémoire est gérée par le framework.

            string phrase = " ceci est une phrase "; //un objet de type string, en mémoire c'est un tableau de caractères

            Console.WriteLine("Taille de phrase: " + phrase.Length); // 21
            Console.WriteLine("2ème caractère de phrase: " + phrase[1]); //c
            Console.WriteLine("2émé caractère de phrase: "+ phrase.ElementAt(1)); //c
            Console.WriteLine("Suppression des espaces de début et de fin de chaine: "+phrase.Trim());
            Console.WriteLine("Phrase contient le mot ceci? "+phrase.Contains("ceci")); //true
            Console.WriteLine("Remplacer phrase par paragraphe: "+phrase.Replace("une phrase", "un paragraphe"));
            Console.WriteLine("Phrase commence par ceci? "+phrase.StartsWith("ceci")); //false
            Console.WriteLine("Phrase se termine par phrase ? "+phrase.EndsWith("phrase ")); //true

            //Extraction de sous chaine
            string sousChaine1 = phrase.Substring(3);
            Console.WriteLine($"souschaine1 = {sousChaine1}");

            string sousChaine2 = phrase.Substring(1, 4);
            Console.WriteLine($"souschaine2 = {sousChaine2}");

            //Chaine sous format CSV - Split
            string chaineCSV = "dawan;paris lyon";
            string[] mots = chaineCSV.Split(';', ' ');
            foreach (string item in mots)
            {
                Console.WriteLine(item);
            }

            //Join: static
            string phrase2 = string.Join(" ", "Je","suis","en","formation", "chez","Dawan");
            Console.WriteLine(phrase2);

            Console.WriteLine($" Nombre de mots: { MesMethodes.NombreMots(" ceci est  une chaine ")}");
            Console.WriteLine($"L'inverse de dawan est: {MesMethodes.InverserChaine("dawan")}");
            Console.WriteLine($"sms est un palindrôme ? {MesMethodes.VerifPalindrome("Sms")}");
            string paragraphe = "Dawan erzerze dawan sdqsdsq dawan.";
            Console.WriteLine($"Nombre occurrences de dawan: {MesMethodes.NombreOccurrences(paragraphe, "dawan")}");


            #endregion

            #region "La classe DateTime"

            Console.WriteLine("******************DateTime*****************");

            //Création d'objets DateTime
            DateTime dt1 = DateTime.Now;

            Console.WriteLine($"dt1 = {dt1}");

            DateTime dt2 = DateTime.Today;

            Console.WriteLine($"dt2 = {dt2}");

            DateTime dt3 = new DateTime(2019, 3, 1, 17, 52, 35);
            Console.WriteLine($"dt3={dt3}");

            //Comparaison de dates

            Console.WriteLine("Comparaison de dt1 à dt2: " + dt2.CompareTo(dt1));
            Console.WriteLine("Egalité d'objets de type Date: " +dt1.Equals(dt2));

            //Opérations sur les objets Date
            Console.WriteLine("Ajouter 2 jours et demi à dt1: " + dt1.AddDays(2.5));
            Console.WriteLine("dt1 - dt2: "+ (dt1.Subtract(dt2)));

            //Recherches sur des dates:
            Console.WriteLine("Date de dt1: "+ dt1.Date);
            Console.WriteLine("Jour du mois de dt1: " + dt1.Day);
            Console.WriteLine("Jour de la semaine de dt1: "+ dt1.DayOfWeek);
            Console.WriteLine("Jour de l'année de dt1: "+ dt1.DayOfYear);

            //Formatter les objets dates:

            Console.WriteLine("ToLongDate: "+dt1.ToLongDateString());
            Console.WriteLine("ToLongTime: "+dt1.ToLongTimeString());
            Console.WriteLine("ToShortDate: "+dt1.ToShortDateString());
            Console.WriteLine("ToShortTime: "+dt1.ToShortTimeString());

            #endregion

            #region "Collections"

            Console.WriteLine("*****************COLLECTIONS*******************");
            /*
             * 2 types de collections: faiblement typées - fortement typées
             * Une collection: est un tableau dynamique (à taille variable)
             */

            Console.WriteLine("***Collection faiblement typée****");
            var myArray = new ArrayList();

            Console.WriteLine("Taille de myArray: "+myArray.Count); //0
            myArray.Add(10);
            myArray.Add(true);
            myArray.Add("dawan");

            Console.WriteLine("Taille de myArray après ajout: "+myArray.Count); //3

            Console.WriteLine("myArray contient la chaine dawan? "+myArray.Contains("dawan")); //true

            Console.WriteLine("Index de dawan dans myArray: "+myArray.IndexOf("dawan")); //2

            myArray.Insert(2, 10.5);

            Console.WriteLine("Index de dawan après Insert: "+myArray.IndexOf("dawan")); //3

            myArray.Add("dawan");

            Console.WriteLine("Taille du myArray: "+myArray.Count); //5 ---
                                                                    //ArrayList: collection ordonnée (possède un index
                                                                    //et qui accèpte les doublons

            foreach (object item in myArray)
            {
                Console.WriteLine(item);
            }

            myArray.Remove("dawan"); //La première occurrence de dawan sera supprimée du tableau

            Console.WriteLine("**********FOREACH après le remove");

            foreach (object item in myArray)
            {
                Console.WriteLine(item);
            }

            myArray.Clear();

            Console.WriteLine("Taille de myArray après Clear: "+myArray.Count ); //0

            myArray.Add(10); //0
            myArray.Add(true); //1
            myArray.Add("test"); //2
            myArray.Add("test"); //3

            Console.WriteLine("*********Test avant remove*****");
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
            /*
             * pas possible des faire des Remove dans un foreach
            foreach (var item in myArray)
            {
                if (item.Equals("test"))
                {
                    myArray.Remove(item);
                }
            }
            */

            for (int indexe = myArray.Count - 1; indexe >= 0; indexe--)
            {
                if (myArray[indexe].Equals("test"))
                {
                    myArray.RemoveAt(indexe);
                }
            }

            Console.WriteLine("*********Test après remove*************");

            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("***Collections fortement typée****");
            //List

            List<string> chaines = new List<string>();

            Console.WriteLine("Taille de la liset: "+chaines.Count); //0

            chaines.Add("test");
            chaines.Add("lyon");
            chaines.Add("dawan");
            chaines.Add("paris");
            chaines.Add("dawan1");
            chaines.Add("dawan2");
            chaines.Add("dawan3");
            chaines.Add("dawan4");

            chaines.Remove("test");
            chaines.RemoveAt(0);
            chaines.RemoveRange(0, 2);

            foreach (string item in chaines)
            {
                Console.WriteLine(item);
            }

            //Dictionnaire: stockage de type clé:valeur

            Console.WriteLine("*************DICTIONARY*****************");

            Dictionary<int, string> dictionnaire = new Dictionary<int, string>();

            Console.WriteLine("Taille du dictionnaire: "+dictionnaire.Count); //0

            dictionnaire.Add(100, "admin123");
            dictionnaire.Add(150, "password");

            if (dictionnaire.ContainsKey(150))
            {
                Console.WriteLine("Valeur associée à la clé 150: "+dictionnaire[150]);
            }
            else
            {
                Console.WriteLine("Clé introuvable");
            }

            //Lister le contenu du dictionnaire:

            //foreach sur les clé

            foreach (int cle in dictionnaire.Keys)
            {
                Console.WriteLine($"Clé = {cle} - Valeur = {dictionnaire[cle]}");
            }

            //foreach sur les valeurs

            foreach (string valeur in dictionnaire.Values)
            {
                Console.WriteLine($"Valeur = {valeur}");
                
            }

            List<CompteBancaire> comptesCrediteurs = new List<CompteBancaire>();
            comptesCrediteurs.Add(new CompteBancaire("sqdqsd", 1500));
            comptesCrediteurs.Add(new CompteBancaire("dfds158", 4500));
            comptesCrediteurs.Add(new CompteBancaire("tgb158", 2000));


            List<CompteBancaire> comptesDebiteurs = new List<CompteBancaire>();
            comptesDebiteurs.Add(new CompteBancaire("sdqsddze", -1500));
            comptesDebiteurs.Add(new CompteBancaire("8520dqsd", -4500));
            comptesDebiteurs.Add(new CompteBancaire("pmn458", -2000));

            Dictionary<string, List<CompteBancaire>> comptesDictionnaire = new Dictionary<string, List<CompteBancaire>>();

            comptesDictionnaire.Add("crediteurs", comptesCrediteurs);
            comptesDictionnaire.Add("debiteurs", comptesDebiteurs);

            //Lister les comptes débiteurs à partir du dictionnaire

            if (comptesDictionnaire.ContainsKey("debiteurs"))
            {
               foreach(CompteBancaire cp in comptesDictionnaire["debiteurs"])
                {
                    Console.WriteLine( cp);
                }
            }



            #endregion

            #region "Tri de collections"

            Console.WriteLine("***********TRI COLLECTIONS*******************");

            List<CompteBancaire> listComptes = new List<CompteBancaire>();
            listComptes.Add(new CompteBancaire("sdqsdsqd", 4500));
            listComptes.Add(new CompteBancaire("pmlo158", 1200));
            listComptes.Add(new CompteBancaire("sdsqd155", 900));
            listComptes.Add(new CompteBancaire("sdqsdsqd", 3200));

            //Pour que la méthode Sort puisse trier la liste des comptes, elle doit comparer les comptes de cette liste
            //Pour comparer 2 comptes bancaire, on a besoin de la méthode CompareTo (la classe compteBancaire doit imlémenter
            //la méthode CompareTo définie dans l'interface IComparable

            listComptes.Sort();

            foreach (var item in listComptes)
            {
                Console.WriteLine(item);
            }

            listComptes.Sort(new SoldeDecroissant());

            Console.WriteLine("**********Solde décroissant**********");

            foreach (var item in listComptes)
            {
                Console.WriteLine(item);
            }

            listComptes.Sort(new SoldeCroissant());

            Console.WriteLine("**********Solde Croissant**********");

            foreach (var item in listComptes)
            {
                Console.WriteLine(item);
            }




            #endregion

            #region "Fichiers"

            Console.WriteLine("******************FICHIERS***************");
            /*
             * .net fournit un certain nombre de classes qui nous permettent de manipuler les fichiers et les dossiers
             * Directory: pour les répertoires
             * File et FileInfos: ces 2 classes proposent les mm méthodes, sauf qu'elles d'instance pour 
             * FileInfos et static pour File
             * 
             * Pour les opérations de lecture/écriture: StreamReader (lecture) / StreamWriter (écriture)
             * 
             */

            //Créer un dossier:
            Directory.CreateDirectory("dossier"); //Chemin relatif à l'emplacement du .exe bin/debug
            Directory.CreateDirectory(@"c:\dossier"); //chemin absolut

            //Lister le contenu d'un répertoire:
            string[] files = Directory.GetFiles(@"c:\test");

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }

            string[] txtFiles = Directory.GetFiles(@"c:\test", "*.txt");

            Console.WriteLine("****** txtFiles:");
            foreach (var item in txtFiles)
            {
                Console.WriteLine(item);
            }

           string[] allTxtFiles = Directory.GetFiles(@"c:\test", "*.txt", SearchOption.AllDirectories);

            Console.WriteLine("********* Tous les dossiers:");
            foreach (var item in allTxtFiles)
            {
                Console.WriteLine(item);
            }

            //Classe File
            string source = @"c:\test\source.txt";
            string cible = @"c:\test\cible.txt";

            File.Copy(source, cible, true);

            File.Delete(@"c:\test\ToDelete.txt");

            FileInfo info = new FileInfo(@"c:\test\cible.txt");

            Console.WriteLine("Date création du fichier: "+info.CreationTime);
            Console.WriteLine("Date de dernière modification: "+info.LastWriteTime);
            Console.WriteLine("Date du dernier accès au fichier: "+info.LastAccessTime);
            Console.WriteLine("Extension du fichier: "+info.Extension);
            Console.WriteLine("Taille du fichier: "+info.Length);

            /*
             * Lecture/Ecriture:
             * Pour les opérations de lecture/écriture, on utilise un flux (stream)
             * flux (stream): canal intermédiaire entre la source et la destination
             * 1- Charger le fichier dans un flux en lecture/écriture
             * 2- Exécution des opérations (lecture/écriture)
             * 3- Fermeture du flux
             * 
             */

            Console.WriteLine("************LECTURE D'UN FICHIER***************");

            StreamReader sr = new StreamReader(@"c:\test\cible.txt");
            string contenu = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine(contenu);

            Console.WriteLine("************ECRITURE DANS UN FICHIER***************");

            StreamWriter sw = new StreamWriter(@"c:\test\ecriture.txt");
            sw.Write("ceci est le contenu du fichier!!!!!!!");
            /*Console.WriteLine("Votre nom:");
            string nom = Console.ReadLine();
            sw.WriteLine();
            sw.WriteLine("Nom: " + nom);

            Console.WriteLine("Votre prénom:");
            string prenom = Console.ReadLine();

            sw.WriteLine("Prénom: " + prenom);*/

            sw.Close();

            string content = Tools.LectureFichier(@"c:\test\fichier.txt");
            Console.WriteLine(content);

            Tools.EcritureFichier(@"c:\test\new.txt", "nouveau contenu de new");


            #endregion

            #region "Sérialisation"

            //Sérialisation: mécanisme qui permet de sauvegarder l'état d'un objet dans un support physique de persistence
            //fichier, BD.....etc
            //3 types de sérialisation: binaire, XML, JSON

            Console.WriteLine("******************SERIALISATION***************");
            List<CompteBancaire> lst = new List<CompteBancaire>();
            lst.Add(new CompteBancaire("qsqdssqd", 1500));
            lst.Add(new CompteBancaire("mplo158", 3000));
            lst.Add(new CompteBancaire("wwww152", 2896));


            Console.WriteLine("***************SERIALISATION BINAIRE*************");
            Tools.ExportBIN(@"c:\test\comptes.bin", lst);

            List<CompteBancaire> comptesBIN = Tools.ImportBIN(@"c:\test\comptes.bin");

            foreach (CompteBancaire item in comptesBIN)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("***************SERIALISATION XML*************");

            Tools.ExportXML(@"c:\test\comptes.xml", lst);

            foreach (var item in Tools.ImportXML(@"c:\test\comptes.xml"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("***************SERIALISATION JSON*************");

            Tools.ExportJSON(@"c:\test\comptes.json", lst);

            foreach (var item in Tools.ImportJSON(@"c:\test\comptes.json"))
            {
                Console.WriteLine(item);
            }

            #endregion

            

            //Maintenir la console active
            Console.ReadLine();
        }

        private static double Surface(double longueur, double largeur)
        {
            return longueur * largeur;
        }

        //Polymorphisme par sous typage
        public static void Identite(Animal a)
        {
            a.Identite();
        }

        //Polymorphisme AD-HOC - Exige des contrôles
        public static void Identite2(object o)
        {
            
            if (o is Animal)
            {
                Animal a = (Animal)o;
                a.Identite();
            }
        }

        /// <summary>
        /// Méthode qui génère une exception si x = 0
        /// </summary>
        /// <param name="x"></param>
        /// <exception cref="DivideByZeroException"></exception>
        public static void Division(int x)
        {
            //Option1: gérer l'exception dans la méthode

            /*  try
              {
                  Console.WriteLine(10 / x);
              }
              catch (Exception e)
              {
                  Console.WriteLine("Exception gérée par la méthode....");
                  Console.WriteLine(e.Message);
                  Console.WriteLine(e.StackTrace);
              }*/

            //Option2: faire une remontée d'exception - plus utilisée en pratique

            if (x != 0)
            {
                Console.WriteLine(10 / x);
            }
            else
            {
                //Déclencher une exception
                //throw mot clé qui permet de déclencher une exception
                throw new DivideByZeroException();
            }
            
        }
        public static void MyMethod(Personne p)
        {

        }

        public static void MyMethod2(IClient c)
        {

        }
    }
}
