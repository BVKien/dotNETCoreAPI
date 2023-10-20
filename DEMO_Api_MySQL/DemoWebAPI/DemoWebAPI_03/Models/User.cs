using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class User
    {
        public User()
        {
            BlogcommentReplyToUserNavigations = new HashSet<Blogcomment>();
            BlogcommentUsers = new HashSet<Blogcomment>();
            Blogs = new HashSet<Blog>();
            Courseenrolls = new HashSet<Courseenroll>();
            Courses = new HashSet<Course>();
            Feedbacks = new HashSet<Feedback>();
            Notes = new HashSet<Note>();
        }

        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Facebook { get; set; }
        public string? Github { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? BackgroundImage { get; set; }
        public string? GmailId { get; set; }
        public string? FacebookId { get; set; }
        public string? GithubId { get; set; }
        public int? Status { get; set; }
        public string? CodeVerify { get; set; }
        public int UserRoleRoleId { get; set; }

        public virtual Userrole UserRoleRole { get; set; } = null!;
        public virtual ICollection<Blogcomment> BlogcommentReplyToUserNavigations { get; set; }
        public virtual ICollection<Blogcomment> BlogcommentUsers { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Courseenroll> Courseenrolls { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
