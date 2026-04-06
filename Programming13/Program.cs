using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Programming13
{
    internal class Program
    {

        //https://github.com/BG-IT-Edu/School-Programming/blob/main/Courses/Applied-Programmer/OOP-Basics/03-%D0%95%D0%BD%D0%BA%D0%B0%D0%BF%D1%81%D1%83%D0%BB%D0%B0%D1%86%D0%B8%D1%8F-%D0%BD%D0%B0-%D0%B4%D0%B0%D0%BD%D0%BD%D0%B8/10.%D0%94%D0%BE%D0%BF%D1%8A%D0%BB%D0%BD%D0%B8%D1%82%D0%B5%D0%BB%D0%BD%D0%B8-%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B8-1.pdf
        class Team
        {
            private List<Player> players = new List<Player>();
            private string teamName="";
            private int rating = 0;

            public Team(string inputName) { setName(inputName); }
            public Team() { }

            private void setName(string name)
            {
                if (name.Length != 0 && checkName(name))
                {
                    this.teamName = name;
                }

                else
                {
                    Console.WriteLine("A name should not be empty.");
                    teamName = "Incorrect team name";
                }
            }
            public void addPlayer(string playerName, int r, int sp, int d, int p, int sh)
            {
                Statistics statistic = new Statistics(r, sp, d, p, sh);
                Player player = new Player(playerName, statistic);
                players.Add(player);
                updateStatistics();
            }
            public void removePlayer(string playerName)
            {
                bool foundPlayer = false;
                for (int i = 0; i < players.Count(); i++)
                {
                    if (players[i].name == playerName)
                    {
                        players.RemoveAt(i);
                        foundPlayer = true;
                        updateStatistics();
                    }
                }
                if (!foundPlayer)
                {
                    Console.WriteLine("Player " + playerName + " is not in " + teamName + " team.");
                }
            }

            private void updateStatistics()
            {
                double sum = 0;
                for (int i = 0; i < players.Count(); i++)
                {
                    sum += players.ElementAt(i).avgStatistics;
                }
                double result = Math.Ceiling(sum / players.Count());
                rating = System.Convert.ToInt16(result);
            }

            public void getRating()
            {
                Console.WriteLine(teamName + " - " + rating);
            }
        }

        class Player
        {
            public string name;
            private Statistics statistics;
            public double avgStatistics;

            public Player(string name, Statistics statistics)
            {
                this.name = name;
                this.statistics = statistics;
                setStatistics();
            }
            private void setStatistics()
            {
                avgStatistics = (statistics.getResilience() + statistics.getSprint() + statistics.getDribble() + statistics.getPasses() + statistics.getShots()) / 5.0;
            }

            private void setName(string name)
            {
                if (name.Length == 0 && checkName(name))
                {
                    this.name = name;
                }

                else
                {
                    Console.WriteLine("A name should not be empty.");
                    this.name = "Incorrect player name";
                }
            }
        }


        class Statistics
        {
            private int resilience = 0;
            private int sprint = 0;
            private int dribble = 0;
            private int passes = 0;
            private int shots = 0;

            public Statistics(int resilience, int sprint, int dribble, int passes, int shots)
            {
                setResilience(resilience);
                setDribble(dribble);
                setSprint(sprint);
                setPasses(passes);
                setShots(shots);
            }

            public int getResilience() { return resilience; }
            public int getSprint() { return sprint; }
            public int getDribble() { return dribble; }
            public int getPasses() { return passes; }
            public int getShots() { return shots; }



            private void setResilience(int inputResilience)
            {
                if (0 <= inputResilience && inputResilience <= 100)
                {
                    this.resilience = inputResilience;
                }
                else
                {
                    Console.WriteLine("Resilience should be between 0 and 100");
                }
            }
            private void setSprint(int inputSprint)
            {
                if (0 <= inputSprint && inputSprint <= 100)
                {
                    this.sprint = inputSprint;
                }
                else
                {
                    Console.WriteLine("Sprint should be between 0 and 100");
                }
            }
            private void setDribble(int inputDribble)
            {
                if (0 <= inputDribble && inputDribble <= 100)
                {
                    this.dribble = inputDribble;
                }
                else
                {
                    Console.WriteLine("Dribble should be between 0 and 100");
                }
            }
            private void setPasses(int inputPasses)
            {
                if (0 <= inputPasses && inputPasses <= 100)
                {
                    this.passes = inputPasses;
                }
                else
                {
                    Console.WriteLine("Passes should be between 0 and 100");
                }
            }
            private void setShots(int inputShots)
            {
                if (0 <= inputShots && inputShots <= 100)
                {
                    this.shots = inputShots;
                }
                else
                {
                    Console.WriteLine("Shots should be between 0 and 100");
                }
            }

        }


        static bool checkName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name.ElementAt(i) != ' ')
                {
                    return true;
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Team team = new Team();
            while (input != "END")
            {
                List<string> list = input.Split(';').ToList();
                string firstWord = list[0];
                switch (firstWord)
                {
                    case "Team":
                        string secondWord = list[1];
                        Team team2 = new Team(secondWord);
                        team = team2;
                        break;
                    case "Add":
                        string thirdWord = list[2];
                        int firstStatistics = int.Parse(list[3]);
                        int secondStatistics = int.Parse(list[4]);
                        int thirdStatistics = int.Parse(list[5]);
                        int fourthStatistics = int.Parse(list[6]);
                        int fifthStatistics = int.Parse(list[7]);
                        team.addPlayer(thirdWord, firstStatistics, secondStatistics, thirdStatistics, fourthStatistics, fifthStatistics);
                        break;
                    case "Rating":
                        team.getRating();
                        break;
                    case "Remove":
                        string thirdWord2 = list[2];
                        team.removePlayer(thirdWord2);
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}