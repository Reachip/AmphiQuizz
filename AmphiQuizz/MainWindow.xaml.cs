using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmphiQuizz
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Membres ------------------------------------------------------
        /// <summary>
        /// Liste des groupes
        /// </summary>
        public ObservableCollection<Groupe> GroupesObservableCollection { get; set; }

        /// <summary>
        /// Liste des élèves
        /// </summary>
        public ObservableCollection<Eleve> StudentsObservableCollection { get; set; }

        /// <summary>
        /// Liste des professeurs
        /// </summary>
        public ObservableCollection<Professeur> TeachersObservableCollection { get; set; }

        /// <summary>
        /// Liste des valeurs des notes
        /// </summary>
        public ObservableCollection<Note> NotesObservableCollection { get; set; }


        public ObservableCollection<Note> StudentsNotesObservableCollection { get; set; }


        /// <summary>
        /// Elève sélectionné par le professeur
        /// </summary>
        public Eleve EleveSelectionne { get; set; }
        #endregion Membres ------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            ApplicationData.LoadApplicationData();

            try
            {
                GroupesObservableCollection = new ObservableCollection<Groupe>(ApplicationData.ListeGroupes);
                StudentsObservableCollection = new ObservableCollection<Eleve>(ApplicationData.ListeEleves);
                TeachersObservableCollection = new ObservableCollection<Professeur>(ApplicationData.ListeProfesseurs);
                NotesObservableCollection = new ObservableCollection<Note>(ApplicationData.ListeNotes);
                StudentsNotesObservableCollection = new ObservableCollection<Note>(ApplicationData.ListeNotesEleves);
                
            }
            
            catch (Exception e)
            {
                MessageBox.Show("Une erreur innatendu à été détecté ! L'application va se fermer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
                MessageBox.Show(e.Message + " " + e.StackTrace);
                Close();
            }


            lvGroupe.ItemsSource = GroupesObservableCollection;
            lvEleve.ItemsSource = StudentsObservableCollection;
            lvProfesseur.ItemsSource = TeachersObservableCollection;
            lvNoteProfesseur.ItemsSource = NotesObservableCollection;
            lvNote.ItemsSource = StudentsNotesObservableCollection;

            lvGroupe.SelectedIndex = 0;

            CollectionView studentsCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(lvEleve.ItemsSource);
            studentsCollectionView.Filter = StudentFilter;

            CollectionView notesCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(lvNote.ItemsSource);
            notesCollectionView.Filter = NoteFilter;
        }

        #region Filtres des ListView ------------------------------------------------------
        /// <summary>
        /// Garde dans la ListView des notes, celles qui appertiennent
		/// à un élève séléctionné et aux professeurs cochées dans l'applicatio, associées à la note.
        /// </summary>
        private bool NoteFilter(object obj)
        {
            Note note = (Note)obj;

            if (note.Student.Equals((Eleve)lvEleve.SelectedItem))
                return true;

            return false;
        }

        /// <summary>
        /// Garde dans la ListView les étudiants appartenant aux groupes cochés dans l'application
        /// </summary>
        private bool StudentFilter(object item)
        {
            Eleve student = (Eleve)item;

            foreach (Groupe grp in lvGroupe.Items)
            {
                if (grp.IsSelected && student.Groupe.Equals(grp))
                    return true;
            }

            return false;
        }
        #endregion Filtres des ListView ------------------------------------------------------

        #region Ecouteurs d'événements ------------------------------------------------------
        /// <summary>
        /// Méthode invoqué lorsque la séléction d'un étudiant change
        /// </summary>
        private void OnStudentSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Eleve student = (Eleve)lvEleve.SelectedItem;
            
            if (student != null)
            {
                StudentNameTextBox.Text = student.Name;
                StudentSurnameTextBox.Text = student.Surname;
                StudentGroupTextBox.Text = student.Groupe.Libelle;

                try
                {
                    StudentImage.Source = BitmapFrame.Create(new Uri($"U:\\Documents\\DUT\\INFO\\INFO1\\S2\\UE21\\M2104-TROMBI\\{student.ImagePath}"));
                }

                catch(Exception _) { }
                lvNote.SelectedIndex = -1;
                lvNoteProfesseur.SelectedIndex = -1;
                lvProfesseur.SelectedIndex = -1;
            }

            else
            {
                StudentNameTextBox.Text = null;
                StudentSurnameTextBox.Text = null;
                StudentGroupTextBox.Text = null;
                StudentImage.Source = null;
            }

            CollectionViewSource.GetDefaultView(lvNote.ItemsSource).Refresh();
        }

        /// <summary>
        /// Méthode invoqué lorsque le bouton de tirage aléatoire d'un étudiant est cliqué
        /// </summary>
        private void OnTakeRandomStudentButtonClick(object sender, RoutedEventArgs e)
        {
            int studentListViewSize = lvEleve.Items.Count;

            if (studentListViewSize > 0)
            {
                Random rn = new Random();
                lvEleve.SelectedIndex = rn.Next(studentListViewSize);
            }

            else
                MessageBox.Show("Veuilez séléctionner un élève");
        }

        /// <summary>
        /// Méthode invoqué lorsque le bouton d'application d'une note à un étudiant séléctionné est cliqué.
        /// </summary>
        private void OnPutNoteButtonClick(object sender, RoutedEventArgs e)
        {
            Eleve student = (Eleve)lvEleve.SelectedItem;
            Professeur teacher = (Professeur)lvProfesseur.SelectedItem;
            Note selectedNote = (Note)lvNoteProfesseur.SelectedItem;

            if (student == null && teacher == null && selectedNote == null)
                MessageBox.Show("Veuillez sélectionner sélectionner un élève ainsi qu'une note et un professeur afin de noter");

            else if(student == null)
                MessageBox.Show("Veuillez sélectionner sélectionner un élève");

            else if (teacher == null)
                MessageBox.Show("Veuillez sélectionner sélectionner un professeur");

            else if (selectedNote == null)
                MessageBox.Show("Veuillez sélectionner sélectionner une note");

            else
            {
                Note note = new Note(DateTime.Now, selectedNote.StudentNote, teacher, student);
                note.Create();
                StudentsNotesObservableCollection.Add(note);
                MessageBox.Show("Note inserée");
            }

                        
        }

        /// <summary>
        /// Méthode invoqué lorsqu'un groupe est coché ou décoché.
        /// </summary>
        private void OnGroupeIsCheckedOrUnchecked(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvEleve.ItemsSource).Refresh();
            lvEleve.SelectedIndex = 0;
        }

        /// <summary>
        /// Méthode invoqué lorsqu'une note est sélectionné  
        /// </summary>
        private void lvNote_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Note note = (Note)lvNote.SelectedItem;

            if (note != null)
            {
                lvProfesseur.SelectedItem = note.Teacher;
                lvNoteProfesseur.SelectedItem = ApplicationData.ListeNotes.Find(note_ => note_.StudentNote == note_.StudentNote);
            }
        }
        #endregion Ecouteurs d'événements ------------------------------------------------------
    }
}

