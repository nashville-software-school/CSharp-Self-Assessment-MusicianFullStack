using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MusicianFullStack.Models;
using System.Collections.Generic;

namespace MusicianFullStack.Repositories
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly string _connectionString;
        public InstrumentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public void Add(Instrument instrument)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Instrument (Name, DifficultyId)
                                        OUTPUT INSERTED.ID 
                                        VALUES (@Name, @DifficultyId)";

                    cmd.Parameters.AddWithValue("@Name", instrument.Name);
                    cmd.Parameters.AddWithValue("@DifficultyId", instrument.DifficultyId);

                    instrument.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public List<Instrument> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT i.id, i.Name, i.DifficultyId, d.Label
                                          FROM Instrument i 
                                               LEFT JOIN Difficulty d on i.DifficultyId = d.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instrument> instruments = new List<Instrument>();

                    while (reader.Read())
                    {
                        instruments.Add(NewInstrumentFromReader(reader));
                    }

                    reader.Close();

                    return instruments;
                }
            }
        }

        public List<Instrument> Search(string criterion)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT i.id, i.Name, i.DifficultyId, d.Label
                                          FROM Instrument i 
                                               LEFT JOIN Difficulty d on i.DifficultyId = d.Id
                                         WHERE i.Name LIKE @criterion";

                    cmd.Parameters.AddWithValue("@criterion", $"%{criterion}%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instrument> instruments = new List<Instrument>();

                    while (reader.Read())
                    {
                        instruments.Add(NewInstrumentFromReader(reader));
                    }

                    reader.Close();

                    return instruments;
                }
            }
        }


        public Instrument GetById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT i.id AS InstrumentId, i.Name AS InstrumentName, i.DifficultyId, 
                               d.Label,
                               m.Id AS MusicianId, m.Name as MusicianName
                          FROM Instrument i 
                               LEFT JOIN Difficulty d ON i.DifficultyId = d.Id
                               LEFT JOIN MusicianInstrument mi ON mi.InstrumentId = i.Id
                               LEFT JOIN Musician m ON mi.MusicianId = m.Id
                         WHERE i.id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Instrument instrument = null;

                    while (reader.Read())
                    {
                        if (instrument == null)
                        {
                            instrument = new Instrument()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("InstrumentId")),
                                Name = reader.GetString(reader.GetOrdinal("InstrumentName")),
                                DifficultyId = reader.GetInt32(reader.GetOrdinal("DifficultyId")),
                                Difficulty = new Difficulty()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("DifficultyId")),
                                    Label = reader.GetString(reader.GetOrdinal("Label"))
                                },
                                Musicians = new List<Musician>()
                            };
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("MusicianId")))
                        {
                            Musician musician = new Musician()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("MusicianId")),
                                Name = reader.GetString(reader.GetOrdinal("MusicianName")),
                            };
                            instrument.Musicians.Add(musician);
                        }
                    }

                    reader.Close();

                    return instrument;
                }
            }
        }

        public void Update(Instrument instrument)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Instrument
                                           SET Name = @Name,
                                               DifficultyId = @DifficultyId
                                         WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Name", instrument.Name);
                    cmd.Parameters.AddWithValue("@DifficultyId", instrument.DifficultyId);
                    cmd.Parameters.AddWithValue("@Id", instrument.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMusicians(int instrumentId, List<int> musicianIds)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM MusicianInstrument WHERE InstrumentId = @InstrumentId";
                    cmd.Parameters.AddWithValue("@InstrumentId", instrumentId);
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = @"INSERT INTO MusicianInstrument (InstrumentId, MusicianId) 
                                        VALUES (@InstrumentId, @MusicianId)";

                    foreach (int musicianId in musicianIds)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@InstrumentId", instrumentId);
                        cmd.Parameters.AddWithValue("@MusicianId", musicianId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Remove(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Instrument WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Instrument NewInstrumentFromReader(SqlDataReader reader)
        {
            return new Instrument()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                DifficultyId = reader.GetInt32(reader.GetOrdinal("DifficultyId")),
                Difficulty = new Difficulty()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("DifficultyId")),
                    Label = reader.GetString(reader.GetOrdinal("Label"))
                }
            };
        }
    }
}
