using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J_LearingSystem.Models;

namespace J_LearningSystem.Data
{
     public class UnitOfWork
    {
        SystemContext _db;

        BaseRepository<Student> studentRepository { get; set; }
        BaseRepository<Staff> staffRepository { get; set; }
        BaseRepository<Schedule> scheduleRepository { get; set; }
        BaseRepository<Course> courseRepository { get; set; }
        BaseRepository<Quiz> quizRepository { get; set; }
        BaseRepository<Question> questionRepository { get; set; }
        BaseRepository<QuestionOption> questionOptionRepository { get; set; }
        BaseRepository<Answer> answerRepository { get; set; }
        BaseRepository<Forum> forumRepository { get; set; }
        BaseRepository<Topic> topicRepository { get; set; }
        BaseRepository<Reply> replyRepository { get; set; }
        BaseRepository<Video> videoRepository { get; set; }

        public UnitOfWork()
        {
            _db = new SystemContext();
        }

        public BaseRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new BaseRepository<Student>(_db);

                return studentRepository;
            }
        }

        public BaseRepository<Staff> StaffRepository
        {
            get
            {
                if (staffRepository == null)
                    staffRepository = new BaseRepository<Staff>(_db);

                return staffRepository;
            }
        }

        public BaseRepository<Schedule> ScheduleRepository
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new BaseRepository<Schedule>(_db);

                return scheduleRepository;
            }
        }

        public BaseRepository<Course> CourseRepository
        {
            get
            {
                if (courseRepository == null)
                    courseRepository = new BaseRepository<Course>(_db);

                return courseRepository;
            }
        }

        public BaseRepository<Quiz> QuizRepository
        {
            get
            {
                if (quizRepository == null)
                    quizRepository = new BaseRepository<Quiz>(_db);

                return quizRepository;
            }
        }

        public BaseRepository<Question> QuestionRepository
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new BaseRepository<Question>(_db);

                return questionRepository;
            }
        }

        public BaseRepository<QuestionOption> QuestionOptionRepository
        {
            get
            {
                if (questionOptionRepository == null)
                    questionOptionRepository = new BaseRepository<QuestionOption>(_db);

                return questionOptionRepository;
            }
        }

        public BaseRepository<Answer> AnswerRepository
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new BaseRepository<Answer>(_db);

                return answerRepository;
            }
        }

        public BaseRepository<Forum> ForumRepository
        {
            get
            {
                if (forumRepository == null)
                    forumRepository = new BaseRepository<Forum>(_db);

                return forumRepository;
            }
        }

        public BaseRepository<Topic> TopicRepository
        {
            get
            {
                if (topicRepository == null)
                    topicRepository = new BaseRepository<Topic>(_db);

                return topicRepository;
            }
        }

        public BaseRepository<Reply> ReplyRepository
        {
            get
            {
                if (replyRepository == null)
                    replyRepository = new BaseRepository<Reply>(_db);

                return replyRepository;
            }
        }

        public BaseRepository<Video> VideoRepository
        {
            get
            {
                if (videoRepository == null)
                    videoRepository = new BaseRepository<Video>(_db);

                return videoRepository;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
