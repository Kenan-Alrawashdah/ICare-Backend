using ICare.Core.ApiDTO.Patient;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICare.Infra.Services
{
    public class ProcessBackgroundService : IProcessBackgroundService
    {
        private readonly IProcessBackgroundRepository _processBackgroundRepository;
        private readonly IMailingService _mailingService;
        private readonly INotificationServices _notificationServices;

        public ProcessBackgroundService(IProcessBackgroundRepository processBackgroundRepository
                                         , IMailingService mailingService,
                                         INotificationServices notificationServices)
        {
            _processBackgroundRepository = processBackgroundRepository;
            _mailingService = mailingService;
            _notificationServices = notificationServices;
        }

        public void BringDrugsOnTime()
        {
            var result = _processBackgroundRepository.BringDrugsOnTime();
            if (result.ToList().Count > 0)
            {

                foreach (var item in result)
                {

                    Console.WriteLine("Drug :" + item.Email);
                    _notificationServices.Create(new Notification { Message = "Please take your medicine now " + item.NameDrug.ToUpper(), PatientId = item.Id });
                    _mailingService.SendEmailAsync(item.Email, "Drug", "Please take your medicine now " + item.NameDrug.ToUpper());
                }

            }
        }

        public void CheckExpierDrug()
        {
            var result = _processBackgroundRepository.CheckExpierDrug();
            if (result.ToList().Count > 0)
            {

                foreach (var item in result)
                {

                   Console.WriteLine("Drug :" + item.Email +":"+ item.NameDrug);
                    _notificationServices.Create(new Notification { Message = $"we want to alert you that your medicine {item.NameDrug.ToUpper()} has been expired ", PatientId = item.Id });
                    _mailingService.SendEmailAsync(item.Email, "Expire Drug", $"we want to alert you that your medicine {item.NameDrug.ToUpper()} has been expired ");
                }

            }
        }

        public void CheckExpierSubscription()
        {
            var result = _processBackgroundRepository.CheckExpierSubscription();
            if (result.ToList().Count > 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine("ExpierSubscription Email :" + item.Email);
                       _mailingService.SendEmailAsync(item.Email, "Expier subscription Icare", "Dear Icare subscriber, tomorrow your subscription will expire." +
                        " If you want to continue with us, renew your subscription");
                }
            }

        }

        public void CheckWaterOnTime()
        {
            var result = _processBackgroundRepository.CheckWaterOnTime();
            if (result.ToList().Count > 0)
            {
                foreach (var emil in result)
                {
                    Console.WriteLine("Water :" + emil);
                    //     _notificationServices.Create(new Notification { Message = "Please take your medicine now " + item.NameDrug.ToUpper(), PatientId = item.Id });
                    _mailingService.SendEmailAsync(emil, "Water", "Please drunk water now " );
                }
            }

        }


    }
}
