using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Runtime;
namespace Sifravimas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        DES DESalg = DES.Create("DES");
        string CMode;
        static string TheWeekend;
        private void LibraryEncryptButton_Click(object sender, EventArgs e)
        {
            #region Kintamieji
            string ToEncrypt = LibraryRawTextBox.Text;
            byte[] data = Encoding.UTF8.GetBytes(ToEncrypt);
            string b64 = Convert.ToBase64String(data);
            string Path = @"C:\Users\kajus\Desktop\testSaugumas\b.txt"; // deklaruoju cia, kad galeciau lengviau keisti jei noreciau
            #endregion Kintamieji
            //
            // cia padarau, kad mazdaug taip atrodytu mano byte array, kur vartotojas pats iveda
            // var key = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef };
            //
            try
            {
                string[] holder = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text };
                var c = holder.Select(s => byte.Parse(s, NumberStyles.AllowHexSpecifier)).ToArray();
                DESalg.Key = c;
            }
            catch (Exception se)
            {
                MessageBox.Show("Most likely you've entered the wrong key");
                MessageBox.Show(se.Message);
            }
            if (CBCButton.Checked == true)
            {
                CMode = "CBC";
                DESalg.Mode = CipherMode.CBC;
            }
            if(ECBButton.Checked == true)
            {
                CMode = "ECB";
                DESalg.Mode = CipherMode.ECB;
                //DESalg.Padding = PaddingMode.None;
            }

            LibraryEncodedTextBox.Text = EncryptToFileAndTxtBox(LibraryRawTextBox.Text, Path, DESalg.Key, DESalg.IV, CMode);

            /*
            EncryptTextToFile(b64, Path, DESalg.Key, DESalg.IV, CMode);
            //using FileStream fStream = File.Open(Path, FileMode.OpenOrCreate);
            //LibraryEncodedTextBox.Text = File.ReadAllText(Path);
            string temp_inBase64 = Convert.ToBase64String(EncryptTextToMemory(LibraryRawTextBox.Text, DESalg.Key, DESalg.IV));
            byte[] temp_backToBytes = Convert.FromBase64String(temp_inBase64);
            LibraryRawTextBox.Text = DecryptTextFromMemory(temp_backToBytes,DESalg.Key, DESalg.IV);

            LibraryEncodedTextBox.Text = temp_inBase64;
            */
            MessageBox.Show("Encryption was a success!");


        }


        private void LibraryDecryptButton_Click(object sender, EventArgs e)
        {
            #region Kintamieji
            //string TxtFileName = DateTime.Now.ToString() + ".txt";
            //DES DESalg = DES.Create("DES");
            string Path = @"C:\Users\kajus\Desktop\testSaugumas\b.txt"; // deklaruoju cia, kad galeciau lengviau keisti jei noreciau
            #endregion Kintamieji
            //
            // cia padarau, kad mazdaug taip atrodytu mano byte array, kur vartotojas pats iveda
            // var key = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef };
            // labai negraziai, zinau, bet taip yra lengviausia isvengti, kad raktas per didelis ar per mazas ar kas nors tokio
            //
            if (CBCButton.Checked == true)
            {
                CMode = "CBC";
                DESalg.Mode = CipherMode.CBC;
            }
            if (ECBButton.Checked == true)
            {
                CMode = "ECB";
                DESalg.Mode = CipherMode.ECB;
            }
            try
            {
                string[] holder = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text };
                var c = holder.Select(s => byte.Parse(s, NumberStyles.AllowHexSpecifier)).ToArray();
                DESalg.Key = c;
                //byte[] Data = Encoding.UTF8.GetBytes(LibraryEncodedTextBox.Text);
                byte[] temp_Data = Convert.FromBase64String(LibraryEncodedTextBox.Text);
                string Final = DecryptTextFromMemory(temp_Data, DESalg.Key, DESalg.IV, LibraryEncodedTextBox.Text, CMode);
                LibraryRawTextBox.Text = Final;
            }
            catch (Exception se)
            {
                MessageBox.Show("Exception thrown - most likely you've entered the wrong key!");
                Debug.WriteLine(se.Message);
            }

        }


        private string EncryptToFileAndTxtBox(String Data, String FileName, byte[] Key, byte[] IV, string CMode)
        {
            try
            {
                if (CMode == "ECB")
                {
                    Debug.WriteLine("ECB Mode used in EncryptTXT");
                    //
                    // UZKODUOJA ATMINTYJE, VELIAU PERKELIA I FILE
                    //
                    using MemoryStream mStream = new MemoryStream();
                    DES DESalg = DES.Create();
                    //DESalg.Padding = PaddingMode.Zeros;
                    DESalg.Mode = CipherMode.ECB;
                    DESalg.Key = Key;
                    CryptoStream cStream = new CryptoStream(mStream,
                        DESalg.CreateEncryptor(),
                        CryptoStreamMode.Write);
                    byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);
                    cStream.Write(toEncrypt, 0, toEncrypt.Length);
                    cStream.FlushFinalBlock();
                    byte[] ret = mStream.ToArray();
                    cStream.Close();
                    mStream.Close();
                    //
                    // PAVERCIU I BASE 64 BYTE ARRAY, KAD GALECIAU GRAZIAI PARODYT, O NE KINIETISKUS SIMBOLIUS KAZKOKIUS RODYTI
                    //
                    string temp_inBase64 = Convert.ToBase64String(ret);
                    //
                    // IRASO I FILE
                    //
                    using (StreamWriter writer = new StreamWriter(FileName))
                    {
                        writer.Write(temp_inBase64);
                    }
                    return temp_inBase64;

                }
                else
                {
                    Debug.WriteLine("CBC Mode used in EncryptTXT");
                    //
                    // UZKODUOJA ATMINTYJE, VELIAU PERKELIA I FILE
                    //
                    using MemoryStream mStream = new MemoryStream();
                    DES DESalg = DES.Create();
                    //DESalg.Padding = PaddingMode.Zeros;
                    DESalg.Mode = CipherMode.CBC;
                    CryptoStream cStream = new CryptoStream(mStream,
                        DESalg.CreateEncryptor(Key, IV),
                        CryptoStreamMode.Write);
                    byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);
                    cStream.Write(toEncrypt, 0, toEncrypt.Length);
                    cStream.FlushFinalBlock();
                    byte[] ret = mStream.ToArray();
                    cStream.Close();
                    mStream.Close();
                    //
                    // PAVERCIU I BASE 64 BYTE ARRAY, KAD GALECIAU GRAZIAI PARODYT, O NE KINIETISKUS SIMBOLIUS KAZKOKIUS RODYTI
                    //
                    string temp_inBase64 = Convert.ToBase64String(ret);
                    //
                    // IRASO I FILE
                    //
                    using (StreamWriter writer = new StreamWriter(FileName))
                    {
                        writer.Write(temp_inBase64);
                    }
                    return temp_inBase64;
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        private void FileDecryptButton_Click(object sender, EventArgs e)
        {

            #region Kintamieji
            var content = string.Empty;;
            using (OpenFileDialog ofd = new OpenFileDialog())
            { 
                string path;
                ofd.Filter = "txt files (*.txt)|*.txt";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                    var data = ofd.OpenFile();
                    using (StreamReader sr = new StreamReader(data))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            byte[] temp_Data = Convert.FromBase64String(content);
            //string TxtFileName = DateTime.Now.ToString() + ".txt";
            //DES DESalg = DES.Create("DES");
            //string Path = @"C:\Users\kajus\Desktop\testSaugumas\b.txt"; // deklaruoju cia, kad galeciau lengviau keisti jei noreciau
            #endregion Kintamieji
            //
            // cia padarau, kad mazdaug taip atrodytu mano byte array, kur vartotojas pats iveda
            // var key = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef };
            // labai negraziai, zinau, bet taip yra lengviausia isvengti, kad raktas per didelis ar per mazas ar kas nors tokio
            //
            if (CBCButton.Checked == true)
            {
                CMode = "CBC";
                DESalg.Mode = CipherMode.CBC;
            }
            if (ECBButton.Checked == true)
            {
                CMode = "ECB";
                DESalg.Mode = CipherMode.ECB;
            }
            try
            {
                string[] holder = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text };
                var c = holder.Select(s => byte.Parse(s, NumberStyles.AllowHexSpecifier)).ToArray();
                DESalg.Key = c;
                string Final = DecryptTextFromFileaaa(DESalg.Key, DESalg.IV, CMode, temp_Data);
                LibraryRawTextBox.Text = Final;
            }
            catch (Exception se)
            {
                MessageBox.Show("Exception thrown - most likely you've entered the wrong key!");
                Debug.WriteLine(se.Message);
            }
        }
        public static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV, string Contents, string CMode)
        {
            //byte[] temp_backToBytes = Convert.FromBase64String(Contents);
            try
            {
                if (CMode == "ECB")
                {
                    Debug.WriteLine("ECB Mode used in DecryptTXT");
                    using MemoryStream msDecrypt = new MemoryStream(Data);
                    DES DESalg = DES.Create();
                    //DESalg.Padding = PaddingMode.Zeros;
                    DESalg.Key = Key;
                    DESalg.Mode = CipherMode.ECB;
                    CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                        DESalg.CreateDecryptor(),
                        CryptoStreamMode.Read);
                    byte[] fromEncrypt = new byte[Data.Length];
                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                    return new ASCIIEncoding().GetString(fromEncrypt);

                }
                else
                {
                    
                    Debug.WriteLine("CBC Mode used in DecryptTXT");
                    using MemoryStream msDecrypt = new MemoryStream(Data);
                    DES DESalg = DES.Create();
                    //DESalg.Padding = PaddingMode.Zeros;
                    DESalg.Mode = CipherMode.CBC;
                    CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                        DESalg.CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);
                    byte[] fromEncrypt = new byte[Data.Length];
                    Debug.WriteLine("This is what was decrypted: ");
                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                    Debug.WriteLine(new ASCIIEncoding().GetString(fromEncrypt));
                    return new ASCIIEncoding().GetString(fromEncrypt);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        public static string DecryptTextFromFileaaa(byte[] Key, byte[] IV, string CMode, byte[] Data)
        {

            try
            {
                if (CMode == "ECB")
                {
                    Debug.WriteLine("ECB Mode used in DecryptTXT");
                    using MemoryStream msDecrypt = new MemoryStream(Data);
                    DES DESalg = DES.Create();
                    //DESalg.Padding = PaddingMode.Zeros;
                    DESalg.Key = Key;
                    DESalg.Mode = CipherMode.ECB;
                    CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                        DESalg.CreateDecryptor(),
                        CryptoStreamMode.Read);
                    byte[] fromEncrypt = new byte[Data.Length];
                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                    return new ASCIIEncoding().GetString(fromEncrypt);

                }
                else
                {

                    Debug.WriteLine("CBC Mode used in DecryptTXT");
                    using MemoryStream msDecrypt = new MemoryStream(Data);
                    DES DESalg = DES.Create();
                    //DESalg.Padding = PaddingMode.Zeros;
                    DESalg.Mode = CipherMode.CBC;
                    CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                        DESalg.CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);
                    byte[] fromEncrypt = new byte[Data.Length];
                    Debug.WriteLine("This is what was decrypted: ");
                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                    Debug.WriteLine(new ASCIIEncoding().GetString(fromEncrypt));
                    return new ASCIIEncoding().GetString(fromEncrypt);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        public static string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV, string CMode)
        {
            try
            {
                // Create or open the specified file.
                using FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a new DES object.
                DES DESalg = DES.Create();
                if (CMode == "ECB")
                {
                    Debug.WriteLine("ECB Mode used in DecryptTXT");
                    //DESalg.Padding = PaddingMode.None;
                    DESalg.Mode = CipherMode.ECB;
                    DESalg.Key = Key;
                    // Create a CryptoStream using the FileStream
                    // and the passed key and initialization vector (IV).
                    CryptoStream cStream = new CryptoStream(fStream,
                        DESalg.CreateDecryptor(),
                        CryptoStreamMode.Read);
                    // Create a StreamReader using the CryptoStream.
                    StreamReader sReader = new StreamReader(cStream);

                    // Read the data from the stream
                    // to decrypt it.
                    string val = sReader.ReadLine();

                    // Close the streams and
                    // close the file.
                    //cStream.FlushFinalBlock();
                    sReader.Close();
                    cStream.Close();
                    fStream.Close();
                    // Return the string.
                    return val;
                }
                else
                {
                    Debug.WriteLine("CBC Mode used in DecryptTXT");
                    DESalg.Mode = CipherMode.CBC;
                    // Create a CryptoStream using the FileStream
                   // and the passed key and initialization vector (IV).
                    CryptoStream cStream = new CryptoStream(fStream,
                        DESalg.CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);
                    // Create a StreamReader using the CryptoStream.
                    StreamReader sReader = new StreamReader(cStream);

                    // Read the data from the stream
                    // to decrypt it.
                    string val = sReader.ReadLine();

                    // Close the streams and
                    // close the file.
                    sReader.Close();
                    cStream.Close();
                    fStream.Close();
                    // Return the string.
                    return val;
                }


            }
            catch (CryptographicException e)
            {
                MessageBox.Show("An error had ocurred, make sure you're using the right deciphering mode.");
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
        }
        public static string DecryptTextFromTextBox(String FileName, byte[] Key, byte[] IV, string CMode, string Contents)
        {
            byte[] data = Encoding.UTF8.GetBytes(Contents);
            string result;
            try
            {
                using MemoryStream mStream = new MemoryStream(data);
                DES DESalg = DES.Create();
                //DESalg.Padding = PaddingMode.PKCS7;
                if (CMode == "ECB")
                {
                    Debug.WriteLine("ECB Mode used in DecryptTXT");
                    //DESalg.Padding = PaddingMode.None;
                    DESalg.Mode = CipherMode.ECB;
                    DESalg.Key = Key;
                    CryptoStream cStream = new CryptoStream(mStream,
                        DESalg.CreateDecryptor(),
                        CryptoStreamMode.Read);
                    StreamReader sReader = new StreamReader(cStream);
                    string val = sReader.ReadLine();
                    cStream.FlushFinalBlock();
                    sReader.Close();
                    cStream.Close();
                    mStream.Close();
                    return val;
                }
                else
                {
                    Debug.WriteLine("CBC Mode used in DecryptTXT");
                    DESalg.Mode = CipherMode.CBC;
                    using (MemoryStream msDecrypt = new MemoryStream(System.Convert.ToByte(Contents)))
                    {
                        using (ICryptoTransform decryptor = DESalg.CreateDecryptor(Key, IV))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                                {
                                    result = swDecrypt.ReadToEnd();
                                }
                            }
                        }
                    }
                    DESalg.Clear();
                    return result;
                    /*
                    // Create a CryptoStream using the FileStream
                    // and the passed key and initialization vector (IV).
                    CryptoStream cStream = new CryptoStream(mStream,
                        DESalg.CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);
                    // Create a StreamReader using the CryptoStream.
                    StreamReader sReader = new StreamReader(cStream);

                    // Read the data from the stream
                    // to decrypt it.
                    string val = sReader.ReadLine();

                    // Close the streams and
                    // close the file.
                    sReader.Close();
                    cStream.Close();
                    mStream.Close();
                    // Return the string.
                    return val;*/
                }


            }
            catch (CryptographicException e)
            {
                MessageBox.Show("An error had ocurred, make sure you're using the right deciphering mode.");
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);

                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
        }

    }
}




