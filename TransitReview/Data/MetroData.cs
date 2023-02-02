using System.Text;
using TransitReview.Models;
namespace TransitReview.Data
{
    public class MetroData
    {
        static private Dictionary<int, Review> Reviews = new Dictionary<int, Review>();

        static private Dictionary<int, Metro> Metros = new Dictionary<int, Metro>();

        static private string DATA_FILE = "src/MetroLinkStations_REGISTERED.csv";

        static bool IsDataLoaded = false;

        static List<Metro> AllMetros;

        static private List<MetroField> AllStopName = new List<MetroField>();

        public static void Add(Review newReview)
        {
            Reviews.Add(newReview.Id, newReview);
        }
        //public static Dictionary<int,Metro> Test()
        //{
        //    List<Metro> metros;
        //    metros = MetroData.FindAll();
        //    Metros.Add(metros.Id, metros);
        //    return Metros;
        //}
        public static IEnumerable<Review> GetAll()
        {
            return Reviews.Values;
        }
        public static List<Metro> FindAll()
        {
            LoadData();
            return new List<Metro>(AllMetros);
        } //end FindAll

        static public List<Metro> FindByColumnAndValue(string column, string value)
        {
            //load data 
            LoadData();

            List<Metro> metros = new List<Metro>();

            if(value.ToLower().Equals("all"))
            {
                return FindAll();
            } 

            if (column.Equals("all"))
            {
                metros = FindByValue(value);
                return metros;
            }

            foreach (Metro metro in AllMetros)
            {
                string aValue = GetFieldValue(metro, column);
                if (aValue != null && aValue.ToLower().Contains(value.ToLower()))
                {
                    metros.Add(metro);
                }
            }
            return metros;
        } //end FindByColumnAndValue


        static public string GetFieldValue(Metro metro, string fieldName)
        {
            string theValue;
            if (fieldName.Equals("name"))
            {
                theValue = metro.Name;
            }
            else if (fieldName.Equals("city"))
            {
                theValue = metro.City.ToString();
            }
            else
            {
                theValue = "GetFieldValueError";
            }
           
            return theValue;
        } //end GetFieldValue

        static public List<Metro> FindByValue(string value)
        {

            // load data, if not already loaded
            LoadData();

            List<Metro> metros = new List<Metro>();

            foreach (Metro metro in AllMetros)
            {

                if (metro.Name.ToLower().Contains(value.ToLower()))
                {
                    metros.Add(metro);
                }
                else if (metro.City.ToString().ToLower().Contains(value.ToLower()))
                {
                    metros.Add(metro);
                }
            }

            return metros;
        } // end FindByValue


        static private void LoadData()
        {
            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();


            using (StreamReader reader = File.OpenText(DATA_FILE))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArray = CSVRowToStringArray(line);
                    if (rowArray.Length > 0)
                    {
                        rows.Add(rowArray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            AllMetros = new List<Metro>();

            // Parse each row array 
            foreach (string[] row in rows)
            {
                string aX = row[0];
                string aY = row[1];
                string aOBJECTID = row[2];
                string aStopID = row[3];
                string aStopAbbr = row[4];
                string aStopName = row[5];
                string aBusCxn = row[6];
                string aCity = row[7];
                string aLon = row[8];
                string aLat = row[9];

                /*Employer newEmployer = (Employer)FindExistingObject(AllEmployers, anEmployer);
               

                if (newEmployer == null)
                {
                    newEmployer = new Employer(anEmployer);
                    AllEmployers.Add(newEmployer);
                } */

                

                Metro newMetro = new Metro(aStopName, aBusCxn, aCity);

                AllMetros.Add(newMetro);
            }

            IsDataLoaded = true;
        } //end LoadData

        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        } //end CSVRowToStringArray
    }
}
