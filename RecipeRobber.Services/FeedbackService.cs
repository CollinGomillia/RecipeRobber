using RecipeRobber.Data;
using RecipeRobber.Models.FeedbackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Services
{
    public class FeedbackService
    {
        private readonly Guid _userId;

        public FeedbackService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFeedback(FeedbackCreate model)
        {
            var entity =
                new Feedback()
                {
                   OwnerId = _userId,
                   AuthorId = model.AuthorId,
                   Comment = model.Comment,
                   Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Feedbacks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FeedbackGet> GetFeedbacks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Feedbacks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                               e =>
                                  new FeedbackGet
                                  {
                                      AuthorId = e.AuthorId,
                                      Comment = e.Comment,
                                      Rating = e.Rating
                                      
                                  }
                        );
                return query.ToArray();
            }
        }
       
        public FeedbackDetail GetFeedbackById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Feedbacks
                        .Single(e => e.AuthorId == id && e.OwnerId == _userId);
                return
                    new FeedbackDetail
                    {
                        AuthorId = entity.AuthorId,
                        Comment = entity.Comment,
                        Rating = entity.Rating
                       

                    };
            }
        }

        public bool DeleteFeedback(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Feedbacks
                       .Single(e => e.AuthorId == commentId && e.OwnerId == _userId);

                ctx.Feedbacks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}
