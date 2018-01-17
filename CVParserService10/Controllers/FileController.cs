using CVParserService10.ServiceLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CVParserService10.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage upload()
        {
            HttpRequest request = HttpContext.Current.Request;
            CVConverterLogic logic = new CVConverterLogic();
            if (request.Files.Count != 1)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, "One File Allowed");
            }
            else
            {
                logic.saveFile(request.Files[0]);
                return Request.CreateResponse(HttpStatusCode.OK, request.Files);
            }
        }
    }
}
