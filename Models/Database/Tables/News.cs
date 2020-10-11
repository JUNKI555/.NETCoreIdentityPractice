using System;
using System.ComponentModel.DataAnnotations;

namespace DotNETCoreIdentityPractice.Models.Database.Tables
{
    [Serializable]
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime UpdTime { get; set; }
    }
}
