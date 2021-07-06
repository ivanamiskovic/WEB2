using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class InstructionsService
    {
        public Instructions Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Instructions.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<Instructions> GetAll(int page, int perPage, string search, string sort)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Instructions.GetAll(page, perPage, search, sort);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Instructions Add(Instructions instruction)
        {
            //try
            //{
            using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
            {
                Instructions newInstruction = new Instructions();

                newInstruction.Name = instruction.Name;
                newInstruction.Order = instruction.Order;
                
                unitOfWork.Instructions.Add(newInstruction);
                unitOfWork.Complete();

                return newInstruction;
            }
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}

        }

        public bool Edit(int id, Instructions instruction)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Instructions instructionDB = Get(id);
                    unitOfWork.Instructions.Update(instructionDB);

                    instructionDB.Name = instruction.Name;
                    instructionDB.Order = instruction.Order;
                    
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
                    Instructions instruction = Get(id);
                    unitOfWork.Instructions.Update(instruction);

                    instruction.Deleted = true;

                    unitOfWork.Complete();


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
