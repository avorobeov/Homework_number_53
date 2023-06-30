using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_number_53
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSortPatientsByFullName = "1";
            const string CommandSortPatientsByAge = "2";
            const string CommandFindPatientsWithDisease = "3";
            const string CommandExit = "4";

            Hospital hospital = new Hospital();

            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine($"Для того что бы отсортировать пациентов по Ф.И.О: {CommandSortPatientsByFullName}\n" +
                                  $"Для того что бы отсортировать пациентов по возрасту: {CommandSortPatientsByAge}\n" +
                                  $"Для того что бы найти пациента по заболеванию: {CommandFindPatientsWithDisease}\n" +
                                  $"Для того что бы закрыть приложение нажмите {CommandExit}\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSortPatientsByFullName:
                        hospital.ShowSortedPatientsByFullName();
                        break;

                    case CommandSortPatientsByAge:
                        hospital.ShowSortedPatientsByAge();
                        break;

                    case CommandFindPatientsWithDisease:
                        hospital.FindPatientsWithDisease();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет в наличии!");
                        break;
                }

                Console.WriteLine("\n\nДля продолжения ведите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Patient
    {
        public Patient(string surname, string name, string patronymic, string disease, int age)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Disease = disease;
            Age = age;
        }

        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            Fill();
        }

        public void FindPatientsWithDisease()
        {
            Console.WriteLine("Укажите заболевание по которому хотите увидеть больных:");
            string disease = Console.ReadLine();

            List<Patient> sortedPatients = GetPatientsWithDisease(disease);

            ShowPatients(sortedPatients);
        }

        public void ShowSortedPatientsByFullName()
        {
            List<Patient> sortedPatients = GetSortedPatientsByFullName();

            ShowPatients(sortedPatients);
        }

        public void ShowSortedPatientsByAge()
        {
            List<Patient> sortedPatients = GetSortedSortPatientsByAge();

            ShowPatients(sortedPatients);
        }

        public List<Patient> GetPatientsWithDisease(string disease)
        {
            return _patients.Where(patient => patient.Disease == disease).ToList();
        }

        private List<Patient> GetSortedPatientsByFullName()
        {
            return _patients.OrderBy(patient => patient.Surname).ThenBy(patient => patient.Name).ThenBy(patient => patient.Patronymic).ToList();
        }

        private List<Patient> GetSortedSortPatientsByAge()
        {
            return _patients.OrderBy(patient => patient.Age).ToList();
        }

        private void ShowPatients(List<Patient> sortedPatients)
        {
            foreach (Patient patient in sortedPatients)
            {
                Console.WriteLine("Пациент:");
                Console.WriteLine($"ФИО: {patient.Surname + " " + patient.Name + " " + patient.Patronymic}");
                Console.WriteLine($"Заболевание: {patient.Disease}");
                Console.WriteLine($"Возраст: {patient.Age}");
                Console.WriteLine();
            }
        }

        private void Fill()
        {
            Random random = new Random();

            List<string> surnames = new List<string>
           {
            "Иванов",
            "Петров",
            "Сидоров",
            "Смирнов",
            "Козлов",
            "Макаров",
            "Павлов",
            "Соколов",
            "Петрова",
            "Иванова"
           };
            List<string> names = new List<string>
           {
            "Иван",
            "Петр",
            "Алексей",
            "Ольга",
            "Андрей",
            "Максим",
            "Екатерина",
            "Игорь",
            "Анна",
            "Мария"
           };
            List<string> patronymics = new List<string>
            {
            "Иванович",
            "Петрович",
            "Васильевич",
            "Петровна",
            "Сергеевич",
            "Игоревич",
            "Александровна",
            "Сергеевич",
            "Владимировна",
            "Ивановна"
            };
            List<string> diseases = new List<string>()
            {
            "Грипп",
            "Простуда",
            "Ангина",
            "Бронхит",
            "Пневмония",
            "Туберкулез",
            "Гастрит",
            "Язва желудка",
            "Колит"
            };

            int quantityPatients = 10;
            int maxAge = 100;

            for (int i = 0; i < quantityPatients; i++)
            {
                _patients.Add(new Patient(surnames[random.Next(surnames.Count)],
                                          names[random.Next(names.Count)],
                                          patronymics[random.Next(patronymics.Count)],
                                          diseases[random.Next(diseases.Count)],
                                          random.Next(maxAge)));
            }
        }
    }
}
