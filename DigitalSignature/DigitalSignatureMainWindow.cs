using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Windows.Forms;
using DigitalSignature.Data.Entities;
using DigitalSignature.ECDSACustom;
using DigitalSignature.RSA;
using KeysProvider = DigitalSignature.RSA.KeysProvider;

namespace DigitalSignature
{
    public partial class DigitalSignatureMainWindow : Form
    {
        private RSADecryptor decryptor;

        private RSASigner signer;

        private KeysProvider keysProvider;

        private ECDSACustom.KeysProvider ecdsaKeysProvider;

        private CurveProvider curveProvider;

        private ECDSASigner ecdsaSigner;

        private ECDSAVerifier ecdsaVerifier;

        public DigitalSignatureMainWindow(RSADecryptor decryptor, RSASigner signer, KeysProvider keysProvider, ECDSACustom.KeysProvider ecdsaKeysProvider, CurveProvider curveProvider, ECDSASigner ecdsaSigner, ECDSAVerifier ecdsaVerifier)
        {
            this.decryptor = decryptor;
            this.signer = signer;
            this.keysProvider = keysProvider;
            this.ecdsaKeysProvider = ecdsaKeysProvider;
            this.curveProvider = curveProvider;
            this.ecdsaSigner = ecdsaSigner;
            this.ecdsaVerifier = ecdsaVerifier;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rSAToolStripMenuItem.Checked)
            {
                publicKeyE.Text = keysProvider.GetPublicKey().E.ToString();
                publicKeyN.Text = keysProvider.GetPublicKey().N.ToString();
            }
            if (eCDSAToolStripMenuItem.Checked)
            {
                publicKeyE.Text = ecdsaKeysProvider.GetPublicKey().X.ToString();
                publicKeyN.Text = ecdsaKeysProvider.GetPublicKey().Y.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rSAToolStripMenuItem.Checked)
            {
                keysProvider.ResetKeys();
            }
            if (eCDSAToolStripMenuItem.Checked)
            {
                ecdsaKeysProvider.Reset();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageToSend.Text) || string.IsNullOrWhiteSpace(publicKeyE.Text) || string.IsNullOrWhiteSpace(publicKeyN.Text))
            {
                return;
            }
            if (rSAToolStripMenuItem.Checked)
            {
                var start = DateTime.Now;
                var sign = signer.GetSignature(messageToSend.Text);
                var eNumber = BigInteger.Parse(publicKeyE.Text);
                var nNumber = BigInteger.Parse(publicKeyN.Text);


                var checkModel = decryptor.CheckSign(eNumber, nNumber, messageToSend.Text, sign);
                var end = DateTime.Now;
                signBox.Text = checkModel.Sign.ToString();
                sentMessageHashBox.Text = checkModel.SentMessageHash.ToString();
                decryptedSignHashBox.Text = checkModel.DecryptedSignHash.ToString();
                timeBox.Text = (end - start).TotalMilliseconds.ToString();
                if (checkModel.SignOk)
                {
                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Signature verified";
                }
                else
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = "Invalid sign";
                }
            }
            if(eCDSAToolStripMenuItem.Checked)
            {
                var start = DateTime.Now;
                var sign = ecdsaSigner.GetSignature(messageToSend.Text);
                var x = BigInteger.Parse(publicKeyE.Text);
                var y = BigInteger.Parse(publicKeyN.Text);

                var Q = new ECDSAPublicKey {X = x, Y = y};
                var checkModel = ecdsaVerifier.CheckSign(messageToSend.Text, sign, Q);
                var end = DateTime.Now;
                timeBox.Text = (end - start).TotalMilliseconds.ToString();
                signBox.Text = "s= " + sign.S + Environment.NewLine + "r= " + sign.R;
                sentMessageHashBox.Text = checkModel.MessageHash.ToString();
                decryptedSignHashBox.Text = string.Empty;

                if (checkModel.SignOk)
                {
                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Signature verified";
                }
                else
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = "Invalid sign";
                }
            }
            

        }

        private void rSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rSAToolStripMenuItem.Checked)
            {
                eCDSAToolStripMenuItem.Checked = false;
            }
            if (!rSAToolStripMenuItem.Checked)
            {
                rSAToolStripMenuItem.Checked = true;
            }

            pKeyName1.Text = "E=";
            pKeyName2.Text = "N=";
        }

        private void eCDSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eCDSAToolStripMenuItem.Checked)
            {
                rSAToolStripMenuItem.Checked = false;
            }
            if (!eCDSAToolStripMenuItem.Checked)
            {
                eCDSAToolStripMenuItem.Checked = true;
            }

            pKeyName1.Text = "Q.X=";
            pKeyName2.Text = "Q.Y=";
        }

    }
}
