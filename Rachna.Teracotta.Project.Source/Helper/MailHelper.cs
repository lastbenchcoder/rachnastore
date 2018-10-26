using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.Helper
{
    public class MailHelper
    {
        private static string DomainUrl = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
        private static string AppName = ConfigurationSettings.AppSettings["AppName"].ToString();
        private static string MailAddressFrom = ConfigurationSettings.AppSettings["MailFrom"].ToString();
        private static string SmtpClient = ConfigurationSettings.AppSettings["SmtpClient"].ToString();
        private static string SmtpPort = ConfigurationSettings.AppSettings["SmtpPort"].ToString();
        private static string NetworkCredentialEmail = ConfigurationSettings.AppSettings["NetworkCredentialEmail"].ToString();
        private static string NetworkCredentialPwd = ConfigurationSettings.AppSettings["NetworkCredentialPwd"].ToString();
        public static string SendEmail(string ToEmailId, string Subject, string BodyMessage, string MailFrom)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(MailAddressFrom, MailFrom);
                mailMessage.To.Add(new MailAddress(ToEmailId));
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = Subject;
                mailMessage.Body = BodyMessage;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient(SmtpClient);
                smtpClient.Port = Convert.ToInt32(SmtpPort);
                System.Net.NetworkCredential MyCache = new System.Net.NetworkCredential(NetworkCredentialEmail, NetworkCredentialPwd);
                smtpClient.Credentials = MyCache;
                smtpClient.EnableSsl = false;
                smtpClient.Send(mailMessage);

                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message + "ToEmailId:";
            }
        }
        public static string PasswordResetLink(string host)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/noimage.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "Thanks for submitting the request, Please find your reset password link.<br />"
             + "<br />"
             + "<a href='" + host + "'>Click here to reset the password</a>"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Admin"
             + "</div>";
            return result;
        }
        public static string PasswordResetSuccess()
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "Thanks for submitting the request, Your password has been updated successfully.<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Admin"
             + "</div>";
            return result;
        }
        public static string EmailSubscribe()
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "Thanks for submitting the request, Your Email Updated in our database.<br />"
             + "You will recieve all the updates from our application.<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Admin"
             + "</div>";
            return result;
        }
        public static string EmailArticleUploaded(string url, string title)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "It's been good time, new article uploaded in our portal. We found it will helps to you.<br />"
             + "<h4>" + title + "</h4>"
             + "Click below link to read full article.<br />"
             + "<br />"
             + "<a href='" + url + "'>Click here to read full article</a>"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Admin"
             + "</div>";
            return result;
        }
        public static string InvitationLink(string host)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + " .<br />"
             + "<br />"
             + "<a href='" + host + "'>Click here to complete for your registration</a>"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Admin"
             + "</div>";
            return result;
        }

        public static string RequestRaised()
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
               + "<div>"
            + "Dear User,<br />"
            + "<br />"
            + "Thanks for submitting the request, Your request is in under process. Further communication to be communicated via email.<br />"
            + "<br />"
            + "Thanks,<br />"
            + "Rachna Teracotta Admin"
            + "</div>";
            return result;
        }
        public static string CustomerOrderPlaced(string Orders, string Fullname)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
             + "<div>"
             + "Dear," + Fullname + "<br />"
             + "<br />"
             + "Thanks for submitting the order, your order placed successfully and delivered on time.<br />"
             + "You can track your order by login to your account in rachna estore customer portal.<br />"
             + "<br />"
             + "<br />"
             + "<br />"
             + " " + Orders + " "
             + "<br />"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Store"
             + "</div>";
            return result;
        }

        public static string CustomerOrderCancelled(string Orders, string Fullname, string Reason)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
             + "<div>"
             + "Dear," + Fullname + "<br />"
             + "<br />"
             + "Your order has been cancelled.<br />"
             + " " + Reason + "<br/> "
             + "<br />"
             + "<br />"
             + "<br />"
             + " " + Orders + " "
             + "<br />"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Store"
             + "</div>";
            return result;
        }

        public static string CustomerOrderProcessed(string Orders, string Fullname, string Reason)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
             + "<div>"
             + "Dear," + Fullname + "<br />"
             + "<br />"
             + "Your order has been processed.<br />"
             + " " + Reason + "<br/> "
             + "<br />"
             + "<br />"
             + "<br />"
             + " " + Orders + " "
             + "<br />"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Store"
             + "</div>";
            return result;
        }
        public static string VerifyEmailLink(string host, string user)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
                + "<div>"
             + "Dear "+ user + ",<br />"
             + "<br />"
             + "Thank you for registering with us, Please click below link to verify your email id.<br />"
             + "<br />"
             + "<a href='" + host + "'>Click here to verify your email id</a>"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Store"
             + "</div>";
            return result;
        }

        public static string FunctionalityAddedOrUpdated(Functionality Functionality)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
                + "<div>"
             + "Dear Admin,<br />"
             + "<br />"
             + "New Functionality Added to the aplication.<br />"
             + "<h4>" + Functionality.Title + "</h4>"
             + "Click below link to read full functionality detail.<br />"
             + "<br />"
             + "<a href='/administration/defectmanager/functdetail.aspx?id=" + Functionality.Function_Id + "'>Click here to read full detail about functionality.</a>"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Admin"
             + "</div>";
            return result;
        }

        public static string DefectAddedOrUpdated(FunctionalDefect FunctionalDefect)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
                + "<div>"
             + "Dear Admin,<br />"
             + "<br />"
             + "New Defect Added to the aplication.<br />"
             + "<h4>" + FunctionalDefect.Title + "</h4>"
             + "Click below link to read full functionality detail.<br />"
             + "<br />"
             + "<a href='/administration/defectmanager/defectdetail.aspx?id=" + FunctionalDefect.Defect_Id + "'>Click here to read full detail about defectdetail.</a>"
             + "<br />"
             + "Thanks,<br />"
             + "Rachna Teracotta Admin"
             + "</div>";
            return result;
        }

        public static string AccountCreated(string fullname,string emailId, string password, string role)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/UnderConstrunction.png' width='200'></div>"
               + "<div>"
            + "Dear " + fullname + ",<br />"
            + "<br />"
            + "Your account has been created successfully in Rachna Teracotta. Please find your account detail, given below.<br />"
            + "<br />"
            + "EmailId : " + emailId
            + "<br />"
            + "Password : " + password
            + "<br />"
            + "Role : " + role
            + "<br />"
            + "Thanks,<br />"
            + "Rachna Teracotta Admin"
            + "</div>";
            return result;
        }
    }
}
