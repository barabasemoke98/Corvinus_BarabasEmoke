using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gyak7_TBCJ6C.Entities;
using System.IO;

namespace gyak7_TBCJ6C
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbability(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbability(@"C:\Temp\halál.csv");

        }

        Random rng = new Random(135);
        
        private void SimStep(int year, Person person)
        {

            for (int i = 0; i < Population.Count; i++)
            {

            

                if (!person.IsAlive) return;
                byte age = (byte)(year - person.BirthYear);

           
                double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.DeathProbabilitiess).FirstOrDefault();
            
                if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;

           
                if (person.IsAlive && person.Gender == Gender.Female)
                {
                
                    double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.BirthProbabilitiess).FirstOrDefault();
                    if (rng.NextDouble() <= pBirth)
                    {
                        Person újszülött = new Person();
                        újszülött.BirthYear = year;
                        újszülött.NbrOfChildren = 0;
                        újszülött.Gender = (Gender)(rng.Next(1, 3));
                        Population.Add(újszülött);
                    }
                }
            }

            int nbrOfMales = (from x in Population
                              where x.Gender == Gender.Male && x.IsAlive
                              select x).Count();
            int nbrOfFemales = (from x in Population
                                where x.Gender == Gender.Female && x.IsAlive
                                select x).Count();

            Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
        }


        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthProbability> GetBirthProbability(string csvpath)
        {
            List<BirthProbability> birthProb = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthProb.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChilden = int.Parse(line[1]),
                        BirthProbabilitiess = double.Parse(line[2])

                    });
                }
            }
            return birthProb;
        }

        public List<DeathProbability> GetDeathProbability(string csvpath)
        {
            List<DeathProbability> deathProb = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathProb.Add(new DeathProbability()
                    {
                        gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        DeathProbabilitiess = double.Parse(line[2])
                    });
                }

            }
            return deathProb;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName.ToString();
            }
            Population = GetPopulation(ofd.FileName);

        }
    }
    
}
