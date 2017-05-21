using System;
using System.IO;
using System.Reflection;


public class LogPile {		
	
	//defaults - use config file to customize	
	static string dateFormatFileNm = "yyyy-MM-dd"; //easily control file name rollover by using H, m or s in dateFormatFileNm. Default is daily.
	static string dateFormatLog = "yyyy-MM-dd HH:mm:ss:fff";
	
	static string dir = Environment.CurrentDirectory;
	static string fileNm = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
	static string fileExt = ".logpile";
	
	internal static void WriteLine(string level, string message) {
		DateTime date = DateTime.Now;
		string logFile = Path.Combine(dir, fileNm + "_" + date.ToString(dateFormatFileNm) + fileExt);
		string className = "ClassNameHere"; // todo:
		using (StreamWriter w = new StreamWriter(logFile, true)) {
			w.WriteLine(string.Format("{0}|{1}|{2}|{3}", date.ToString(dateFormatLog), level, className, message));			
		}
	}
	
	public static void Info(string message) {		
		WriteLine("INFO", message);
	}		

	public static void Debug(string message) {		
		WriteLine("DEBUG", message);
	}	

	public static void Warn(string message) {		
		WriteLine("WARN", message);
	}	

	public static void Fatal(string message) {		
		WriteLine("FATAL", message);
	}	

	public static void Error(string message) {		
		WriteLine("ERROR", message);
	}	

	public static void Custom(string level, string message) {		
		WriteLine(level, message);
	}
}