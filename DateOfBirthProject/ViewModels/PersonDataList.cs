using DateOfBirthProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace DateOfBirthProject.ViewModels
{
    internal class PersonDataList
    {
        private List<Person> _people;
        public bool RemovePerson(Person person)
        {
            return _people.Remove(person);
        }
        

        internal List<Person> People
        {
            get { return _people;}
            set { _people = value;}
        }

        public PersonDataList()
        {
            if (!File.Exists("people.json"))
            {
                CreatePeopleList();
                Serialize();
            }
            else
            {
                Deserialize();
            }
        }

        private void CreatePeopleList()
        {
            People = new List<Person>();

            DateTime max = new DateTime(1944, 1, 1);
            Random random = new Random();
            int range = (DateTime.Today - max).Days;

            string[] names = { "Emily", "James", "Sophia", "Benjamin", "Olivia", "Jacob", "Ava", "Michael", "Emma", "William", "Isabella", "Alexander",
                               "Mia", "Ethan", "Charlotte", "Daniel", "Amelia", "Matthew", "Harper", "Lucas", "Nathan", "Evelyn", "Elijah",
                               "Scarlett", "Henry", "Avery", "Jackson", "Mila", "Carter", "Ella", "Sebastian", "Abigail", "Gabriel", "Sofia", "Owen"};


            string[] surnames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez",
                                  "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "White", "Lee", "Harris",
                                  "Clark", "Lewis", "Walker", "Hall", "Allen", "Young", "King", "Wright", "Scott", "Green", "Adams", "Nelson"};


            string[] emailDomains = { "gmail.com", "ukr.net", "ukma.edu.ua", "yahoo.com", "outlook.com" };

            for (int i = 0; i < 50; i++)
            {
                string name = names[random.Next(0, 35)];
                string surname = surnames[random.Next(0, 35)];
                string email = $"{surname}.{name}{i}@" + emailDomains[random.Next(0, 5)];
                DateTime date = max.AddDays(random.Next(range));
                People.Add(new Person(name, surname, email, date));
            }
        }

        private void Serialize()
        {

            File.WriteAllText("peopleList.json", (string)JsonConvert.SerializeObject(People));
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (FileStream s = new FileStream("people.xml", FileMode.Create))
            {
                serializer.Serialize(s, _people);
            }
            
        }

        private void Deserialize()
        {
            using (StreamReader reader = new StreamReader("peopleList.json"))
            {
                string json = reader.ReadToEnd();
                People = JsonConvert.DeserializeObject<List<Person>>(json);

            }          
        }
        public ObservableCollection<Person> GetBase()
        {
            return new ObservableCollection<Person>(People);
        }
        
       public void UpdateDatabase(string EmailToRemove)
                {
                    string json = File.ReadAllText("peopleList.json");
                    List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);

                    Person personToDelete = people.Find(p => p.Email == EmailToRemove);
                    if (personToDelete != null)
                    {
                        people.Remove(personToDelete);
                    }
                    else
                    {
                        return;
                    }

                    string updatedJson = JsonConvert.SerializeObject(people, Formatting.Indented);

                    File.WriteAllText("peopleList.json", updatedJson);

                
                }

        
    }
}
    

