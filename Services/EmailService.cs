using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

public class EmailService
{
    public void SendEmail(string email)
    {
        // هنا تكتب كود الإرسال الفعلي
        Console.WriteLine($"Sending email to {email}...");

        // لو بتستخدم SMTP مثلا تكتب كود الإرسال هنا
        // أو تستدعي خدمة خارجية لإرسال الإيميلات
    }
}
}