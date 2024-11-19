using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie_02._2025
{
    internal class DataAndFilesManagement
    {
        static string pathOfDirectory = Path.Combine("C:\\Users\\dell\\source\\repos\\Zaliczenie 02.2025\\Accounts\\usersFiles");
        static string pathOfUsers = Path.Combine();
        static int usersEqual= AccountAcces.equals;
        static int directoryEqual=Directory.GetDirectories(pathOfDirectory).Length;

//Metoda każdorazowo przy prawidłowym zalogowaniu się użytkownika sprawdza, czy w folderze userFiles znajdują się podfoldery dla wszystkich
//użytkowników z folderu userData, jeżeli jest różnica np. został wcześniej dodany nowy użytkownik, metoda utworzy jego folder
//Po prawidłowym zalogowaniu do serwisu
        static internal void DirectoriesCreator()
        {
            for(int i = 1; i <= usersEqual; i++)
            {
                var t1=AccountAcces.ReturnInfo(i);
                if (Directory.Exists($"{pathOfDirectory}\\{t1.Item1}_{t1.Item2}"))
                {
                    continue;
                }
                else
                {
                    Directory.CreateDirectory($"{pathOfDirectory}\\{t1.Item1}_{t1.Item2}");
                }
            }
        }
        //Metoda służy do pożądkowania katalogu userFiles,wysyła do metody "isPathExist" ścieżkę do zbadania, czy
        //ma ona prawo isnieć, jeśli ww metoda zwróci "false", folder o takiej ścieżce zostanie usunięty z 
        //folderu "userFiles"

        static internal void DeleteUnnecessaryDirectories()
        {
            bool exist;

            for (int i = 0; i < DirectionRefresh().Item2; i++)
            {
                 exist=IsPathExist($"{DirectionRefresh().Item1.GetValue(i)}");
                if(!exist)
                {
                    Directory.Delete($"{DirectionRefresh().Item1.GetValue(i)}");
                    i--;
                }
            }
        }
        //Metoda służy do monitorowania obecnej liczy filderów, zwracania ich ścieżek oraz ilości.
        static internal (string[], int) DirectionRefresh()
        {
            string[] directories = Directory.GetDirectories(pathOfDirectory);
            int lenght=directories.Length;
            return (directories,lenght);
        }
        //Metoda służy do sprawdzania, czy ścieżka podana jako argument istnieje już w folderze userFiles, 
        //pobiera za pomocą tetody ReturnInfo podstawowe dane istniejących użytkowników, tworzy z tych
        //danych ścieżkę do folderu użytkownika w userFiles i sprawdza, czy ścieżka podana w argumencie 
        //ma prawo bytu(czy może istnieć folder o takim oznaczeniu imie_nazwisko), jeśli nie, zwraca
        //wartość fales
        static internal bool IsPathExist(string path)
        {
            bool exist=false;
            for (int i = 1; i <= usersEqual; i++)
            {
                var t1 = AccountAcces.ReturnInfo(i);

                if (path.Equals($"{pathOfDirectory}\\{t1.Item1}_{t1.Item2}"))
                {
                    exist = true;
                    break;


                }
            }
            return exist;
        }
    }
}
