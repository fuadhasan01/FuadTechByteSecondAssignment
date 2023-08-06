using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncryptDecrypt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string fileContent = Convert.ToBase64String(fileBytes);

                if (EncryptCheck.IsChecked == true)
                {
                    string encryptedText = Encrypt(fileContent);
                    OutputText.Text = encryptedText;
                }
                else if (DecryptCheck.IsChecked == true)
                {
                    string decryptedText = Decrypt(fileContent);
                    OutputText.Text = decryptedText;
                }
                else if (HashCheck.IsChecked == true)
                {
                    string hashCode = Hash(fileContent);
                    OutputText.Text = hashCode;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (EncryptCheck.IsChecked == true)
            {
                string text = RecieveText.Text;
                string output = Encrypt(text);
                OutputText.Text = output;
                RecieveText.Clear();
                
            }
            else if(DecryptCheck.IsChecked == true)
            {
                string text = RecieveText.Text;
                string output = Decrypt(text);
                OutputText.Text = output;
                RecieveText.Clear();
            }
            else if(HashCheck.IsChecked == true)
            {
                string text = RecieveText.Text;
                string output = Hash(text);
                OutputText.Text = output;
                RecieveText.Clear();
            }
        }

        private string Encrypt(string plainText)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.GenerateIV();
                aes.GenerateKey();

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                    }

                    byte[] encryptedBytes = ms.ToArray();
                    byte[] iv = aes.IV;
                    byte[] key = aes.Key;

                    // Here, you can store the IV and key securely for decryption later if needed.
                    // For demonstration purposes, we are converting them to Base64 strings and appending them to the result.
                    string result = Convert.ToBase64String(encryptedBytes) + "||" + Convert.ToBase64String(iv) + "||" + Convert.ToBase64String(key);
                    return result;
                }
            }
        }

        private string Decrypt(string encryptedText)
        {
            string[] parts = encryptedText.Split(new string[] { "||" }, StringSplitOptions.None);
            byte[] encryptedBytes = Convert.FromBase64String(parts[0]);
            byte[] iv = Convert.FromBase64String(parts[1]);
            byte[] key = Convert.FromBase64String(parts[2]);

            using (AesManaged aes = new AesManaged())
            {
                aes.IV = iv;
                aes.Key = key;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }

                    byte[] decryptedBytes = ms.ToArray();
                    string result = Encoding.UTF8.GetString(decryptedBytes);
                    return result;
                }
            }
        }

        private string Hash(string inputText)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputText);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string hashCode = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashCode;
            }
        }
    }
}
