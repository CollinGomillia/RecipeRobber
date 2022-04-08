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

        public bool CreateReview(FeedbackCreate model)
        {
            var entity =
                new Feedback()
                {
                   OwnerId = _userId,
                   Comment = model.Comment,
                   Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Feedbacks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FeedbackList> GetFeedbacks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Feedbacks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                               e =>
                                  new FeedbackList
                                  {
                                      AuthorId = e.AuthorId,
                                      Comment = e.Comment,
                                      Rating = e.Rating,
                                      RecipeId = e.RecipeId
                                  }
                        );
                return query.ToArray();
            }
        }
        public FeedbackGet GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Feedbacks
                        .Single(e => e.AuthorId == id && e.OwnerId == _userId);
                return
                    new FeedbackGet
                    {
                        AuthorId = entity.AuthorId,
                        Comment = entity.Comment,
                        Rating = entity.Rating,
                        RecipeId = entity.RecipeId

                    };
            }
        }

        public bool DeleteComment(int commentId)
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
