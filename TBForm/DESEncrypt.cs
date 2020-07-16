using System;
using System.Security.Cryptography;  
using System.Text;
using System.Runtime.InteropServices;
namespace Infrastructure.CrossCutting.Framework.Encrypt
{
	/// <summary>
	/// DES����/�����ࡣ
    /// LiTianPing
	/// </summary>
	public class DESEncrypt
	{
        [DllImport("AESDLL.dll", EntryPoint = "GetAesCipher")]
        static extern int GetAesCipher(string sourStr, StringBuilder aesStr, string keyStr);
        [DllImport("AESDLL.dll", EntryPoint = "GetAesInvCipher")]
        static extern int GetAesInvCipher(string sourStr, StringBuilder aesStr, string keyStr);
        [DllImport("AESDLL.dll", EntryPoint = "GetMd5")]
        static extern int GetMd5(string sourStr, StringBuilder aesStr, int Lenght);
        static string Key = "www.esaipay.com/cllskdnajkdnsanp";
        static string CattleKey = "lvsiwmtsmxbxixpxwmwmjdwxolpqnwvsjdwxolpqnwvsbxixpxwmwmjdwxolpqnwvsvs";
        [DllImport("Cattle.dll", EntryPoint = "GetMd5Safe")]
        static extern void CattleMd5(string sourStr, StringBuilder aesStr, int Lenght);
        [DllImport("Cattle.dll", EntryPoint = "GetAesInvCipher")]
        static extern void CattleAesInvCipher(string sourStr, StringBuilder aesStr, string keyStr);
        [DllImport("Cattle.dll", EntryPoint = "GetAesCipher")]
        static extern void CattleAesCipher(string sourStr, StringBuilder aesStr, string keyStr);
		public DESEncrypt()
		{			
		}
        /// <summary>
        /// �ͻ��˻���MD5����
        /// </summary>
        /// <param name="sourStr">����ܵ��ִ�</param>
        /// <param name="aesStr">���ܽ��</param>
        /// <param name="Lenght">����</param>
        public static string GetCattleMd5(string sourStr,int Lenght)
        {
            StringBuilder md5Str = new StringBuilder(1000);
            CattleMd5(sourStr, md5Str, Lenght);
            CattleMd5(md5Str.ToString() + "�����ۺ�1515aac�ɷ�ϵͳ", md5Str, Lenght);
            string Result = md5Str.ToString().Trim().Replace(GetAsciiOne(), "");
            return Result;
        }

        /// <summary>
        /// ����AES����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <returns></returns>
        public static string ESaiCattleInvAes(string SourceStr)
        {
            StringBuilder aesinvStr = new StringBuilder(5000);
            CattleAesInvCipher(SourceStr, aesinvStr, CattleKey);
            return aesinvStr.ToString().Trim().Replace(GetAsciiOne(), "");
        }
        /// <summary>
        /// ����AES����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <returns></returns>
        public static string ESaiCattleAes(string SourceStr)
        {
            StringBuilder aesStr = new StringBuilder(5000);
            CattleAesCipher(SourceStr, aesStr, CattleKey);
            return aesStr.ToString().Trim().Replace(GetAsciiOne(), "");
        }


