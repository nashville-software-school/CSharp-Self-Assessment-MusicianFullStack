using MusicianFullStack.Models;
using System.Collections.Generic;

namespace MusicianFullStack.Repositories
{
    public interface IMusicianRepository
    {
        List<Musician> GetAll();
    }
}