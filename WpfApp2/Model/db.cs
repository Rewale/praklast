using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Model
{
    class db
    {
        private static autoinspecEntities1 _context;
        public static autoinspecEntities1 GetContext()
        {
            if (_context == null)
                _context = new autoinspecEntities1();

            return _context;
        }

        private static void importToBinary()
        {
            string path = @"C:\Users\usersql\Desktop\УП 01 Учебная практика\Ресурсы\Сессия 2\drivers 2\photo\";

            foreach (var item in GetContext().Drivers)
            {
                if(File.Exists(path+item.photo))
                {
                    item.photoBinary = File.ReadAllBytes(path + item.photo);
                }
                else
                {
                    MessageBox.Show(path + item.photo);
                }
            }

            GetContext().SaveChanges();
        }

        private static void importNewBase()
        {
            string path = @"C:\Users\usersql\Desktop\УП 01 Учебная практика\Ресурсы\Сессия 3\licences\drivers and licences11.csv";

            string[] lines = File.ReadAllLines(path);
            char[] separators = new char[] { ';' };
            List<Category> categoriesList = new List<Category>();
            List<EngineType> engineTypesList = new List<EngineType>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] items = lines[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(items[0]);
                DateTime licence_date = DateTime.Parse(items[1]);
                DateTime expire_date = DateTime.Parse(items[2]);
                string[] categories = items[3].Split(',');
                string series = items[4];
                int number = int.Parse(items[5]);
                string VIN = items[6];
                string manufacturer = items[7];
                string model = items[8];
                int year = int.Parse(items[9]);
                int weight = int.Parse(items[10]);
                int color = int.Parse(items[11]);
                int engineType = int.Parse(items[12]);
                string typeOfDrive = items[13];

                licence licence = new licence()
                {
                    licence_date = licence_date,
                    expire_date = expire_date,
                    licence_series = series,
                    number = number,
                    owner=id,                                    

                };

                foreach (var item in categories)
                {
                    string categoryLetter = item.Trim();
                    var categoryObject = categoriesList.FirstOrDefault(p => p.letter == categoryLetter);
                    if(categoryObject==null)
                    {
                        Category cat = new Category();
                        cat.letter = categoryLetter;
                        categoriesList.Add(cat);
                    }

                    licence.Category.Add(categoryObject);

                }
                var engineTypeObject = engineTypesList.FirstOrDefault(p =>p.id==engineType);

                if(engineTypeObject == null)
                {
                    EngineType engine = new EngineType();
                    engine.id = engineType;
                    engine.name = typeOfDrive;
                    engineTypesList.Add(engine);
                }
                Auto auto = new Auto()
                {
                    VIN = VIN,
                    color = color,
                    Model = model,
                    weight = weight,
                    year = year,
                    Manufacturer = manufacturer,
                    owner = id,
                    EngineType = engineTypeObject,                    
                };

                
                GetContext().Auto.Add(auto);
                GetContext().licence.Add(licence);



            }
            GetContext().EngineType.AddRange(engineTypesList);
            GetContext().Category.AddRange(categoriesList);
            GetContext().SaveChanges();
        }

        private static void importAuto()
        {
            string path = @"C:\Users\usersql\Desktop\УП 01 Учебная практика\Ресурсы\Сессия 3\licences\drivers and licences11.csv";

            string[] lines = File.ReadAllLines(path);
            char[] separators = new char[] { ';' };
            List<Category> categoriesList = new List<Category>();
            List<EngineType> engineTypesList = new List<EngineType>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] items = lines[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);

                
                string VIN = items[6];                
                int engineType = int.Parse(items[12]);


                GetContext().Auto.FirstOrDefault(p => p.VIN == VIN).TypeOfEngineId = engineType;




            }
            
            GetContext().SaveChanges();
        }

        private static void importOldAuto()
        {

        }
    }
}
