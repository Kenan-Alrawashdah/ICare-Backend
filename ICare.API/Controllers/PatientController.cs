using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;
        private readonly IUserServices _userServices;
        private readonly IFileService _fileService;

        public PatientController(IPatientServices patientServices, IUserServices userServices, IFileService fileService)
        {
            this._patientServices = patientServices;
            this._userServices = userServices;
            this._fileService = fileService;
        }

        [HttpPost]
        [Route("AddPatientDrug")]
        public async Task<ActionResult<ApiResponse>> AddPatientDrug(AddpatientDrugApiDTO.Request request)
        {
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);
            var response = new ApiResponse();
            var patientDrug = new PatientDrugs()
            {
                DrugName = request.DrugName,
                EndDate = request.EndDate,
                PatientId = patient.Id
            };
            List<DrugDoseTime> drugDoseTimeLsit = new List<DrugDoseTime>();

            if (request.drugDoseTime1 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime1
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime2 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime2
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime3 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime3
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime4 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime4
                };
                drugDoseTimeLsit.Add(d);
            }
            if(drugDoseTimeLsit.Count == 0)
            {
                response.AddError("must have at least on dose time");
                return Ok(response);
            }
          await  _patientServices.AddPatientDrugs(patientDrug, drugDoseTimeLsit);

            return Ok(response);
        }

        [HttpPost]
        [Route("InsertPDFData")]
        public async Task<ActionResult<ApiResponse>> InsertPDFData(IFormFile PdfFile)
        {
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);

            // var fileName = PdfFile.Name+ DateTime.Now.ToString("MM/dd/yyyy")+ "patientId="+ patient.Id+".pdf";
            var fileName = DateTime.Now.ToFileTime().ToString() + ".pdf";
            await _fileService.SaveFile(PdfFile, fileName, "PatientPDFFiles");

            //var x = PdfFile.FileName;//.pdf
            //var y = PdfFile.Name;//without .pdf


            FileStream docStream = new FileStream("wwwroot/Files/PatientPDFFiles/"+ fileName, FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            PdfLoadedForm form = loadedDocument.Form;

            var request =new InsertPDFDataHealthReportDTO.Request();

            request.CheckUpName = (form.Fields[0] as PdfLoadedTextBoxField).Text;
            request.BloodType = (form.Fields[1] as PdfLoadedTextBoxField).Text ;
            request.BloodSugarLevel = (form.Fields[2] as PdfLoadedTextBoxField).Text ;

            request.CheckUpDate = (form.Fields[3] as PdfLoadedTextBoxField).Text ;


            loadedDocument.Close(true);


            request.PatientId = patient.Id;

            var response = new ApiResponse();
            var result = _patientServices.InsertPDFData(request);
            if (result == null)
            {
                response.AddError("No Data In Pdf File");
                return Ok(response);
            }

            return Ok(response);
        }





    }
}
