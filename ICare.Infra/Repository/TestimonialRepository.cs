using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ICare.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
            var param = new DynamicParameters();

            param.Add("@created_at", testimonial.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@userName", testimonial.userName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@userSubject", testimonial.userSubject, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@userEmail", testimonial.userEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@userPhone", testimonial.userPhone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@userMessage", testimonial.userMessage, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@isProved", testimonial.isProved, dbType: DbType.Boolean, direction: ParameterDirection.Input);


            try
            {

                var result = _dbContext.Connection.Execute("TestimonialInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public IEnumerable<Testimonial> GetAllTestimonial()
        {
            var carts = _dbContext.Connection.Query<Testimonial>("GetAllTestimonial", commandType: CommandType.StoredProcedure);

            return carts;
        }
    }
}
