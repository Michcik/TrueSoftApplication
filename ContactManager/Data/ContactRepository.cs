using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ContactManager.Models;

namespace ContactManager.Data
{
    public class ContactRepository
    {
        // ------------------------------------------------------------------ mapping
        private static Contact MapContact(IDataReader r) => new Contact
        {
            Id         = Convert.ToInt32(r["Id"]),
            FirstName  = r["FirstName"].ToString(),
            LastName   = r["LastName"].ToString(),
            Email      = r["Email"].ToString(),
            Phone      = r["Phone"].ToString(),
            Category   = (ContactCategory)Enum.Parse(typeof(ContactCategory), r["Category"].ToString()),
            AvatarPath = r["AvatarPath"] == DBNull.Value ? null : r["AvatarPath"].ToString()
        };

        // ------------------------------------------------------------------ read
        public List<Contact> GetAll(string nameFilter = null, string sortBy = "LastName")
        {
            var list = new List<Contact>();
            using (var conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    // SQL Server uses + for string concat (not ||)
                    var where = string.IsNullOrWhiteSpace(nameFilter)
                        ? ""
                        : "WHERE FirstName LIKE @f OR LastName LIKE @f OR (FirstName + ' ' + LastName) LIKE @f";

                    var order = sortBy == "Category" ? "Category, LastName"
                              : sortBy == "FirstName" ? "FirstName, LastName"
                              : "LastName, FirstName";

                    cmd.CommandText = $"SELECT * FROM Contacts {where} ORDER BY {order};";

                    if (!string.IsNullOrWhiteSpace(nameFilter))
                        cmd.Parameters.AddWithValue("@f", $"%{nameFilter}%");

                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            list.Add(MapContact(r));
                }
            }
            return list;
        }

        public Contact GetById(int id)
        {
            using (var conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Contacts WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var r = cmd.ExecuteReader())
                        return r.Read() ? MapContact(r) : null;
                }
            }
        }

        // ------------------------------------------------------------------ write
        public void Add(Contact c)
        {
            using (var conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Contacts (FirstName, LastName, Email, Phone, Category, AvatarPath)
                        VALUES (@fn, @ln, @em, @ph, @cat, @av);";
                    cmd.Parameters.AddWithValue("@fn",  c.FirstName);
                    cmd.Parameters.AddWithValue("@ln",  c.LastName);
                    cmd.Parameters.AddWithValue("@em",  c.Email);
                    cmd.Parameters.AddWithValue("@ph",  c.Phone);
                    cmd.Parameters.AddWithValue("@cat", c.Category.ToString());
                    cmd.Parameters.AddWithValue("@av",  (object)c.AvatarPath ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Contact c)
        {
            using (var conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Contacts
                        SET FirstName = @fn,
                            LastName  = @ln,
                            Email     = @em,
                            Phone     = @ph,
                            Category  = @cat,
                            AvatarPath= @av
                        WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@fn",  c.FirstName);
                    cmd.Parameters.AddWithValue("@ln",  c.LastName);
                    cmd.Parameters.AddWithValue("@em",  c.Email);
                    cmd.Parameters.AddWithValue("@ph",  c.Phone);
                    cmd.Parameters.AddWithValue("@cat", c.Category.ToString());
                    cmd.Parameters.AddWithValue("@av",  (object)c.AvatarPath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id",  c.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Contacts WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ------------------------------------------------------------------ export
        public void ExportToCsv(string filePath, string nameFilter = null, string sortBy = "LastName")
        {
            var contacts = GetAll(nameFilter, sortBy);
            using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("Id,FirstName,LastName,Email,Phone,Category");
                foreach (var c in contacts)
                    writer.WriteLine(
                        $"{c.Id},{Escape(c.FirstName)},{Escape(c.LastName)}," +
                        $"{Escape(c.Email)},{Escape(c.Phone)},{c.Category}");
            }
        }

        private static string Escape(string s)
        {
            if (s == null) return "";
            return s.Contains(",") || s.Contains("\"") || s.Contains("\n")
                ? $"\"{s.Replace("\"", "\"\"")}\""
                : s;
        }
    }
}
