using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rachna.Teracotta.Project.Source.Models
{
    public class EmailTracker
    {
        [Key]
        [Column("email_tracker_id")]
        public int EmailTrackerId { get; set; }
        [Column("to_email")]
        public string ToEmailId { get; set; }
        [Column("mail_subject")]
        public string MailSubject { get; set; }
        [Column("mail_body")]
        public string MailBody { get; set; }
        [Column("mail_from")]
        public string MailFrom { get; set; }
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("result")]
        [MaxLength(500)]
        public string Result { get; set; }
    }
}