﻿namespace Twitter.Stream.Demo
{
    public class Data
    {
        public DateTime created_at { get; set; }
        public Entities entities { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }

    public class Entities
    {
        public List<Hashtag> hashtags { get; set; }
        public List<Mention> mentions { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
        public string id { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }

}
