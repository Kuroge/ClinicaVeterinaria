using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model
{
    public class ClinicContext
    {
        private ICollection<Appointment> appointments;

        private ICollection<Veterinarian> veterinarians;

        private ICollection<Clinic> clinics;

        private ICollection<Animal> animals;

        private ICollection<Client> clients;

        private ICollection<Kind> kinds;

        private ICollection<Disease> diseases;

        public ClinicContext(ICollection<Appointment> appointments, ICollection<Veterinarian> veterinarians, 
                             ICollection<Clinic> clinics, ICollection<Animal> animals, ICollection<Client> clients, 
                             ICollection<Kind> kinds, ICollection<Disease> diseases)
        {
            this.appointments = appointments;
            this.veterinarians = veterinarians;
            this.clinics = clinics;
            this.animals = animals;
            this.clients = clients;
            this.kinds = kinds;
            this.diseases = diseases;
        }


        public ICollection<Appointment> Appointments { get => appointments; set => appointments = value; }
        public ICollection<Veterinarian> Veterinarians { get => veterinarians; set => veterinarians = value; }
        public ICollection<Clinic> Clinics { get => clinics; set => clinics = value; }
        public ICollection<Animal> Animals { get => animals; set => animals = value; }
        public ICollection<Client> Clients { get => clients; set => clients = value; }
        public ICollection<Kind> Kinds { get => kinds; set => kinds = value; }
        public ICollection<Disease> Diseases { get => diseases; set => diseases = value; }

        public ICollection<T> GetCollection<T>()
        {
            if (typeof(T) == typeof(Appointment))
            {
                return (ICollection<T>)appointments;
            }
            if (typeof(T) == typeof(Veterinarian))
            {
                return (ICollection<T>)veterinarians;
            }
            if (typeof(T) == typeof(Clinic))
            {
                return (ICollection<T>)clinics;
            }
            if (typeof(T) == typeof(Animal))
            {
                return (ICollection<T>)animals;
            }
            if (typeof(T) == typeof(Kind))
            {
                return (ICollection<T>)kinds;
            }
            if (typeof(T) == typeof(Disease))
            {
                return (ICollection<T>)diseases;
            }
            throw new ArgumentException("El tipo no es valido");
        }
    }
}
