using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Interop;

//models the data tables
namespace ChordView.DataModels
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string TagWords { get; set; }
        public int TeaserLength { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsPublished { get; set; }
        public string Metacode { get; set; }
        public string PostText { get; set; }
        public string CommentLink { get; set; }
    }


    public class Songs
    {
        public int SongId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string TuneBy { get; set; }
        public string LyricBy { get; set; }
        public string Album { get; set; }
        public string Keywords { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsPublished { get; set; }
        public string Metacode { get; set; }
        public string SongText { get; set; }
        public string CommentLink { get; set; }
    }

    public class SongMeta
    {
        public int SongId { get; set; }
        public string Title { get; set; }
		public string Artist { get; set; }
		public string Album { set; get;}
    }

	public class GroupedSongMeta : ObservableCollection<SongMeta>
	{
		public string GroupHeader { get; set; } // artist name or album name
	}

    //a filter class
    public class SongFilter
    {
        public string Keyword { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public SongFilter()
        {
            Keyword = "";
            Artist = "";
            Album = "";
        }
    }

    public enum RoleType
    {
        ADMIN, // can do anything
        MODERATOR, // can only post new news/song, or edit song
        GUEST = 100// can only view
    }

    public class User
    {
        public int UserId { get; set; }
        public string Alias { get; set; }
        public string FBlink { get; set; }
        public RoleType Role { get; set; }
    }





/*
    public class BanglaChordContext
    {
        public BanglaChordContext(string dbPath, ISQLitePlatform platform) 
            : base(new SQLiteConnection()
            {
                ConnectionString =
                    new SQLiteConnectionStringBuilder() { DataSource = fName, ForeignKeys = true }.ConnectionString
            }, true) { }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
*/

}