using Dapper;
using ICare.Core.ApiDTO.Patient;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICare.Infra.Repository
{
    public class ProcessBackground : IProcessBackground
    {
        private readonly IDbContext _DbContext;
        private readonly IMailingService _mailingService;
        private readonly INotificationServices _notificationServices;
        public ProcessBackground(IDbContext dbContext,
                                 IMailingService mailingService,
                                 INotificationServices notificationServices)
        {
            _DbContext = dbContext;
            _mailingService = mailingService;
            _notificationServices = notificationServices;
        }
        public void BringDrugsOnTime()
        {
            var  result = _DbContext.Connection.Query<SendDrugByEmailDTO.Response>
                          ("GetDrugsOnTime", commandType: CommandType.StoredProcedure);
             if(result.ToList().Count > 0)
            {
                
                foreach (var item in result)
                {
                    _notificationServices.Create(new Notification { Message = "Please take your medicine now " + item.NameDrug.ToUpper(),PatientId = item.Id });
                    _mailingService.SendEmailAsync(item.Email, "Drug", "Please take your medicine now " + item.NameDrug.ToUpper());
                }
            }
            
           
        }
    }
}
