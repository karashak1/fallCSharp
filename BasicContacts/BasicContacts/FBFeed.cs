using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContacts {
    public class FacebookFeed {
        public Datum[] data { get; set; }
        public Paging paging { get; set; }
    }

    public class Paging {
        public string previous { get; set; }
        public string next { get; set; }
    }

    public class Datum {
        public string id { get; set; }
        public From from { get; set; }
        public string message { get; set; }
        public string picture { get; set; }
        public string link { get; set; }
        public string icon { get; set; }
        public FBAction[] actions { get; set; }
        public Privacy privacy { get; set; }
        public string type { get; set; }
        public string status_type { get; set; }
        public string object_id { get; set; }
        public DateTime created_time { get; set; }
        public DateTime updated_time { get; set; }
        public Shares shares { get; set; }
        public Likes likes { get; set; }
        public Comments comments { get; set; }
        public string name { get; set; }
        public string caption { get; set; }
        public FBApplication application { get; set; }
        public To to { get; set; }
        public Message_Tags1 message_tags { get; set; }
        public string story { get; set; }
    }

    public class From {
        public string category { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Privacy {
        public string value { get; set; }
    }

    public class Shares {
        public int count { get; set; }
    }

    public class Likes {
        public Datum1[] data { get; set; }
        public Paging1 paging { get; set; }
    }

    public class Paging1 {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }

    public class Cursors {
        public string after { get; set; }
        public string before { get; set; }
    }

    public class Datum1 {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Comments {
        public Comment[] data { get; set; }
        public Paging2 paging { get; set; }
    }

    public class Paging2 {
        public Cursors1 cursors { get; set; }
        public string next { get; set; }
    }

    public class Cursors1 {
        public string after { get; set; }
        public string before { get; set; }
    }

    public class Comment {
        public string id { get; set; }
        public From1 from { get; set; }
        public string message { get; set; }
        public bool can_remove { get; set; }
        public DateTime created_time { get; set; }
        public int like_count { get; set; }
        public bool user_likes { get; set; }
        public Message_Tags[] message_tags { get; set; }
    }

    public class From1 {
        public string name { get; set; }
        public string id { get; set; }
        public string category { get; set; }
    }

    public class Message_Tags {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class FBApplication {
        public string name { get; set; }
        public string _namespace { get; set; }
        public string id { get; set; }
    }

    public class To {
        public Datum3[] data { get; set; }
    }

    public class Datum3 {
        public string category { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public Category_List[] category_list { get; set; }
    }

    public class Category_List {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Message_Tags1 {
        public _25[] _25 { get; set; }
        public _57[] _57 { get; set; }
        public _42[] _42 { get; set; }
        public _22[] _22 { get; set; }
    }

    public class _25 {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class _57 {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class _42 {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class _22 {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class FBAction {
        public string name { get; set; }
        public string link { get; set; }
    }

}
