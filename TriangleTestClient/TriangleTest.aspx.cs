using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using TriangleTestClient.Models;

namespace TriangleTestClient
{
    public partial class TriangleTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Submit button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnTriangleType_Click(object sender, EventArgs e)
        {
            // dont do anything if page is invalid
            if(!Page.IsValid)
            {
                return;
            }           

            //create a triangle dto
            var triangle = new TriangleDto
            {
                A = decimal.Parse(A.Text),
                B = decimal.Parse(B.Text),
                C = decimal.Parse(C.Text),
            };

            //create a rest client
            var client = new RestClient("http://localhost:54643/api/geometry");
            var request = new RestRequest("determinetriangletype", Method.POST);
            request.AddJsonBody(triangle);

            //send request to service
            var restResponse = client.Execute(request);

            if(restResponse.StatusCode == System.Net.HttpStatusCode.OK) //success
            {
                var jObject = JObject.Parse(restResponse.Content);

                var triangleType = jObject.GetValue("triangleDescription").ToString();

                Output.Text = triangleType;
            }
            else if(restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest) //failure
            {
                var jObject = JObject.Parse(restResponse.Content);
                jObject.TryGetValue("errors", out JToken errors);
                if (errors != null)
                {
                    Output.Text = errors.ToString();
                }

                jObject.TryGetValue("errorMessage", out JToken errorMessage);

                if(errorMessage != null)
                {
                    Output.Text = errorMessage.ToString();
                }
            }


        }

        /// <summary>
        /// Custom validator to check user enters number greater than 0
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                var isNumber = decimal.TryParse(args.Value, out decimal number);
                if (isNumber && number > 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
    }
}