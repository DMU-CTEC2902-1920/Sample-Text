using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmuBlogger.Models
{
    public class Genre
    {
        public List<string> GenreList
        {
            get 
            { 
                List<string> mGenreList = new List<string>();
                mGenreList.Add("Other");
                mGenreList.Add("Adventure");
                mGenreList.Add("Shooter");
                mGenreList.Add("Puzzle");
                mGenreList.Add("Platformer");
                mGenreList.Add("Sports");
                mGenreList.Add("Role playing");
                mGenreList.Add("Strategy");
                return mGenreList;
            }
        }
    }
}