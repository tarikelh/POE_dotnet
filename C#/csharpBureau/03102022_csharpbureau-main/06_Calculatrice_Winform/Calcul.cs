namespace _06_Calculatrice_Winform
{
    public class Calcul
    {
        #region Private properties

        private List<Operator> _operatorsList;

        private List<Double> _numberList;

        private int _numberOfLevels;

        private string _expression;

        #endregion

        #region Public properties

        public string Expression
        {
            get { return _expression; }
            set
            {
                // Si l'expression ne contient pas le même nombre de parenthèses ouvertes et fermées
                if (value.Count(f => (f == '(')) != value.Count(f => (f == ')')))
                {
                    throw new Exception("Expression non valide");
                }

                //retourne la liste des nombres présents dans le calcul à faire
                _numberList = GetNumbers(value);

                //Si la liste est nulle c'est que l'expression n'est pas valide...
                if (_numberList == null)
                {
                    throw new Exception("Expression non valide");
                }

                //retourne la liste des nombres opérateurs dans le calcul à faire
                _operatorsList = GetOperators(value);

                //Si la liste est nulle c'est que l'expression n'est pas valide...
                if (_operatorsList == null)
                {
                    throw new Exception("Expression non valide");
                }

                _expression = value;
            }
        }

        #endregion

        #region Constructors
        public Calcul(string expression)
        {
            Expression = expression;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retourne le résultat du calcul sous forme de chaine de caractères
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            //On calcule le nombre de niveaux imbriqués du calcul à faire
            // ex : 1 + 2 => _numberOfLevels = 0
            // ex : 1 + (2*3/2) => _numberOfLevels = 1
            // ex : 1 + (2*3/(2-0.5)) => _numberOfLevels = 2
            _numberOfLevels = GetNumberOfLevels(_operatorsList);

            //On effectue les calculs par ordre de priorité décroissants
            while (_numberOfLevels >= 0)
            {
                Operator currentOperator;
                //Pour chaque niveau de priorité on commence par faire toutes les multiplications et divisions
                for (int i = 0; i < _operatorsList.Count; i++)
                {
                    currentOperator = _operatorsList[i];

                    if (currentOperator.Priority == _numberOfLevels && (currentOperator.Type == '*' || currentOperator.Type == '/'))
                    {
                        //On remplace le premier nombre de l'opération en cours par le résultat de la multiplication ou de la division
                        _numberList[i] = currentOperator.Type == '*' ? _numberList[i] * _numberList[i + 1] : _numberList[i] / _numberList[i + 1]; //equivalent à if(operator[i]=='*') numbers[i] =... else...

                        //On supprime le second des 2 nombres courants de la liste des nombres à calculer
                        _numberList.RemoveAt(i + 1);

                        //On supprime l'opérateur courant de la liste des opérateurs
                        _operatorsList.RemoveAt(i);

                        //On décrémente l'indice de la boucle pour compemser la suppression
                        i--;
                    }
                }

                //Il ne doit plus rester que des additions et des soustractions à ce niveau de priorité
                for (int i = 0; i < _operatorsList.Count; i++)
                {
                    currentOperator = _operatorsList[i];

                    if (currentOperator.Priority == _numberOfLevels && (currentOperator.Type == '+' || currentOperator.Type == '-'))
                    {
                        currentOperator = _operatorsList[i];

                        _numberList[i] = currentOperator.Type == '+' ? _numberList[i] + _numberList[i + 1] : _numberList[i] - _numberList[i + 1];
                        _numberList.RemoveAt(i + 1);
                        _operatorsList.RemoveAt(i);
                        i--;
                    }
                }

                _numberOfLevels--;
            }

            //A la fin notre tableau de nombres ne contient plus que le résultat.
            //On en prend donc le premier indice qu'on convertit en string pour affichage...
            return _numberList[0].ToString();
        }
        #endregion

        #region Private helpers

        /// <summary>
        /// Classe représentant un type d'opération et son niveau de priorité dans le calcul
        /// </summary>
        private class Operator
        {
            public char Type;

            public int Priority;

            public Operator(char type, int priority)
            {
                this.Type = type;
                this.Priority = priority;
            }
        }

        /// <summary>
        /// Retourne la liste de nombres présents dans l'expression
        /// </summary>
        /// <param name="userInput">Expression à calculer</param>
        /// <returns></returns>
        private static List<double> GetNumbers(string userInput)
        {
            List<double> numbers = new List<double>();

            try
            {
                //On splite l'expression à calsuler par rapport à chacun des 4 opérateurs possibles...
                //... et on récupère le split dans un array de string
                string[] strArray = userInput.Split('+', '-', '*', '/');

                // On crée une chaine de caractère temporère pour sanitiser chacune des chaines de notre array...
                string strTemp;

                // On convertie chacune des chaines récupérées par le split en double et on l'ajoute à notre liste de nombre
                foreach (string str in strArray)
                {
                    // Pour ce faire on commmmence par supprimer les espaces de début et de fin
                    strTemp = str.Trim();

                    // Normalement il ne devrait donc plus y avoir d'espaces.
                    // S'il en reste c'est que l'expression de départ est non valide. ex "1 + 3 .1" au lieu de "1 +3.1"
                    //Le problème c'est que Convert.ToDouble("3 .1") s'execute comme Convert.ToDouble("3.1")
                    // Donc on remplace les espaces restants par la lettre X pour faire planter Convert.ToDouble("3X.1")
                    strTemp = strTemp.Replace(' ', 'X');
                    // On remplace les '.' par des ',' parce que Convert.ToDouble("3.1") plante...
                    strTemp = strTemp.Replace('.', ',');

                    //On supprime les parenthèses de la chaine à convertir en double
                    strTemp = strTemp.Replace(')', ' ').Replace('(', ' ');

                    //On convertit la chaine restante en double et on l'ajoute à notre liste de nombres
                    numbers.Add(Convert.ToDouble(strTemp));
                }
            }
            catch
            {
                return null;
            }

            return numbers;
        }

        /// <summary>
        /// Retourne la liste ordonnée des opérateurs présents dans l'expression à calculer
        /// </summary>
        /// <param name="userInput">Expression à calculer</param>
        /// <returns></returns>
        private static List<Operator> GetOperators(string userInput)
        {
            List<Operator> OperatorsList = new List<Operator>();

            int currentPriority = 0;

            try
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if ("(".Any((f => (f == userInput[i]))))
                        currentPriority++;
                    else if (")".Any((f => (f == userInput[i]))))
                        currentPriority--;
                    else if ("+-*/".Any((f => (f == userInput[i]))))
                        OperatorsList.Add(new Operator(userInput[i], currentPriority));
                }
            }
            catch
            {
                return null;
            }

            return OperatorsList;
        }

        /// <summary>
        /// Retourne le niveau d'intrication de l'expression à calculer
        /// </summary>
        /// <param name="operators">Liste des opérateurs présents dans l'expression à calculer</param>
        /// <returns></returns>
        private static int GetNumberOfLevels(List<Operator> operators)
        {
            int level = 0;
            foreach (Operator op in operators)
            {
                if (op.Priority > level) level = op.Priority;
            }
            return level;
        }
        #endregion

    }
}
