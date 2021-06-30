using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class SolutionService
    {
        public Solution Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Solutions.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<Solution> GetAll(int page, int perPage, string search)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Solutions.GetAll(page, perPage, search, "ASC");
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Solution solution)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Solution newSolution = new Solution();

                    newSolution.Cause = solution.Cause;
                    newSolution.ConstructionType = solution.ConstructionType;
                    newSolution.Deleted = solution.Deleted;
                    newSolution.Id = solution.Id;
                    newSolution.Material = solution.Material;
                    newSolution.SubCase = solution.SubCase;

                    unitOfWork.Solutions.Add(newSolution);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, Solution solution)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Solution solutionDB = Get(id);
                    unitOfWork.Solutions.Update(solutionDB);

                    solutionDB.Cause = solution.Cause;
                    solutionDB.ConstructionType = solution.ConstructionType;
                    solutionDB.Deleted = solution.Deleted;
                    solutionDB.Id = solution.Id;
                    solutionDB.Material = solution.Material;
                    solutionDB.SubCase = solution.SubCase;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Solution solution = Get(id);
                    unitOfWork.Solutions.Remove(solution);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