        public static string GetAsciiOne() 
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            byte[] byteArray = new byte[] { (byte)1 };
            string strCharacter = asciiEncoding.GetString(byteArray);
            return strCharacter;
        }
        /// <summary>
        /// ����AES����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <returns></returns>
        public static string ESaiAes(string SourceStr) 
        {
            if(string.IsNullOrEmpty(SourceStr))
            {
                return "";
            }
            StringBuilder aesStr = new StringBuilder(500000);
            GetAesCipher(SourceStr, aesStr, Key);
            return aesStr.ToString().Trim().Replace(GetAsciiOne(), "");
        }
        /// <summary>
        /// ����AES����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <returns></returns>
        public static string ESaiInvAes(string SourceStr)
        {
            if(string.IsNullOrEmpty(SourceStr))
            {
                return "";
            }
            StringBuilder aesinvStr = new StringBuilder(500000);
            GetAesInvCipher(SourceStr, aesinvStr, Key);
            return aesinvStr.ToString().Trim().Replace(GetAsciiOne(), "");
        }
        /// <summary>
        /// ����AES����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <returns></returns>
        public static string ESaiAesBig(string SourceStr)
        {
            StringBuilder aesStr = new StringBuilder(50000000);
            GetAesCipher(SourceStr, aesStr, Key);
            return aesStr.ToString().Trim().Replace(GetAsciiOne(), "");
        }
        /// <summary>
        /// ����AES����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <returns></returns>
        public static string ESaiInvAesBig(string SourceStr)
        {
            StringBuilder aesinvStr = new StringBuilder(50000000);
            GetAesInvCipher(SourceStr, aesinvStr, Key);
            return aesinvStr.ToString().Trim().Replace(GetAsciiOne(), "");
        }
        /// <summary>
        /// ����MD5����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <param name="Lenght">���ĳ���</param>
        /// <returns></returns>
        public static string ESaiMD5(string SourceStr, int Lenght)
        {
            StringBuilder md5Str = new StringBuilder(40);
            GetMd5(SourceStr, md5Str, Lenght);
            return md5Str.ToString().Trim().Replace(GetAsciiOne(), "");
        }

        public static string NewESaiMD5(string SourceStr, int Lenght)
        {
            StringBuilder md5Str = new StringBuilder(40);
            GetMd5(SourceStr, md5Str, Lenght);
            return md5Str.ToString().Trim().Replace(GetAsciiOne(), "").Substring(0, 9) + DateTime.Now.ToString("mmssfff");
        }

        //static Secret.Miwen sm = new Secret.Miwen();
        /// <summary>
        /// ����MD5����
        /// </summary>
        /// <param name="SourceStr">Ҫ���ܵ��ַ���</param>
        /// <param name="Lenght">���ĳ���</param>
        /// <returns></returns>
        //public static string ESaiOldMD5(string SourceStr, int Lenght)
        //{
        //    return sm.EsaiMd5(SourceStr, Lenght);
        //}
		#region ========����======== 
 
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
		public static string Encrypt(string Text) 
		{
			return Encrypt(Text,"MATICSOFT");
		}
		/// <summary> 
		/// �������� 
		/// </summary> 
		/// <param name="Text"></param> 
		/// <param name="sKey"></param> 
		/// <returns></returns> 
		public static string Encrypt(string Text,string sKey) 
		{ 
			DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
			byte[] inputByteArray; 
			inputByteArray=Encoding.Default.GetBytes(Text); 
			des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			System.IO.MemoryStream ms=new System.IO.MemoryStream(); 
			CryptoStream cs=new CryptoStream(ms,des.CreateEncryptor(),CryptoStreamMode.Write); 
			cs.Write(inputByteArray,0,inputByteArray.Length); 
			cs.FlushFinalBlock(); 
			StringBuilder ret=new StringBuilder(); 
			foreach( byte b in ms.ToArray()) 
			{ 
				ret.AppendFormat("{0:X2}",b); 
			} 
			return ret.ToString(); 
		} 

		#endregion
		
		#region ========����======== 
   
 
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
		public static string Decrypt(string Text) 
		{
			return Decrypt(Text,"MATICSOFT");
		}
		/// <summary> 
		/// �������� 
		/// </summary> 
		/// <param name="Text"></param> 
		/// <param name="sKey"></param> 
		/// <returns></returns> 
		public static string Decrypt(string Text,string sKey) 
		{ 
			DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
			int len; 
			len=Text.Length/2; 
			byte[] inputByteArray = new byte[len]; 
			int x,i; 
			for(x=0;x<len;x++) 
			{ 
				i = Convert.ToInt32(Text.Substring(x * 2, 2), 16); 
				inputByteArray[x]=(byte)i; 
			} 
			des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
			System.IO.MemoryStream ms=new System.IO.MemoryStream(); 
			CryptoStream cs=new CryptoStream(ms,des.CreateDecryptor(),CryptoStreamMode.Write); 
			cs.Write(inputByteArray,0,inputByteArray.Length); 
			cs.FlushFinalBlock(); 
			return Encoding.Default.GetString(ms.ToArray()); 
		} 
 
		#endregion 


	}
}
