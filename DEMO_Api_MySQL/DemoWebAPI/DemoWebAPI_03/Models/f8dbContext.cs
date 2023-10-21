using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoWebAPI_03.Models
{
    public partial class f8dbContext : DbContext
    {
        public f8dbContext()
        {
        }

        public f8dbContext(DbContextOptions<f8dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Ask> Asks { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Blogcomment> Blogcomments { get; set; } = null!;
        public virtual DbSet<Blogtag> Blogtags { get; set; } = null!;
        public virtual DbSet<Blogtopic> Blogtopics { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Courseenroll> Courseenrolls { get; set; } = null!;
        public virtual DbSet<Dicuss> Dicusses { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Likecomment> Likecomments { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Reply> Replies { get; set; } = null!;
        public virtual DbSet<Saveblog> Saveblogs { get; set; } = null!;
        public virtual DbSet<Savelike> Savelikes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userrole> Userroles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=f8db;user=root;password=02122002", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answer");

                entity.HasIndex(e => e.QuestionQuestionId, "fk_Answer_Question1_idx");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.Answer1)
                    .HasMaxLength(200)
                    .HasColumnName("Answer")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.QuestionQuestionId).HasColumnName("Question_QuestionID");

                entity.HasOne(d => d.QuestionQuestion)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Answer_Question1");
            });

            modelBuilder.Entity<Ask>(entity =>
            {
                entity.ToTable("ask");

                entity.HasIndex(e => e.DicussDicussId, "fk_Ask_Dicuss1_idx");

                entity.Property(e => e.AskId).HasColumnName("AskID");

                entity.Property(e => e.Content)
                    .HasMaxLength(2000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.DicussDicussId).HasColumnName("Dicuss_DicussID");

                entity.HasOne(d => d.DicussDicuss)
                    .WithMany(p => p.Asks)
                    .HasForeignKey(d => d.DicussDicussId)
                    .HasConstraintName("fk_Ask_Dicuss1");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("blog");

                entity.HasIndex(e => e.BlogTagBlogTagId, "fk_Blog_BlogTag1_idx");

                entity.HasIndex(e => e.BlogTopicBlogTopicId, "fk_Blog_BlogTopic1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_Blog_User1_idx");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.BlogImage)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.BlogTagBlogTagId).HasColumnName("BlogTag_BlogTagID");

                entity.Property(e => e.BlogTitle)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.BlogTopicBlogTopicId).HasColumnName("BlogTopic_BlogTopicID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogTagBlogTag)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogTagBlogTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Blog_BlogTag1");

                entity.HasOne(d => d.BlogTopicBlogTopic)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogTopicBlogTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Blog_BlogTopic1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Blog_User1");
            });

            modelBuilder.Entity<Blogcomment>(entity =>
            {
                entity.ToTable("blogcomment");

                entity.HasIndex(e => e.BlogId, "fk_BlogComment_Blog1_idx");

                entity.HasIndex(e => e.UserId, "fk_BlogComment_User1_idx");

                entity.HasIndex(e => e.ReplyToUser, "fk_BlogComment_User2_idx");

                entity.Property(e => e.BlogCommentId).HasColumnName("BlogCommentID");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.OriginCommentId).HasColumnName("Origin_Comment_ID");

                entity.Property(e => e.Publish).HasColumnType("datetime");

                entity.Property(e => e.ReplyToUser).HasColumnName("Reply_To_User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Blogcomments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("fk_BlogComment_Blog1");

                entity.HasOne(d => d.ReplyToUserNavigation)
                    .WithMany(p => p.BlogcommentReplyToUserNavigations)
                    .HasForeignKey(d => d.ReplyToUser)
                    .HasConstraintName("fk_BlogComment_User2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BlogcommentUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_BlogComment_User1");
            });

            modelBuilder.Entity<Blogtag>(entity =>
            {
                entity.ToTable("blogtag");

                entity.Property(e => e.BlogTagId).HasColumnName("BlogTagID");

                entity.Property(e => e.BlogTagName).HasMaxLength(100);
            });

            modelBuilder.Entity<Blogtopic>(entity =>
            {
                entity.ToTable("blogtopic");

                entity.Property(e => e.BlogTopicId).HasColumnName("BlogTopicID");

                entity.Property(e => e.BlogTopicName).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("chapter");

                entity.HasIndex(e => e.CourseCourseId, "fk_Lesson_Course1_idx");

                entity.Property(e => e.ChapterId).HasColumnName("ChapterID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Lesson_Course1");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasIndex(e => e.CategoryCategoryId, "fk_Course_Category1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_Course_User1_idx");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CategoryCategoryId).HasColumnName("Category_CategoryID");

                entity.Property(e => e.CourseInfo)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.Property(e => e.VideoIntro)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.CategoryCategory)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Course_Category1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Course_User1");
            });

            modelBuilder.Entity<Courseenroll>(entity =>
            {
                entity.ToTable("courseenroll");

                entity.HasIndex(e => e.CourseCourseId, "fk_CourseEnroll_Course1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_CourseEnroll_User1_idx");

                entity.Property(e => e.CourseEnrollId).HasColumnName("CourseEnrollID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.EnrollDate).HasColumnType("datetime");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.Courseenrolls)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CourseEnroll_Course1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Courseenrolls)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CourseEnroll_User1");
            });

            modelBuilder.Entity<Dicuss>(entity =>
            {
                entity.ToTable("dicuss");

                entity.HasIndex(e => e.LessonLessonId, "fk_Dicuss_Lesson1_idx");

                entity.Property(e => e.DicussId).HasColumnName("DicussID");

                entity.Property(e => e.LessonLessonId).HasColumnName("Lesson_LessonID");

                entity.HasOne(d => d.LessonLesson)
                    .WithMany(p => p.Dicusses)
                    .HasForeignKey(d => d.LessonLessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Dicuss_Lesson1");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.HasIndex(e => e.CourseCourseId, "fk_Feedback_Course1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_Feedback_User1_idx");

                entity.Property(e => e.FeedbackId)
                    .ValueGeneratedNever()
                    .HasColumnName("FeedbackID");

                entity.Property(e => e.CourseCourseId).HasColumnName("Course_CourseID");

                entity.Property(e => e.Feedback1)
                    .HasMaxLength(300)
                    .HasColumnName("Feedback")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.CourseCourse)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CourseCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Feedback_Course1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Feedback_User1");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("lesson");

                entity.HasIndex(e => e.ChapterChapterId, "fk_Lesson_Chapter1_idx");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.ChapterChapterId).HasColumnName("Chapter_ChapterID");

                entity.Property(e => e.Time).HasColumnType("time");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Video)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.ChapterChapter)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ChapterChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Lesson_Chapter1");
            });

            modelBuilder.Entity<Likecomment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("likecomment");

                entity.HasIndex(e => e.BlogCommentBlogCommentId, "fk_LikeComment_BlogComment1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_LikeComment_User1_idx");

                entity.Property(e => e.BlogCommentBlogCommentId).HasColumnName("BlogComment_BlogCommentID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogCommentBlogComment)
                    .WithMany()
                    .HasForeignKey(d => d.BlogCommentBlogCommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LikeComment_BlogComment1");

                entity.HasOne(d => d.UserUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LikeComment_User1");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("note");

                entity.HasIndex(e => e.ChapterChapterId, "fk_Note_Chapter1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_Note_User1_idx");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.ChapterChapterId).HasColumnName("Chapter_ChapterID");

                entity.Property(e => e.Content)
                    .HasMaxLength(300)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.ChapterChapter)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ChapterChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Note_Chapter1");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Note_User1");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.HasIndex(e => e.QuizQuizId, "fk_Question_Quiz1_idx");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CorrectAnswer)
                    .HasMaxLength(2000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.QuizQuizId).HasColumnName("Quiz_QuizID");

                entity.HasOne(d => d.QuizQuiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizQuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Question_Quiz1");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("quiz");

                entity.HasIndex(e => e.ChapterChapterId, "fk_Quiz_Chapter1_idx");

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.Property(e => e.ChapterChapterId).HasColumnName("Chapter_ChapterID");

                entity.HasOne(d => d.ChapterChapter)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.ChapterChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Quiz_Chapter1");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("reply");

                entity.HasIndex(e => e.AskAskId, "fk_Reply_Ask1_idx");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.AskAskId).HasColumnName("Ask_AskID");

                entity.Property(e => e.Content)
                    .HasMaxLength(2000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.AskAsk)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.AskAskId)
                    .HasConstraintName("fk_Reply_Ask1");
            });

            modelBuilder.Entity<Saveblog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("saveblog");

                entity.HasIndex(e => e.BlogBlogId, "fk_SaveBlog_Blog1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_SaveBlog_User1_idx");

                entity.Property(e => e.BlogBlogId).HasColumnName("Blog_BlogID");

                entity.Property(e => e.SaveDay)
                    .HasColumnType("datetime")
                    .HasColumnName("save_day");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogBlog)
                    .WithMany()
                    .HasForeignKey(d => d.BlogBlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SaveBlog_Blog1");

                entity.HasOne(d => d.UserUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SaveBlog_User1");
            });

            modelBuilder.Entity<Savelike>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("savelike");

                entity.HasIndex(e => e.BlogBlogId, "fk_SaveLike_Blog1_idx");

                entity.HasIndex(e => e.UserUserId, "fk_SaveLike_User1_idx");

                entity.Property(e => e.BlogBlogId).HasColumnName("Blog_BlogID");

                entity.Property(e => e.UserUserId).HasColumnName("User_UserID");

                entity.HasOne(d => d.BlogBlog)
                    .WithMany()
                    .HasForeignKey(d => d.BlogBlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SaveLike_Blog1");

                entity.HasOne(d => d.UserUser)
                    .WithMany()
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SaveLike_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserRoleRoleId, "fk_User_UserRole1_idx");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.BackgroundImage)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Bio)
                    .HasMaxLength(300)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.CodeVerify).HasMaxLength(15);

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(50)
                    .HasColumnName("FacebookID")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Github)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.GithubId)
                    .HasMaxLength(50)
                    .HasColumnName("GithubID")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.GmailId)
                    .HasMaxLength(50)
                    .HasColumnName("GmailID")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserRoleRoleId).HasColumnName("UserRole_RoleID");

                entity.HasOne(d => d.UserRoleRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_UserRole1");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("userrole");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
