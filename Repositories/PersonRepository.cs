using System;
using System.Collections.Generic;
using System.Text;
using ayepezS5.Models;
using SQLite;

namespace ayepezS5.Repositories
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection _conn;

        public string StatusMessage { get; set; }

        public PersonRepository(string path)
        {
            _dbPath = path;
        }

        private void Init()
        {
            if (_conn is not null)
                return;

            _conn = new(_dbPath);
            _conn.CreateTable<Persona>();
        }

        //INSERTAR
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona persona = new() { Name = name };
                result = _conn.Insert(persona);
                StatusMessage = string.Format("Dato Ingresado");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error: {0}", ex.Message);
            }
        }

        //SELECT
        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error: {0}", ex.Message);
            }
            return new List<Persona>();
        }

        //DELETE (taller)
        public void DeletePerson(int id)
        {
            try
            {
                Init();
                _conn.Delete<Persona>(id);
                StatusMessage = string.Format("Dato Eliminado");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error: {0}", ex.Message);
            }
        }

        //UPDATE (tarea)
    }
}