using GamifyLearnHub.Attributes;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Service;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigraDoc.DocumentObjectModel.IO;
using System.Xml.Linq;


namespace GamifyLearnHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certificationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CertificationController(ICertificationService certificationService, IWebHostEnvironment webHostEnvironment)
        {
            _certificationService = certificationService;
            _webHostEnvironment = webHostEnvironment;
        }



        [HttpGet]
        [CheckClaims("roleId", "1")]
        public async Task<List<Certification>> GetAllCertifications()
        {
            return await _certificationService.GetAllCertifications();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Certification> GetCertificationById(int id)
        {
            return await _certificationService.GetCertificationById(id);
        }

        [HttpGet]
        [Route("GetByUserId/{id}")]
        [CheckClaims("roleId", "3")]
        public async Task<List<Certification>> GetCertificationByUserId(int id)
        {
            return await _certificationService.GetCertificationByUserId(id);
        }


        [HttpGet]
        [Route("PassUser/{CourseSequence}")]
        public async Task<IActionResult> GetAllUsersPass(int CourseSequence)
        {
            var (UsersPass, Date_End) = await _certificationService.GetAllUsersPass(CourseSequence);

            if (Date_End == 1)
            {
                foreach (var user in UsersPass)
                {
                    byte[] pdfBytes = GeneratePdfCertificate(user.Firsname + user.Lastname, user.Coursename);

                    // Save PDF file
                    string fileName = $"{Guid.NewGuid().ToString()}_Certificate.pdf";
                    var filePath = Path.Combine("Files", fileName);
                    var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

                    await System.IO.File.WriteAllBytesAsync(fullPath, pdfBytes);

                    Certification certification = new Certification();
                    certification.Certificationimage = "https://localhost:7036/Files/" + fileName;
                    certification.Userid = user.Userid;
                    certification.Dateearned = DateTime.Today;
                    certification.Coursesequenceid = user.Coursesequenceid;
                    _certificationService.InsertCertification(certification);
                }

                _certificationService.GoToNextCourse(UsersPass);

               var rowsAffected = await _certificationService.UpdateCertificationStatus(CourseSequence);
                if (rowsAffected > 0)
                {
                    return Ok(new { RowsAffected = rowsAffected });
                }
                else
                {
                    return BadRequest("Create Certification Failed.");
                }
              
            }
            else
            {
                return BadRequest("End Date Not Yet.");
            }
        }

        byte[] GeneratePdfCertificate(string name, string language)
        {
            var ms = new MemoryStream();
            using (var doc = new Document(new Rectangle(PageSize.A4.Rotate())))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                // Set page margins
                doc.SetMargins(50, 50, 50, 50);

                // Add space to center content vertically
                doc.Add(new iTextSharp.text.Paragraph(" "));

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA, 24, Font.BOLD);
                var title = new iTextSharp.text.Paragraph("Certificate", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);



                string logoPath = "wwwroot/Images/IQ_Logo.png";
                Image logoImage = Image.GetInstance(logoPath);
                logoImage.ScaleToFit(100f, 60f);
                logoImage.SetAbsolutePosition(100f, 490f);
                doc.Add(logoImage);



              
               

                // Add space to center content vertically
                doc.Add(new iTextSharp.text.Paragraph(" "));

                var nameFont = FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD); // Larger and bold
                var nameParagraph = new iTextSharp.text.Paragraph($"This is to certify that {name} has successfully completed the {language} course.", nameFont);
                nameParagraph.Alignment = Element.ALIGN_CENTER; // Align to center
                doc.Add(nameParagraph);

                // Add space to center content vertically
                doc.Add(new iTextSharp.text.Paragraph(" "));

                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.NORMAL); // Larger
                var currentDate = DateTime.Now.ToString("MMMM dd, yyyy");
                var date = new iTextSharp.text.Paragraph($"Date of Issue: {currentDate}", dateFont);
                date.Alignment = Element.ALIGN_CENTER; // Align to center
                doc.Add(date);

                // Add space to center content vertically
                doc.Add(new iTextSharp.text.Paragraph(" "));

                var horizontalLine = new Chunk(new LineSeparator());
                doc.Add(new iTextSharp.text.Paragraph(horizontalLine));

                doc.Close();
            }

            return ms.ToArray();
        }





    }
}
