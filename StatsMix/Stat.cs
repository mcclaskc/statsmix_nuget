using System;

namespace StatsMix
{
    class Stat
    {
        public Stat() { }
        public int Id { get; set; }
        public int Value { get; set; }
        public string Meta { get; set; }
        public string RefId { get; set; }
        public int ProfileId { get; set; }
        public int MetricId { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}