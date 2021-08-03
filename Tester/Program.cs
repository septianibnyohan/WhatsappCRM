using S22.Imap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var TestString = @"<p>Terima kasih Angga Prasetya sudah memesan anda sudah berhasil melakukan pemesanan Course Metode Cordobana, berikut ini detilnya:</p>
                        <p>Nama: Angga Prasetya<br />Alamat email: anggaceria@gmail.com<br />Nomor Whatsapp: 082122277700<br />Kota Domisili: Bandung</p>
                        <p>Course : Baca Quran Metode Qordobana<br />Total Invoice : Rp 147.000</p>
                        <p>Mohon untuk melakukan transfer ke salah satu rekening berikut ini:</p>
                        <p>BCA 1234567890 a.n Fulan Bin Fulan<br />BNI 1234567890 a.n Fulan Bin Fulan<br />BRI 1234567890 a.n Fulan Bin Fulan<br />Mandiri 1234567890 a.n Fulan Bin Fulan</p>
                        <p>Jika anda sudah melakukan transfer, mohon untuk konfirmasi bukti transfer, dengan membalas pesan whatsapp ini.</p>
                        <p>Terima kasih,</p>
                        <p>Admin Qordobana</p>";
            //StringWriter writer = new StringWriter();
            //HttpUtility.HtmlEncode(TestString, writer);
            //String EncodedString = writer.ToString();
            string wow = HttpUtility.HtmlDecode(TestString);
            string teslagi = HTMLToText(TestString);
            string htmltotext = HTMLToText(HttpUtility.HtmlDecode(TestString));
            

            //var wow = HttpUtility.HtmlDecode(test);
        }

        public static string HTMLToText(string HTMLCode)
        {
            // Remove new lines since they are not visible in HTML
            //HTMLCode = HTMLCode.Replace("\n", " ");

            // Remove tab spaces
            HTMLCode = HTMLCode.Replace("\t", " ");

            // Remove multiple white spaces from HTML
            //HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

            // Remove HEAD tag
            HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Remove any JavaScript
            HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
              , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Replace special characters like &, <, >, " etc.
            StringBuilder sbHTML = new StringBuilder(HTMLCode);
            // Note: There are many more special characters, these are just
            // most common. You can add new characters in this arrays if needed
            string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;",
                "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
            string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢" };
            for (int i = 0; i < OldWords.Length; i++)
            {
                sbHTML.Replace(OldWords[i], NewWords[i]);
            }

            // Check if there are line breaks (<br>) or paragraph (<p>)
            sbHTML.Replace("<br>", "\n<br>");
            sbHTML.Replace("<br", "\n<br");
            sbHTML.Replace("<p", "\n\n<p");

            // Finally, remove all HTML tags and return plain text
            return System.Text.RegularExpressions.Regex.Replace(
              sbHTML.ToString(), "<[^>]*>", "");
        }
    }
}
