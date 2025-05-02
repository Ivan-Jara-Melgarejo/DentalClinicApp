using System.Collections.ObjectModel;
using System.ComponentModel;
using DentalClinicApp.Models;
using DentalClinicApp.Services;

namespace DentalClinicApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private ObservableCollection<Doctor> _doctors = new ObservableCollection<Doctor>();

        public ObservableCollection<Doctor> Doctors
        {
            get => _doctors;
            set
            {
                _doctors = value;
                OnPropertyChanged(nameof(Doctors));
            }
        }

        public MainViewModel()
        {
            _databaseService = new DatabaseService();
            LoadDoctors(); // Usa un método separado para cargar los datos
        }

        private void LoadDoctors()
        {
            var doctorsList = _databaseService.GetDoctors();
            if (doctorsList.Count > 0)
            {
                Doctors = new ObservableCollection<Doctor>(doctorsList);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}