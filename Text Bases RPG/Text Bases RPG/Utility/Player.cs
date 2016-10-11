using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Text_Bases_RPG.Utility;

namespace ConsoleApplication1
{
    class Player
    {
        public SqlDataReader User;
        private readonly string[] _userData = new string[8];

        public Player(string username, bool create = false)
        {
            if (username.Length < 1)
            {
                Text.Error("You did not enter a valid username");
                Thread.CurrentThread.Abort();

            }
            else
            {
                if (create != true)
                {
                    Database.Connect();
                    User =
                        Database.Query("SELECT * FROM Players WHERE name = '" +
                                       Database.RemoveSpecialCharacters(username) + "'");

                    if (User.HasRows)
                    {

                        while (User.Read())
                        {
                            _userData[0] = User["name"].ToString();
                            _userData[1] = User["hp"].ToString();
                            _userData[2] = User["xp"].ToString();
                            _userData[3] = User["current_xp"].ToString();
                            _userData[4] = User["current_hp"].ToString();
                            _userData[5] = User["stamina"].ToString();
                            _userData[6] = User["created"].ToString();
                            _userData[7] = User["id"].ToString();
                        }

                        User.Close();
                    }
                    else
                    {
                        Text.Error("Gebruiker niet gevonden, probeer het opnieuw.");
                        User = null;
                    }
                }
                else
                {
                    Database.Connect();
                    SqlDataReader newUser = Database.Query("INSERT INTO Players (hp, xp, current_xp, current_hp, stamina, name, created) VALUES(100, 1000, 550, 20, 100, '"+ Database.RemoveSpecialCharacters(username) +"', '"+ DateTime.Now +"')");
                    if (newUser.RecordsAffected < 1)
                    {
                        Text.Error("Er ging iets fout tijdens het invoeren van je gegevens.");
                        Thread.CurrentThread.Abort();
                        newUser.Close();
                        User = null;
                    }
                    else
                    {
                        Text.Success("Gebruiker aangemaakt, je kunt nu inloggen met " + username);
                    }
                }
            }
        }

        public string Username()
        {
            return _userData[0];
        }

        public string Hp()
        {
            return _userData[1];
        }

        public string Xp()
        {
            return _userData[2];
        }

        public string currenthp()
        {
            return _userData[4];
        }

        public string currentxp()
        {
            return _userData[3];
        }

        public string stamina()
        {
            return _userData[5];
        }

        public string Created()
        {
            return _userData[6];
        }

        public bool Update(string what, int amount)
        {
            SqlDataReader updateUser = Database.Query("UPDATE Players SET "+ what +" = "+ amount +" WHERE id = " + _userData[7]);

            if (updateUser.RecordsAffected < 1)
            {
                updateUser.Close();
                return false;
            }
            else
            {
                switch (what)
                {
                    case "current_hp":
                        _userData[4] = amount.ToString();
                        break;
                    case "current_xp":
                        _userData[3] = amount.ToString();
                        break;
                    case "stamina":
                        _userData[5] = amount.ToString();
                        break;
                }
                updateUser.Close();
                return true;
            }
        }

    }
}
