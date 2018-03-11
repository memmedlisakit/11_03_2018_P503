using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Programin teyinati veya tesviri
            List<string> db = new List<string>();
            List<string> user_password = new List<string>();

            // Istifadeci ekrani
            void Instructions()
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1.Melumat elave et");
                Console.WriteLine("2.Melumatlari goster");
                Console.WriteLine("3.Melumatlari yenile");
                Console.WriteLine("4.Melumati sil");
                Console.WriteLine("5.Login");
                Console.WriteLine("-----------------------------------");
                Console.Write("Icra etmek istediyiniz emrin nomresini daxil edin:");
                var emrNomresi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------------");
                

                switch (emrNomresi)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        LoginAdmin();
                        break;
                    default:
                        Console.WriteLine("Daxil etdiyiniz emr movcud deyil, sizi ana ekrana yonlendirirem");
                        Instructions();
                        break;

                }

            }

            // Admin panel login
            void LoginAdmin()
            {
                Console.Write("Username : ");
                var username = Console.ReadLine();
                Console.Write("Password : ");
                var password = Console.ReadLine();
                if (username == "admin" && password == "admin")
                {
                    Instructions();
                }
                else
                { 
                    for (int i = 0; i < db.Count; i++)
                    {
                        if (db[i] == username && user_password[i] == password)
                        {
                            Console.WriteLine("Xosh gelmisiniz sizi yonlendiririk userlerin sehifesine");
                            Read();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Username or Password incorrect");
                            LoginAdmin();
                        }
                    }
                    LoginAdmin();
                }
            }

            
            // Melumat elave etme prosesi

            void Create()
            {
                Console.Write("Elave etmek istediyiniz melumati daxil edin: ");
                var createdData = Console.ReadLine();
                db.Add(createdData);
                Console.Write("Istifadechi kodunu daxil edin: ");
                string password = Console.ReadLine();
                user_password.Add(password);
                Instructions();
            }

            // Melumat oxuma prosesi

            void Read()
            {
                var count = 0;
                var index = 0;
                foreach (var element in db)
                {
                    count++;
                    Console.WriteLine(count + "-" + element + "- passowrd -" + user_password[index]);
                    index++;
                }
                Instructions();
            }

            // Melumat yenileme prosesi

            void Update()
            { 
                Console.Write("Yenilemek istediyiniz melumatin sira nomresini daxil edin: ");
                var selectedDataRow = Convert.ToInt32(Console.ReadLine()); 
                void check_command()
                {
                    Console.Write("Username deyishmek uchun \"u\", passwordu deyishmek uchun \"p\": ");
                    var command = Console.ReadLine();
                    if (command == "u")
                    {
                        Console.Write("Userin yeni username daxil edin: ");
                        var updatedData = Console.ReadLine();
                        db[selectedDataRow - 1] = updatedData;
                    }
                    else if (command == "p")
                    {
                        Console.Write("Userin yeni passwordunu daxil edin: ");
                        var new_password = Console.ReadLine();
                        user_password[selectedDataRow - 1] = new_password;
                    }
                    else
                    {
                        Console.WriteLine("Duzgun command deyil !!!");
                        check_command();
                    }
                }
                check_command();
                Instructions();
            }

            // Melumat silme prosesi

            void Delete()
            {
                Console.Write("Silmek istediyiniz melumatin sira nomresini daxil edin: ");
                var selectedDataRow = Convert.ToInt32(Console.ReadLine());
                db.Remove(db[selectedDataRow - 1]);
                user_password.Remove(user_password[selectedDataRow - 1]);
                Instructions();
            }

            LoginAdmin();
        }
    }
}
