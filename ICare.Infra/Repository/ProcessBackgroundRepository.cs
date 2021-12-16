using Dapper;
using ICare.Core.ApiDTO.Patient;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICare.Infra.Repository
{
    public class ProcessBackgroundRepository : IProcessBackgroundRepository
    {
        private readonly IDbContext _DbContext;
        private readonly IMailingService _mailingService;
        private readonly INotificationServices _notificationServices;
        public ProcessBackgroundRepository(IDbContext dbContext,
                                 IMailingService mailingService,
                                 INotificationServices notificationServices)
        {
            _DbContext = dbContext;
            _mailingService = mailingService;
            _notificationServices = notificationServices;
        }
        public IEnumerable<SendDrugByEmailDTO.Response> BringDrugsOnTime()
        {
            var  result = _DbContext.Connection.Query<SendDrugByEmailDTO.Response>
                          ("GetDrugsOnTime", commandType: CommandType.StoredProcedure);

          

            return result;
        }

        public IEnumerable<string> CheckWaterOnTime()
        {
            var emails = _DbContext.Connection.Query<string>
                          ("checkWaterOnTime", commandType: CommandType.StoredProcedure);

            return emails;
        }
    }
}


/*create proc checkWaterOnTime
 as
 DECLARE @hour  int
SET @hour = datepart(hour, getdate())
DECLARE @mi  int
SET @mi = datepart(mi, getdate())
DECLARE @minet  int
set @minet = @hour * 60 + @mi
 select u.Email 
 from Water w 
 join Patient p on p.Id = w.PatientId
 join [dbo].[User] u on u.id = p.UserId
 where w.FromTime <= concat(@hour,':',@mi,':00') 
 and
 w.ToTime >= concat(@hour,':',@mi,':00')
 and @minet % w.Every = 0
 */