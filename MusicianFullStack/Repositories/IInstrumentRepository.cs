using MusicianFullStack.Models;
using System.Collections.Generic;

namespace MusicianFullStack.Repositories
{
    public interface IInstrumentRepository
    {
        List<Instrument> GetAll();
        List<Instrument> Search(string criterion);
        Instrument GetById(int id);
        void Add(Instrument instrument);
        void Update(Instrument instrument);
        void Remove(int id);
        void UpdateMusicians(int instrumentId, List<int> musicianIds);
    }
}