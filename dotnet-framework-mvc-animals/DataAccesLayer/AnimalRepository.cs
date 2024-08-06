using dotnet_framework_mvc_animals.DataAccesLayer.Connection;
using dotnet_framework_mvc_animals.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace dotnet_framework_mvc_animals.DataAccesLayer
{
    public class AnimalRepository
    {
        private SqlConnection _connection;

        public AnimalRepository()
        {
            DatabaseConnection cd = new DatabaseConnection();
            _connection = cd.SqlConnection;
        }

        public List<Animal> GetAnimalListFromDB()
        {
            List<Animal> animals = new List<Animal>();

            _connection.Open();
            try
            {

                string query = "SELECT * FROM Animal;";
                SqlCommand cmd = new SqlCommand(query, this._connection);

                // Recuperamos un lector...
                SqlDataReader records = cmd.ExecuteReader();

                while (records.Read())
                {
                    Animal animal = new Animal();
                    animal.IdAnimal = records.GetInt32(records.GetOrdinal("IdAnimal"));
                    animal.NombreAnimal = records.GetString(records.GetOrdinal("NombreAnimal"));
                    animal.Raza = records.GetString(records.GetOrdinal("Raza"));
                    animal.RIdTipoAnimal = records.GetInt32(records.GetOrdinal("RIdTipoAnimal"));
                    animal.FechaNacimiento = records.GetDateTime(records.GetOrdinal("FechaNacimiento"));

                    // Agrega más campos según la estructura de tu tabla y tu clase Job
                    animals.Add(animal);
                }
                _connection.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return animals;
        }

        public void InsertAnimalToDB(Animal newAnimal)
        {
            try
            {
                this._connection.Open();
                string sql = @"INSERT INTO Animal( 
                                             NombreAnimal, 
                                             Raza,
                                             RIdTipoAnimal,
                                             FechaNacimiento) 

                                VALUES (@NombreAnimal, 
                                        @Raza,
                                        @RIdTipoAnimal,
                                        @FechaNacimiento)";


                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@NombreAnimal", newAnimal.NombreAnimal);
                    cmd.Parameters.AddWithValue("@Raza", newAnimal.Raza);
                    cmd.Parameters.AddWithValue("@RIdTipoAnimal", newAnimal.RIdTipoAnimal);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", newAnimal.FechaNacimiento);

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateAnimalInDB(Animal updatedAnimal)
        {
            try
            {
                this._connection.Open();
                string sql = @"UPDATE Animal
                       SET NombreAnimal = @NombreAnimal, 
                           Raza = @Raza,
                           RIdTipoAnimal = @RIdTipoAnimal,
                           FechaNacimiento = @FechaNacimiento
                       WHERE IdAnimal = @IdAnimal";

                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@NombreAnimal", updatedAnimal.NombreAnimal);
                    cmd.Parameters.AddWithValue("@Raza", updatedAnimal.Raza);
                    cmd.Parameters.AddWithValue("@RIdTipoAnimal", updatedAnimal.RIdTipoAnimal);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", updatedAnimal.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@IdAnimal", updatedAnimal.IdAnimal); // Asegúrate de que IdAnimal esté presente en el objeto updatedAnimal

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteAnimalFromDB(int idAnimal)
        {
            try
            {
                this._connection.Open();
                string sql = @"DELETE FROM Animal
                       WHERE IdAnimal = @IdAnimal";

                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}