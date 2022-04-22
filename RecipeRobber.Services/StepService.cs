using RecipeRobber.Data;
using RecipeRobber.Models.StepModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Services
{
    public class StepService
    {
        private readonly Guid _userId;

        public StepService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSteps(StepCreate model)
        {
            var entity =
                new Step()
                {
                    OwnerId = _userId,
                    Instruction = model.Instruction,
                    StepId = model.StepId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Steps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StepGet> GetSteps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Steps
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                         e =>
                             new StepGet
                             {
                                 
                                 StepId = e.StepId,
                                 Instruction = e.Instruction

                             }
                         );
                return query.ToArray();
            }
        }

        public StepDetail GetStepById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Steps
                    .Single(e => e.StepId == id && e.OwnerId == _userId);

                return
                     new StepDetail
                     {
                         Instruction = entity.Instruction,
                         StepId = entity.StepId
                         
                     };
            }
        }

        public bool UpdateSteps(StepUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Steps
                    .Single(e => e.StepId == model.StepId);

                entity.Instruction = model.Instruction;

                ctx.SaveChanges();

                return true;
            }
        }

        public bool DeleteStep(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Steps
                    .Single(e => e.StepId == id);

                ctx.Steps.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
