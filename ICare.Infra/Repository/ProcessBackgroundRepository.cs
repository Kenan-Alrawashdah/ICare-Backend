using Dapper;
using ICare.Core.ApiDTO.Patient;
using ICare.Core.ApiDTO.User;
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

        public IEnumerable<SendDrugByEmailDTO.Response> CheckExpierDrug()
        {
            var result = _DbContext.Connection.Query<SendDrugByEmailDTO.Response>
                          ("CheckExpierDrug", commandType: CommandType.StoredProcedure);



            return result;
        }

        //GetExpierSubscriptionDTO

        public IEnumerable<GetExpierSubscriptionDTO> CheckExpierSubscription()
        {
            var result = _DbContext.Connection.Query<GetExpierSubscriptionDTO>
                          ("CheckPatientSubscription", commandType: CommandType.StoredProcedure);

            return result;
        }
    }

}


