using SQLite;
using scaldasS5.Models;

namespace scaldasS5.Repositories
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection _conn;
        public string Status { get; set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (_conn != null)
                return;
            _conn = new SQLiteConnection(_dbPath);
            _conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");

                Persona person = new() { Name = name };
                _conn.Insert(person);
                Status = "Dato ingresado correctamente";
            }
            catch (Exception ex)
            {
                Status = "Error al ingresar: " + ex.Message;
            }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                Status = "Error al listar: " + ex.Message;
                return new List<Persona>();
            }
        }

        
        public void DeletePerson(Persona persona)
        {
            try
            {
                Init();
                _conn.Delete(persona);
                Status = "Persona eliminada correctamente";
            }
            catch (Exception ex)
            {
                Status = "Error al eliminar: " + ex.Message;
            }
        }
    }
}