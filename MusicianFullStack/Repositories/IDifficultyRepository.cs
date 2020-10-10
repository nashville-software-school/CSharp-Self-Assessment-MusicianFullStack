using MusicianFullStack.Models;
using System.Collections.Generic;

namespace MusicianFullStack.Repositories
{
    public interface IDifficultyRepository
    {
        List<Difficulty> GetAll();
    }
}