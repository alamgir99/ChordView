using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net;

namespace ChordView.DataModels
{
    public class SongDataProvider 
    {
        //database context
        SQLiteConnection m_dBContext;
        SongFilter m_Filter;
        
        public SongDataProvider(SQLiteConnection con, SongFilter filter)
        {
            m_dBContext = con;
            m_Filter = filter;
        }
        
        //functions related to Song
        //return total count of posts
        public int TotalSongCount()
        {
            int count = 0;
			if (m_Filter != null)
			{
				if (m_Filter.Keyword != "")
				{ // apply metaphone
					var songs = m_dBContext.Table<Songs>().ToList();
					foreach (Songs s in songs)
					{
						if (s.Keywords != null)
							if (s.Keywords.Contains(m_Filter.Keyword))
								count++;
					}
				}
				else if (m_Filter.Artist != "")
				{
					var songs = m_dBContext.Table<Songs>().ToList();
					foreach (Songs s in songs)
					{
						if (s.Artist.Contains(m_Filter.Artist))
							count++;
					}
				}
				else if (m_Filter.Album != "")
				{
					var songs = m_dBContext.Table<Songs>().ToList();
					foreach (Songs s in songs)
					{
						if (s.Album != null)
							if (s.Album.Contains(m_Filter.Album))
								count++;
					}
				}
			}
			else count = m_dBContext.Table<Songs>().Count();

            return count;
        }

        //return a single song
        public Songs GetSong(int songId)
        {
			return m_dBContext.Table<Songs>().Where( s => s.SongId == songId).FirstOrDefault();
        }



		//returns a list of song meta info
		public List<SongMeta> GetSongInfoList()
		{
			if (m_dBContext == null)
				return null;

			var songs = m_dBContext.Table<Songs>();//.Where(s => s.IsPublished == true);
			var result = from ss in songs 
						 where ss.IsPublished == true 
			                     select new SongMeta { SongId = ss.SongId, Title = ss.Title, Artist = ss.Artist, Album = ss.Album};
			                                    	
			return result.ToList();
		
		}
    }
}