using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _09_UserControls.Composants
{

    public partial class MemberCard : UserControl
    {
        // Dependency property : propdb tab tab
        public string Titre
        {
            get { return (string)GetValue(TitreProperty); }
            set { SetValue(TitreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitreProperty =
            DependencyProperty.Register("Titre", typeof(string), typeof(MemberCard), new PropertyMetadata(String.Empty));

        public Brush Couleur
        {
            get { return (Brush)GetValue(CouleurProperty); }
            set { SetValue(CouleurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Couleur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CouleurProperty =
            DependencyProperty.Register("Couleur", typeof(Brush), typeof(MemberCard), new PropertyMetadata(Brushes.White));


        public MemberCard()
        {
            InitializeComponent();
        }

        private void OnJoindreClick(object sender, RoutedEventArgs e)
        {
            // Déclenchement d'un évènement routé personnalisé
            RaiseEvent(new RoutedEventArgs(JoindreClickEvent));
        }

        // Déclaration et enregistrement d'un routed Event

        public static readonly RoutedEvent JoindreClickEvent = EventManager.RegisterRoutedEvent(
                                                                                                 nameof(JoindreClickHandler),
                                                                                                 RoutingStrategy.Bubble,
                                                                                                 typeof(RoutedEventHandler),
                                                                                                 typeof(MemberCard)
                                                                                                    );
        public event RoutedEventHandler JoindreClickHandler
        {
            add { AddHandler(JoindreClickEvent, value); } // Ajout de l'évènement "JoindreClickEvent" au gestionnaire d'évènements
            remove { RemoveHandler(JoindreClickEvent, value); } // Supression...
        }
    }
}
