using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DogService
{

    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class DogService : IDogService
    {
        private readonly string connstr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        /// <summary>
        /// Realization CheckActualDate method
        /// </summary>
        /// <param name="ActualDate"></param>
        public void CheckActualDate(DateTime ActualDate)
        {

            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlCommand sqlex = new SqlCommand(
                string.Format(@"UPDATE d 
                                    SET d.ACTUAL=CASE WHEN ABS(DATEDIFF(DAY,LAST_UPDATE,'{0}'))>60 THEN 0 else 1 END 
                                    from dogovor d", ActualDate), con);
            sqlex.ExecuteNonQuery();
            con.Close();
        }
        /// <summary>
        /// Convertation DataTable to List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        private static List<T> DataTableToList<T>(DataTable table) where T : new()
        {
            List<T> list = new List<T>();
            var typeProperties = typeof(T).GetProperties().Select(propertyInfo => new
            {
                PropertyInfo = propertyInfo,
                Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
            }).ToList();

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                T obj = new T();
                foreach (var typeProperty in typeProperties)
                {
                    object value = row[typeProperty.PropertyInfo.Name];
                    object safeValue = value == null || DBNull.Value.Equals(value)
                        ? null
                        : Convert.ChangeType(value, typeProperty.Type);

                    typeProperty.PropertyInfo.SetValue(obj, safeValue, null);
                }
                list.Add(obj);
            }
            return list;
        }
        /// <summary>
        /// Realization FillDataTable method
        /// </summary>
        /// <returns></returns>
        public List<Dogovor> FillDataTable()
        {
            string sql = "SELECT * FROM DOGOVOR";
            DataTable dt = new DataTable("Dog");
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();
                using (SqlCommand cmdSel = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter sqlad = new SqlDataAdapter(cmdSel);
                    sqlad.Fill(dt);
                }
                connection.Close();
            }
            List<Dogovor> dogs = DataTableToList<Dogovor>(dt);
            return dogs;
        }
        /// <summary>
        /// Realization UpdateDog method
        /// </summary>
        /// <param name="dog"></param>
        public void UpdateDog(Dogovor dog)
        {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            SqlCommand sqlex = new SqlCommand(string.Format("update dogovor set ACTUAL={0},DOG_NO='{1}',DOG_DATE='{2}',LAST_UPDATE=getdate() where ID={3}",
                1,
                dog.DOG_NO,
                dog.DOG_DATE,
                dog.ID),
                con);
            sqlex.ExecuteNonQuery();
            con.Close();
        }
    }
}
