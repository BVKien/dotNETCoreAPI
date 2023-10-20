using DemoWebAPI_03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DemoWebAPI_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly f8dbContext db;
        public TestApiController(f8dbContext db)
        {
            this.db = db;
        }
        // user
        [HttpGet("/Users")]
        public ActionResult<IEnumerable<User>> Get_Users()
        {
            var users = db.Users.ToList();
            return Ok(users);
        }

        // user roles
        [HttpGet("/UserRoles")]
        public ActionResult<IEnumerable<User>> Get_UserRoles()
        {
            var userroles = db.Userroles.ToList();
            return Ok(userroles);
        }

        // course
        [HttpGet("/Courses")]
        public ActionResult<IEnumerable<Course>> Get_Courses()
        {
            var courses = db.Courses.ToList();
            return Ok(courses);
        }

        // course enroll
        [HttpGet("/CoursesEnrolled")]
        public ActionResult<IEnumerable<Courseenroll>> Get_CoursesEnrolled()
        {
            var courses = db.Courses.ToList();
            return Ok(courses);
        }

        // lesson
        [HttpGet("/Lessons")]
        public ActionResult<IEnumerable<Course>> Get_Lessons()
        {
            var lessons = db.Lessons.ToList();
            return Ok(lessons);
        }

        // blog
        [HttpGet("/Blogs")]
        public ActionResult<IEnumerable<Blog>> Get_Blogs()
        {
            var blogs = db.Blogs.ToList();
            return Ok(blogs);
        }

        // save blog
        [HttpGet("/BlogSaves")]
        public ActionResult<IEnumerable<Saveblog>> Get_BlogSaves()
        {
            var blogs = db.Saveblogs.ToList();
            return Ok(blogs);
        }

        // blog comment
        [HttpGet("/BlogComments")]
        public ActionResult<IEnumerable<Blogcomment>> Get_BlogComments()
        {
            var blogs = db.Blogcomments.ToList();
            return Ok(blogs);
        }

        // ask 
        [HttpGet("/Asks")]
        public ActionResult<IEnumerable<Ask>> Get_Asks()
        {
            var asks = db.Asks.ToList();
            return Ok(asks);
        }

        // answer 
        [HttpGet("/Answers")]
        public ActionResult<IEnumerable<Answer>> Get_Answers()
        {
            var asnwers = db.Answers.ToList();
            return Ok(asnwers);
        }

        // blog tag 
        [HttpGet("/BlogTags")]
        public ActionResult<IEnumerable<Blogtag>> Get_BlogTags()
        {
            var blogtags = db.Blogtags.ToList();
            return Ok(blogtags);
        }

        // blog topic 
        [HttpGet("/BlogTopics")]
        public ActionResult<IEnumerable<Blogtopic>> Get_BlogTopics()
        {
            var blogtopics = db.Blogtopics.ToList();
            return Ok(blogtopics);
        }

        // category
        [HttpGet("/Categories")]
        public ActionResult<IEnumerable<Category>> Get_Categories()
        {
            var categories = db.Categories.ToList();
            return Ok(categories);
        }

        // chpater
        [HttpGet("/Chpaters")]
        public ActionResult<IEnumerable<Chapter>> Get_Chpaters()
        {
            var chapters = db.Chapters.ToList();
            return Ok(chapters);
        }

        // discuss
        [HttpGet("/Discusses")]
        public ActionResult<IEnumerable<Dicuss>> Get_Discusses()
        {
            var discusses = db.Dicusses.ToList();
            return Ok(discusses);
        }

        // feedback
        [HttpGet("/Feedbacks")]
        public ActionResult<IEnumerable<Feedback>> Get_Feedbacks()
        {
            var feedbacks = db.Feedbacks.ToList();
            return Ok(feedbacks);
        }

        // like comments
        [HttpGet("/likeComments")]
        public ActionResult<IEnumerable<Likecomment>> Get_likeComments()
        {
            var likecomments = db.Likecomments.ToList();
            return Ok(likecomments);
        }

        // notes
        [HttpGet("/Notes")]
        public ActionResult<IEnumerable<Likecomment>> Get_Notes()
        {
            var notes = db.Notes.ToList();
            return Ok(notes);
        }

        // questions
        [HttpGet("/Questions")]
        public ActionResult<IEnumerable<Question>> Get_Questions()
        {
            var questions = db.Questions.ToList();
            return Ok(questions);
        }

        // quizes
        [HttpGet("/Quizzes")]
        public ActionResult<IEnumerable<Quiz>> Get_Quizzes()
        {
            var quizzes = db.Quizzes.ToList();
            return Ok(quizzes);
        }

        // replies
        [HttpGet("/Replies")]
        public ActionResult<IEnumerable<Reply>> Get_Replies()
        {
            var replies = db.Replies.ToList();
            return Ok(replies);
        }

        // savelikes
        [HttpGet("/Savelikes")]
        public ActionResult<IEnumerable<Savelike>> Get_Savelikes()
        {
            var savelikes = db.Savelikes.ToList();
            return Ok(savelikes);
        }

    }
}
