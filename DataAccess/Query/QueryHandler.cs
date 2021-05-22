using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxymeter_netcore.DataAccess.Query
{
    public class QueryHandler
    {
        public string selectedQuery;

        public QueryHandler(string operationName)
        {
            switch (operationName)
            {
                case "GetUser":
                    this.selectedQuery = "SELECT tckn,name,surname,birthdate,gender FROM users WHERE tckn=@tckn";
                    break;
                case "Register":
                    this.selectedQuery = "INSERT INTO users (tckn, password, name, surname, birthdate, gender,role) VALUES (@Tckn, @Password, @Name, @Surname, @BirthDate, @Gender, @Role)";
                    break;
                case "Login"://auk
                    this.selectedQuery = "SELECT tckn, role FROM users WHERE tckn=@tckn AND password=@password";//auk
                    break;//auk
                case "AdminLogin"://auk
                    this.selectedQuery = "SELECT tckn, role FROM users WHERE tckn=@tckn AND password=@password AND role = 'admin'";//auk
                    break;//auk
                case "GetMedicalRecord":
                    this.selectedQuery = "SELECT u.tckn as Tckn, m.measurementDate as Date, m.hr as HearthRate, m.spo2 as OxygenRate, m.hesCode as HesCode, m.patientStory as PatientStory FROM users u, medicalrecords m WHERE u.tckn = m.tckn and u.tckn = @Tckn";
                    break;
                case "AddMedicalRecord":
                    this.selectedQuery = "INSERT INTO medicalrecords (measurementDate, spo2, hr, tckn, hesCode, patientStory) VALUES (@MeasurementDate, @Spo2, @Hr, @Tckn,@HesCode,@PatientStory);";
                    break;
                default:
                    this.selectedQuery = null;
                    break;
            }
        }

    }
}
