using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace RsaSignatureConfirmation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void startbtn_Click(object sender, EventArgs e)
        {
            logsTextBox.Text = "Server running...\n";
            IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, 11_001);


            using Socket listener = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(100);


            while (true)
            {
                var handler = await listener.AcceptAsync();
                await Task.Run(async () =>
                {
                    try
                    {
                        while (true)
                        {
                            // Receive message.
                            var buffer = new byte[1_024];
                            var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                            var response = Encoding.UTF8.GetString(buffer, 0, received);

                            var eom = "<|EOM|>";
                            if (response.IndexOf(eom) > -1 /* is end of message */)
                            {

                                if (response.Replace(eom, "").StartsWith("M@"))
                                {
                                    messsageTextBox.Text = response.Replace(eom, "").Replace("M@", "");
                                }
                                else if (response.Replace(eom, "").StartsWith("K@"))
                                {
                                    keyTextBox.Text = response.Replace(eom, "").Replace("K@", "");
                                }
                                else if (response.Replace(eom, "").StartsWith("S@"))
                                {
                                    signatureTextBox.Text = response.Replace(eom, "").Replace("S@", "");
                                }

                                var ackMessage = "<|ACK|>";
                                var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                                await handler.SendAsync(echoBytes, 0);
                                logsTextBox.Text += $"Socket server received a message\n";
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logsTextBox.Text += ex.Message;
                    }

                    finally
                    {
                        handler.Dispose();
                    }
                });
            }
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            using SHA256 alg = SHA256.Create();

            byte[] data = Encoding.ASCII.GetBytes(messsageTextBox.Text);
            byte[] hash = alg.ComputeHash(data);
            byte[] publicKey = Convert.FromBase64String(keyTextBox.Text);
            byte[] signature = Convert.FromBase64String(signatureTextBox.Text);

            // create an instance of RSACryptoServiceProvider
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            // import the public key
            rsa.ImportRSAPublicKey(publicKey, out _);

            // verify the signature
            bool isSignatureValid = rsa.VerifyHash(hash, "SHA256", signature);

            if (isSignatureValid)
            {
                logsTextBox.Text += "------------------------\nSignature is valid.\n------------------------\n";
            }
            else
            {
                logsTextBox.Text += "------------------------\nSignature is not valid.\n------------------------\n";
            }
        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}